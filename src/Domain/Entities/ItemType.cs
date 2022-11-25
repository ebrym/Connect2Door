using Domain.Common;
using System;

namespace Domain.Entities
{
    /// <summary>
    /// Item Type Table
    /// </summary>
    public class ItemType : BaseEntity
    {
        /// <summary>
        /// ItemType
        /// </summary>
        /// <value>
        /// The Item Type Name
        /// </value>
        public string ItemTypeName { get; set; }

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