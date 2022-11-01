using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using connect2door.Api.Models.Request;
using connect2door.Data.Common;

namespace connect2door.Api.Models.Response
{
    public class ShipmentResponseModel : ShipmentRequestModel
    {


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
        /// Gets or sets the created at.
        /// </summary>
        /// <value>
        /// The created at.
        /// </value>
        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Gets or sets the created by.
        /// </summary>
        /// <value>
        /// The created by.
        /// </value>
        [JsonPropertyName("created_by")]
        public string? CreatedBy { get; set; }
        /// <summary>
        /// Gets or sets the updated at.
        /// </summary>
        /// <value>
        /// The updated at.
        /// </value>
        [JsonPropertyName("updated_at")]
        public DateTime? UpdatedAt { get; set; }
        /// <summary>
        /// Gets or sets the updated by.
        /// </summary>
        /// <value>
        /// The updated by.
        /// </value>
        [JsonPropertyName("updated_by")]
        public DateTime? UpdatedBy { get; set; }

    }
}

