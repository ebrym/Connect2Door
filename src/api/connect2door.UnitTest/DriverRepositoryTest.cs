using Microsoft.EntityFrameworkCore;
using connect2door.Data;
using connect2door.Data.Entity;
using connect2door.Repository.Repository;

namespace connect2door.UnitTest
{
    public class DriverRepositoryTest
    {
        private readonly DataContext context;

        public DriverRepositoryTest()
        {
            DbContextOptionsBuilder dbOptions = new DbContextOptionsBuilder()
                .UseInMemoryDatabase(
                    Guid.NewGuid().ToString() // Use GUID so every test will use a different db
                );

            context = new DataContext(dbOptions.Options);
        }

        [Fact]
        public async Task Add_Driver()
        {
            // Arrange
            var sut = new Repository<Driver>(context);
            var driver =  new Driver
            {
                FirstName = "Ade",
                LastName = "Dele",
                VehiclePlate = "pls123ok",
            };
            // Act
            var result =  await sut.Insert(driver);

            // Assert
            List<Driver> drivers = context.Drivers.ToList();
            Assert.Equal(result.FirstName, driver.FirstName);
            Assert.Single(drivers);
        }

        [Fact]
        public async Task Get_Single_Driver()
        {
            // Arrange
            var sut = new Repository<Driver>(context);
            var driver = new Driver
            {
                FirstName = "Ola",
                LastName = "Dele",
                VehiclePlate = "pls123ok",
            };
            // Act
            var result = await sut.Insert(driver);

            // Act
            var singleDriver = await sut.Get(result.Id);

            // Assert
            Assert.NotNull(singleDriver);
            Assert.Equal(result.FirstName, driver.FirstName);
        }

        [Fact]
        public async Task Get_All_Drivers()
        {
            var users = new List<Driver>() {
                new() { FirstName = "Ola1", LastName = "Dele1",VehiclePlate = "pls123ok1",},
                new() {FirstName = "Ola2", LastName = "Dele2",VehiclePlate = "pls123ok2",},
                new() {FirstName = "Ola3", LastName = "Dele3",VehiclePlate = "pls123ok3",},
            };

            context.Drivers.AddRange(users);
            await context.SaveChangesAsync();

            var sut = new Repository<Driver>(context);

            var result = await sut.GetAll();

            Assert.Equal(users.Count, result.Count());
        }
    }
}