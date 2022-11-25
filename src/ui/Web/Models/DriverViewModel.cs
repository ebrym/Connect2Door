using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace connect2door.Web.Models
{
    public class DriverViewModel :DriverModel
    {
        /// <summary>
        /// Gets or sets active.
        /// </summary>
        /// <value>
        /// The active.
        /// </value>
        /// 
        public bool Active { get; set; }
        /// <summary>
        /// Gets or sets the created at.
        /// </summary>
        /// <value>
        /// The created at.
        /// </value>
        public DateTime CreatedAt { get; set; }
        /// <summary>
        /// Gets or sets the updated at.
        /// </summary>
        /// <value>
        /// The updated at.
        /// </value>
        public DateTime? UpdatedAt { get; set; }
    }

   
}
