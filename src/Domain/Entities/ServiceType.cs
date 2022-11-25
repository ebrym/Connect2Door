using Domain.Common;
using System;

namespace Domain.Entities
{
    /// <summary>
    ///
    /// </summary>
    public class ServiceType : BaseEntity
    {
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

        public DateTime DateModified { get; set; }
        public string ModifiedBy { get; set; }
    }
}