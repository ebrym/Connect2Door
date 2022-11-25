using Application.Interfaces;
using Application.Request.ServiceType;

namespace Application.Response.ServiceType
{
    public class UpdateServiceTypeResponse : IMapFrom<UpdateServiceTypeRequest>
    {
        /// <summary>
        /// vendor id
        /// </summary>
        public string Id { get; set; }
    }
}