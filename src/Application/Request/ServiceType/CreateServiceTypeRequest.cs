using Application.Interfaces;
using Application.Response.ServiceType;
using MediatR;

namespace Application.Request.ServiceType
{
    /// <summary>
    ///
    /// </summary>
    public class CreateServiceTypeRequest : IRequest<(bool Succeed, string Message, CreateServiceTypeResponse Response)>, IMapFrom<Domain.Entities.ServiceType>
    {
        /// <summary>
        /// Gets or sets the service type.
        /// </summary>
        /// <value>
        /// The service Type
        /// </value>
        public string ServiceTypeName { get; set; }

        ///// <summary>
        ///// Gets or sets the Status.
        ///// </summary>
        ///// <value>
        ///// The Status
        ///// </value>
        ////public bool Status { get; set; }
    }
}