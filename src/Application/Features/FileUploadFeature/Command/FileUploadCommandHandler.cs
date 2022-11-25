using Application.Interfaces;
using Application.Request.FileUpload;
using Domain.Entities;
using MediatR;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.FileUploadFeature.Command
{
    /// <summary>
    ///
    /// </summary>
    /// <seealso cref="MediatR.IRequestHandler{FileUploadRequest, (bool succeed, string message)}" />
    public class FileUploadCommandHandler : IRequestHandler<FileUploadRequest, (bool succeed, string message)>
    {
        private readonly IUploadService uploadService;
        private readonly IApplicationDbContext applicationDbContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="FileUploadCommandHandler"/> class.
        /// </summary>
        /// <param name="uploadService">The upload service.</param>
        /// <param name="applicationDbContext">The application database context.</param>
        public FileUploadCommandHandler(IUploadService uploadService, IApplicationDbContext applicationDbContext)
        {
            this.uploadService = uploadService;
            this.applicationDbContext = applicationDbContext;
        }

        /// <summary>
        /// Handles a request
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>
        /// Response from the request
        /// </returns>
        public async Task<(bool succeed, string message)> Handle(FileUploadRequest request, CancellationToken cancellationToken)
        {
            if (request?.FormFile == null || request.FormFile?.Length == 0)
            {
                return (false, "There is no file to be uploaded");
            }

            var uploaded = await uploadService.UploadToServer(request.FormFile, request.EntityType.ToString());
            if (!string.IsNullOrEmpty(uploaded))
            {
                await applicationDbContext.FileUploads.AddAsync(new
                    FileUpload
                {
                    EntityId = request.EntityId,
                    EntityType = request.EntityType,
                    File = uploaded,
                    MimeType = request.FormFile.ContentType,
                    Name = request.Name,
                    DateCreated = DateTimeOffset.Now,
                    Ext = Path.GetExtension(request.FormFile.FileName),
                    Size = request.FormFile.Length
                });

                await applicationDbContext.SaveChangesAsync(cancellationToken);
                return (true, "File uploaded successfully");
            }
            return (false, "File could not be uploaded. Contact administrator for details");
        }
    }
}