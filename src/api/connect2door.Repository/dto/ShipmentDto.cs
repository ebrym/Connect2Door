using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using connect2door.Repository.dto;
using connect2door.Data.Common;

namespace connect2door.Repository.Dto
{
    public class ShipmentDto : BaseDto
    {

        /// <summary>
        /// Gets or sets the origin.
        /// </summary>
        /// <value>
        /// The origin.
        /// </value>
        public string? Origin { get; set; }
        /// <summary>
        /// Gets or sets the Destination.
        /// </summary>
        /// <value>
        /// The Destination.
        /// </value>
        public string? Destination { get; set; }
        /// <summary>
        /// Gets or sets the barcode.
        /// </summary>
        /// <value>
        /// The barcode.
        /// </value>
        public string? Barcode { get; set; }
        /// <summary>
        /// Gets or sets the Shipment Status.
        /// </summary>
        /// <value>
        /// The Shipment Status.
        /// </value>
        public ShipmentStatus Status { get; set; }
        /// <summary>
        /// Gets or sets the fShipment Date.
        /// </summary>
        /// <value>
        /// The Shipment Date.
        /// </value>
        public DateTimeOffset? ShipmentDate { get; set; }

        /// <summary>
        /// Gets or sets the Driver Identifier.
        /// </summary>
        /// <value>
        /// The Driver Identifier.
        /// </value>
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
        public DateTimeOffset? PlannedDate { get; set; }
        /// <summary>
        /// Gets or sets the Effective Date.
        /// </summary>
        /// <value>
        /// The Effective Date.
        /// </value>
        public DateTimeOffset? EffectiveDate { get; set; }
        /// <summary>
        /// Gets or sets the Comments.
        /// </summary>
        /// <value>
        /// The Comments.
        /// </value>
        public string? Comments { get; set; }
    }
}

