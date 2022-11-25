using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace connect2door.Web.Models
{
    public class ShipmentModel
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public string? Id { get; set; }
        /// <summary>
        /// Gets or sets the origin.
        /// </summary>
        /// <value>
        /// The origin.
        /// </value>
        [Required]
        public string? Origin { get; set; }
        /// <summary>
        /// Gets or sets the Destination.
        /// </summary>
        /// <value>
        /// The Destination.
        /// </value>
        [Required]
        public string? Destination { get; set; }
        /// <summary>
        /// Gets or sets the barcode.
        /// </summary>
        /// <value>
        /// The barcode.
        /// </value>

        [Required]
        public string? Barcode { get; set; }
        /// <summary>
        /// Gets or sets the fShipment Date.
        /// </summary>
        /// <value>
        /// The Shipment Date.
        /// </value>

        [Required]
        public DateTimeOffset? ShipmentDate { get; set; }
        /// <summary>
        /// Gets or sets the Driver Identifier.
        /// </summary>
        /// <value>
        /// The Driver Identifier.
        /// </value>
        /// 

        [Required]
        public string? DriverId { get; set; }
        /// <summary>
        /// Gets or sets the Driver.
        /// </summary>
        /// <value>
        /// The Driver.
        /// </value>
        public string? Driver { get; set; }
        /// <summary>
        /// Gets or sets the Planned Date.
        /// </summary>
        /// <value>
        /// The Planned Date.
        /// </value>
        /// 

        [Required]
        public DateTimeOffset? PlannedDate { get; set; }
        /// <summary>
        /// Gets or sets the Effective Date.
        /// </summary>
        /// <value>
        /// The Effective Date.
        /// </value>
        /// 

        [Required]
        public DateTimeOffset? EffectiveDate { get; set; }
        /// <summary>
        /// Gets or sets the Comments.
        /// </summary>
        /// <value>
        /// The Comments.
        /// </value>
        /// 

        [Required]
        public string? Comments { get; set; }
    }

   
}
