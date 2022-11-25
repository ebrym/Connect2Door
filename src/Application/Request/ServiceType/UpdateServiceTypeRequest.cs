using Application.Interfaces;
using Application.Response.ServiceType;
using MediatR;

namespace Application.Request.ServiceType
{
    /// <summary>
    ///
    /// </summary>
    public class UpdateServiceTypeRequest : IRequest<(bool Succeed, string Message, UpdateServiceTypeResponse Response)>, IMapFrom<Domain.Entities.ServiceType>
    {
        /// Gets or sets the Id.
        /// </summary>
        /// <value>
        /// The Id
        /// </value>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the service type.
        /// </summary>
        /// <value>
        /// The service Type
        /// </value>
        public string ServiceTypeName { get; set; }

        /// <summary>
        /// Gets or sets the Status.
        /// </summary>
        /// <value>
        /// The Status
        /// </value>
        public bool Status { get; set; }
    }
}