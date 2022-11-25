using Application.Interfaces;
using Application.Request.FileUpload;
using Application.Response.FileUpload;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.FileUploadFeature.Query
{
    /// <summary>
    ///
    /// </summary>
    /// <seealso cref="IRequestHandler{GetUploadedFileRequest, (bool succeed, string message, GetUploadedFileResponse[] file)}" />
    public class GetUploadedFileHandler : IRequestHandler<GetUploadedFileRequest, (bool succeed, string message, GetUploadedFileResponse[] file)>
    {
        private readonly IApplicationDbContext applicationDbContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetUploadedFileHandler"/> class.
        /// </summary>
        /// <param name="applicationDbContext">The application database context.</param>
        public GetUploadedFileHandler(IApplicationDbContext applicationDbContext)
        {
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
        public async Task<(bool succeed, string message, GetUploadedFileResponse[] file)> Handle(GetUploadedFileRequest request, CancellationToken cancellationToken)
        {
            var file = await applicationDbContext.FileUploads.Select(x =>
            new GetUploadedFileResponse
            {
                Id = x.Id,
                EntityId = x.EntityId,
                EntityType = x.EntityType,
                File = x.File,
                MimeType = x.MimeType,
                Name = x.Name,
                Ext = x.Ext,
                Size = x.Size
            })
             .Where(x => x.EntityId.Equals(request.EntityId) && x.EntityType == request.EntityType)
             .ToArrayAsync();
            if (file != null) return (true, "File was found", file);

            return (false, "The uploaded files cannot be found", null);
        }
    }
}