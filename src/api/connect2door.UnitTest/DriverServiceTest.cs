using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using Xunit;
using connect2door.Repository.Interface;
using Moq;
using connect2door.Data.Entity;
using connect2door.Data;
using Microsoft.EntityFrameworkCore;
using connect2door.UnitTest.Models;
using connect2door.Repository.Repository;
using connect2door.Repository.Dto;
using AutoMapper;

namespace connect2door.UnitTest
{
    
    [Collection("Test collection")]
    public class DriverServiceTest
    {

     



        [Fact]
        public async Task Create_Driver_Calls_DriverService_Insert()
        {
            var testObject = new DriverDto
            {
                FirstName = "Ade",
                LastName = "Dele",
                VehiclePlate = "pls123ok",
            };

            var mockDriverService = new Mock<IDriverService>();
            mockDriverService.Setup(x => x.InsertDriver(testObject));
           var dr =  await mockDriverService.Object.InsertDriver(testObject);
            mockDriverService.Verify(x => x.InsertDriver(testObject), Times.Once());


           // Assert.Equal(testObject.FirstName, dr.Item3.FirstName?.ToString());
           // Assert.NotNull( dr.Item3.Id);
        }

        [Fact]
        public void DriverRepository_Given_Driver_Id_Should_Get_Driver_Details()
        {
            //Arrange
          
            var driver = new Driver() { FirstName = "Addedd", 
                                        LastName = "OLA",
                                        VehiclePlate = "2313123"};

            var driverRepositoryMock = new Mock<IRepository<Driver>>();

            driverRepositoryMock.Setup(m => m.Insert(driver)).ReturnsAsync(driver).Verifiable();



            driverRepositoryMock.Setup(m => m.Get(driver.Id)).ReturnsAsync(driver);
            // driverRepositoryMock.Setup(m => m.Get(driverId)).Returns(Driver).Verifiable();

            // productRepositoryMock.Setup(m => m.GetByID(productId)).Returns(product).Verifiable();

            //var unitOfWorkMock = new Mock<IDriverService>();
            //unitOfWorkMock.Setup(m => m.GetDriver(driver.Id).Result.Item3.Id).ReturnsAsync(driver.Id);

            //IProductService sut = new ProductService(unitOfWorkMock.Object);
            ////Act
            //var actual = sut.GetProductName(productId);

            //Assert
            ///driverRepositoryMock.Verify();//verify that GetByID was called based on setup.
            //Assert.NotNull(driver.FirstName);//assert that a result was returned
            //Assert.Equal(driver.FirstName, driverRepositoryMock.Object.Firstname);//assert that actual result was as expected
        }

        [Fact]
        public void DriverService_Given_Driver_Id_Should_Get_Driver_Name()
        {
            //Arrange
          


            var VehiclePlate = "APP234HT";
            var expectedFirstName = "ADEBAYO";
            var expectedLastName = "ADEMOLA";
            var driver = new Driver()
            {
                FirstName = expectedFirstName,
                LastName = expectedLastName,
                VehiclePlate = VehiclePlate
            };


            //Repository<Driver>(context)

            var outDriver = new Driver();

            var driverRepositoryMock = new Mock<IRepository<Driver>>();
            driverRepositoryMock.Setup(m => m.Insert(driver)).ReturnsAsync(driver).Verifiable();

            driverRepositoryMock.Setup(m => m.Get(driver.Id)).ReturnsAsync(outDriver).Verifiable();


            var driverDto = new DriverDto();
            var unitOfWorkMock = new Mock<IDriverService>();
            var output = (true, "", driverDto);
            //Act
            unitOfWorkMock.Setup(m => m.GetDriver(driver.Id)).ReturnsAsync(output).Verifiable();
            unitOfWorkMock.Object.Equals(driverDto);
            //Assert
            Assert.Equal(VehiclePlate, driver.VehiclePlate);//assert that actual result was as expected
            //Assert.Equal(VehiclePlate, output.driverDto.Id);//assert that actual result was as expected
            Assert.Equal(expectedLastName, driver.LastName);//assert that actual result was as expected
            //Assert.Equal(driver.FirstName, output.driverDto.FirstName);//assert that actual result was as expected
        }

    }
}
