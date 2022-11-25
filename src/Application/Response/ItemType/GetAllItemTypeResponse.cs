using Application.Interfaces;
using System;

namespace Application.Response.ItemType
{
    /// <summary>
    ///
    /// </summary>
    public class GetAllItemTypeResponse : IMapFrom<Domain.Entities.ItemType>
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
        public string ItemTypeName { get; set; }

        /// <summary>
        /// Gets or sets the Status.
        /// </summary>
        /// <value>
        /// The Status
        /// </value>
        public bool Status { get; set; }

        public DateTimeOffset DateCreated { get; set; }
    }
}