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
    /// <seealso cref="MediatR.IRequestHandler{GetFileUploadedByIdRequest,GetUploadedFileResponse}" />
    public class GetUploadedFileByIdHandler : IRequestHandler<GetFileUploadedByIdRequest, GetUploadedFileResponse>
    {
        private readonly IApplicationDbContext applicationDbContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetUploadedFileByIdHandler"/> class.
        /// </summary>
        /// <param name="applicationDbContext">The application database context.</param>
        public GetUploadedFileByIdHandler(IApplicationDbContext applicationDbContext)
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
        public async Task<GetUploadedFileResponse> Handle(GetFileUploadedByIdRequest request, CancellationToken cancellationToken)
        {
            var file = await applicationDbContext.FileUploads.Where(x => x.Id == request.Id)
                .Select(x => new GetUploadedFileResponse
                {
                    EntityId = x.EntityId,
                    File = x.File,
                    MimeType = x.MimeType
                }).FirstOrDefaultAsync(cancellationToken: cancellationToken);

            return file;
        }
    }
}