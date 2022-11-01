using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using connect2door.Api.Models.Response;

namespace connect2door.Api.Models.Request
{
    public class CreateDriverRequestModel 
    {
      
        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>
        /// The first name.
        /// </value>
        [Required]
        [JsonPropertyName("first_name")]
        public string? FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>
        /// The last name.
        /// </value>
        [Required]
        [JsonPropertyName("last_name")]
        public string? LastName { get; set; }
        /// <summary>
        /// Gets or sets the vehicle plate.
        /// </summary>
        /// <value>
        /// The vehicle plate.
        /// </value>
        [Required]
        [JsonPropertyName("vehicle_plate")]
        public string? VehiclePlate { get; set; }
        /// <summary>
        /// Gets or sets the start date.
        /// </summary>
        /// <value>
        /// The start date.
        /// </value>
        [Required]
        [JsonPropertyName("start_date")]
        public DateTime StartDate { get; set; }
        /// <summary>
        /// Gets or sets the expiration date.
        /// </summary>
        /// <value>
        /// The expiration date.
        /// </value>
        [Required]
        [JsonPropertyName("expiration_date")]
        public DateTime ExpirationDate { get; set; }

    }
}

