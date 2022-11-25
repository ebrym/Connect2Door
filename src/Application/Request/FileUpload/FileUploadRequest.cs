using Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Request.FileUpload
{
    /// <summary>
    ///
    /// </summary>
    /// <seealso >
    /// <cref>
    /// MediatR.IRequest{(System.Boolean succeed, System.String message)}
    /// </cref>
    /// </seealso>
    public class FileUploadRequest : IRequest<(bool succeed, string message)>
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the type of the entity.
        /// </summary>
        /// <value>
        /// The type of the entity.
        /// </value>
        public EntityType EntityType { get; set; }

        /// <summary>
        /// Gets or sets the entity identifier.
        /// </summary>
        /// <value>
        /// The entity identifier.
        /// </value>
        public string EntityId { get; set; }

        /// <summary>
        /// Gets or sets the form file.
        /// </summary>
        /// <value>
        /// The form file.
        /// </value>
        public IFormFile FormFile { get; set; }
    }
}