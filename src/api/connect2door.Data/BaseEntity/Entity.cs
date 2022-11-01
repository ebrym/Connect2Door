using System;

namespace connect2door.Data.BaseEntity;

    /// <summary>
    /// Base class for all entity
    /// </summary>
    public class Entity
    {
    public string? Id { get; set; } = Guid.NewGuid().ToString();
    public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string? CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string? UpdatedBy { get; set; }

    }

