using connect2door.Data.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace connect2door.Data.Entity
{
   public class Shipment : BaseEntity.Entity
	{
        public string? Origin { get; set; }
		public string? Destination { get; set; }
		public ShipmentStatus Status { get; set; }
		public DateTimeOffset? ShipmentDate { get; set; }
		public string? DriverId { get; set; }
		public string? Barcode { get; set; }
		public virtual Driver? Driver { get; set; }
		public DateTimeOffset? PlannedDate { get; set; }
		public DateTimeOffset? EffectiveDate { get; set; }
		public string? Comments { get; set; }
	}
}
