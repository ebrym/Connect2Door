using Application.Response.FileUpload;
using MediatR;

namespace Application.Request.FileUpload
{
    /// <summary>
    ///
    /// </summary>
    /// <seealso cref="MediatR.IRequest{GetUploadedFileResponse}" />
    public class GetFileUploadedByIdRequest : IRequest<GetUploadedFileResponse>
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public string Id { get; set; }
    }
}