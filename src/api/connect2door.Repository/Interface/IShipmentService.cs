using connect2door.Data.Common;
using connect2door.Data.Entity;
using connect2door.Repository.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace connect2door.Repository.Interface
{
    public interface IShipmentService : IDependencyRegister
    {
        Task<IEnumerable<ShipmentDto>> GetShipments();
        Task<IEnumerable<ShipmentDto>> GetShipments(string include);
        Task<(bool Succeed, string Message, ShipmentDto)> GetShipment(string? id);
        Task<(bool Succeed, string Message, ShipmentDto)> InsertShipment(ShipmentDto Shipment);
        Task<(bool Succeed, string Message, ShipmentDto)> UpdateShipment(ShipmentDto Shipment);
        Task<(bool Succeed, string Message)> DeleteShipment(string? id);
        Task<(bool Succeed, string Message, ShipmentDto)> UpdateShipmentStatus(ShipmentStatus Status, string? id);
    }
}
