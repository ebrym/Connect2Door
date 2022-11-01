using connect2door.Data.Entity;
using connect2door.Repository.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace connect2door.Repository.Interface
{
    public interface IDriverService: IDependencyRegister
    {
        Task<IEnumerable<DriverDto>> GetDrivers();
        Task<(bool Succeed, string Message, DriverDto)> GetDriver(string? id);
        Task<(bool Succeed, string Message, DriverDto)> InsertDriver(DriverDto driver);
        Task<(bool Succeed, string Message, DriverDto)> UpdateDriver(DriverDto driver);
        Task<(bool Succeed, string Message)> DeleteDriver(string? id);
    }
}
