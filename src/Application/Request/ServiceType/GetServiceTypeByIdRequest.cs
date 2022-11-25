using Application.Response.ServiceType;
using MediatR;

namespace Application.Request.ServiceType
{
    /// <summary>
    ///
    /// </summary>
    public class GetServiceTypeByIdRequest : IRequest<GetServiceTypeByIdResponse>
    {
        /// <summary>
        /// Id
        /// </summary>
        public string Id { get; set; }
    }
}