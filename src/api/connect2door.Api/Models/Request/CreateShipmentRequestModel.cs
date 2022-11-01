using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using connect2door.Api.Models.Response;
using connect2door.Data.Common;

namespace connect2door.Api.Models.Request
{
    public class CreateShipmentRequestModel 
    {
      
        /// <summary>
        /// Gets or sets the origin.
        /// </summary>
        /// <value>
        /// The origin.
        /// </value>
        [Required]
        [JsonPropertyName("origin")]
        public string? Origin { get; set; }
        /// <summary>
        /// Gets or sets the Destination.
        /// </summary>
        /// <value>
        /// The Destination.
        /// </value>
        [Required]
        [JsonPropertyName("destination")]
        public string? Destination { get; set; }
        /// <summary>
        /// Gets or sets the barcode.
        /// </summary>
        /// <value>
        /// The barcode.
        /// </value>

        [Required]
        [JsonPropertyName("associated_barcode")]
        public string? Barcode { get; set; }
        /// <summary>
        /// Gets or sets the Shipment Status.
        /// </summary>
        /// <value>
        /// The Shipment Status.
        /// </value>
        [Required]
        [JsonPropertyName("status")]
        public ShipmentStatus Status { get; set; }
        /// <summary>
        /// Gets or sets the fShipment Date.
        /// </summary>
        /// <value>
        /// The Shipment Date.
        /// </value>

        [Required]        
        [JsonPropertyName("shipment_date")] 
        public DateTimeOffset? ShipmentDate { get; set; }
        /// <summary>
        /// Gets or sets the Driver Identifier.
        /// </summary>
        /// <value>
        /// The Driver Identifier.
        /// </value>
        /// 

        [Required]
        [JsonPropertyName("driver_id")]
        public string? DriverId { get; set; }
        /// <summary>
        /// Gets or sets the Planned Date.
        /// </summary>
        /// <value>
        /// The Planned Date.
        /// </value>
        /// 

        [Required]
        [JsonPropertyName("planned_date")]
        public DateTimeOffset? PlannedDate { get; set; }
        /// <summary>
        /// Gets or sets the Effective Date.
        /// </summary>
        /// <value>
        /// The Effective Date.
        /// </value>
        /// 

        [Required]
        [JsonPropertyName("effective_date")]
        public DateTimeOffset? EffectiveDate { get; set; }
        /// <summary>
        /// Gets or sets the Comments.
        /// </summary>
        /// <value>
        /// The Comments.
        /// </value>
        /// 

        [Required]
        [JsonPropertyName("comments")]
        public string? Comments { get; set; }

    }
}

