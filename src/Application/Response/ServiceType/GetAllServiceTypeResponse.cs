using Application.Interfaces;
using System;

namespace Application.Response.ServiceType
{
    /// <summary>
    ///
    /// </summary>
    public class GetAllServiceTypeResponse : IMapFrom<Domain.Entities.ServiceType>
    {
        /// <summary>
        ///
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the service type.
        /// </summary>
        /// <value>
        /// The service Type
        /// </value>
        public string ServiceTypeName { get; set; }

        public DateTimeOffset DateCreated { get; set; }

        /// <summary>
        /// Gets or sets the Status.
        /// </summary>
        /// <value>
        /// The Status
        /// </value>
        public bool Status { get; set; }
    }
}