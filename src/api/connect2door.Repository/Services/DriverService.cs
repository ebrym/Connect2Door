using AutoMapper;
using connect2door.Data.Entity;
using connect2door.Repository.Dto;
using connect2door.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace connect2door.Repository.Services
{
    public class DriverService : IDriverService
    {
        private IRepository<Driver> driverRepository; 
        private readonly IMapper mapper;

        public DriverService(IRepository<Driver> driverRepository,
                                     IMapper mapper)
        {
            this.driverRepository = driverRepository;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<DriverDto>> GetDrivers()
        {
            var result = await driverRepository.GetAll();
            var drivers = mapper.Map<List<DriverDto>>(result);
            return  drivers;
        }

        public async Task<(bool Succeed, string Message,DriverDto)> GetDriver(string id)
        {
            var result = await driverRepository.Get(id);
            if (result == null) return (false, "Driver Not found", null);
            var driver = mapper.Map<DriverDto>(result);
            return (true, "Success", driver);
        }

        public async Task<(bool Succeed, string Message, DriverDto)> InsertDriver(DriverDto driverdto)
        {
            driverdto.Id = Guid.NewGuid().ToString();
            var driver = mapper.Map<Driver>(driverdto);

           var result =  await driverRepository.Insert(driver);

            if (result == null) return (false, "Could not add Driver", null);
            return (true,"Driver Added",mapper.Map<DriverDto>(result));
        }

        public async Task<(bool Succeed, string Message, DriverDto)> UpdateDriver(DriverDto driverUpdate)
        {
            //

            var driver = await driverRepository.Get(driverUpdate.Id);

            if (driver == null) return (false, "Driver not found", null);

            driver.FirstName = driverUpdate.FirstName;
            driver.LastName = driverUpdate.LastName;
            driver.StartDate = driverUpdate.StartDate;
            driver.ExpirationDate = driverUpdate.ExpirationDate;
            driver.VehiclePlate = driverUpdate.VehiclePlate;
            driver.Active=driverUpdate.Active;
            var result = await driverRepository.Update(driver);

            if (result == null) return (false, "Driver not updated", null);
            var driverMap = mapper.Map<DriverDto>(driver);

            return (true,"Driver Updated", driverMap);
        }

        public async Task<(bool Succeed, string Message)> DeleteDriver(string id)
        {
            var driver = await driverRepository.Get(id);
            if (driver == null) return (false, "Driver does not exist!");

            driverRepository.Delete(driver);
            return (true, "success");
        }
    }
}
