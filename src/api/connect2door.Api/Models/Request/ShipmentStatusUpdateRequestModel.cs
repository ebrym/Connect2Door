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
    public class ShipmentStatusUpdateRequestModel 
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [Required]
        public string? Id => null;

        /// <summary>
        /// Gets or sets the Shipment Status.
        /// </summary>
        /// <value>
        /// The Shipment Status.
        /// </value>
        [Required]
        [JsonPropertyName("status")]
        public ShipmentStatus Status => ShipmentStatus.Init;
    }
}

