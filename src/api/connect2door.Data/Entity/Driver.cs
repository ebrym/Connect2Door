using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace connect2door.Data.Entity;

    public class Driver : BaseEntity.Entity
    {
            public string? FirstName  { get; set; }
            public string? LastName { get; set; }
            public string? VehiclePlate { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime ExpirationDate { get; set; }
            public bool Active { get; set; } = true;
    }

