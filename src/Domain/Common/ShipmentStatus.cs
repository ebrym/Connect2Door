using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace connect2door.Data.Common
{
    /// <summary>
    /// Shipment Status
    /// </summary>
    public enum ShipmentStatus
    {
        /// <summary>
        /// Initial
        /// </summary>
        Init,

        /// <summary>
        /// Pickup
        /// </summary>
        PickUp,

        /// <summary>
        /// Delivered
        /// </summary>
        Delivered,

            /// <summary>
            /// Returned
            /// </summary>
        Returned

    }
}
