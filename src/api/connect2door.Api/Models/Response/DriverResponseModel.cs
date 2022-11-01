using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using connect2door.Api.Models.Request;

namespace connect2door.Api.Models.Response
{
    public class DriverResponseModel : DriverRequestModel
    {
     
       
        /// <summary>
        /// Gets or sets active.
        /// </summary>
        /// <value>
        /// The active.
        /// </value>
        /// 
        [JsonPropertyName("active")]
        public bool Active { get; set; }
        /// <summary>
        /// Gets or sets the created at.
        /// </summary>
        /// <value>
        /// The created at.
        /// </value>
        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }
        /// <summary>
        /// Gets or sets the updated at.
        /// </summary>
        /// <value>
        /// The updated at.
        /// </value>
        [JsonPropertyName("updated_at")]
        public DateTime? UpdatedAt { get; set; }

    }
}

