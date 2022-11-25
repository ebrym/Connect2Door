using Application.Interfaces;
using Application.Request.ServiceType;

namespace Application.Response.ServiceType
{
    /// <summary>
    ///
    /// </summary>
    public class CreateServiceTypeResponse : IMapFrom<CreateServiceTypeRequest>
    {
        // <summary>
        ///
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string ServiceTypeName { get; set; }
    }
}