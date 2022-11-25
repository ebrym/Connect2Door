using Application.Response.FileUpload;
using Domain.Common;
using MediatR;

namespace Application.Request.FileUpload
{
    /// <summary>
    ///
    /// </summary>
    /// <seealso cref="IRequest{(bool succeed, string message, GetUploadedFileResponse[] file)}" />
    public class GetUploadedFileRequest : IRequest<(bool succeed, string message, GetUploadedFileResponse[] file)>
    {
        /// <summary>
        /// Gets or sets the entity identifier.
        /// </summary>
        /// <value>
        /// The entity identifier.
        /// </value>
        public string EntityId { get; set; }

        /// <summary>
        /// Gets or sets the type of the entity.
        /// </summary>
        /// <value>
        /// The type of the entity.
        /// </value>
        public EntityType EntityType { get; set; }
    }
}