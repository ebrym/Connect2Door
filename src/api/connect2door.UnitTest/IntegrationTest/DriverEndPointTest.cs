using Newtonsoft.Json;
using connect2door.Data.Entity;
using connect2door.Repository.Dto;
using connect2door.Repository.Interface;
using connect2door.UnitTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace connect2door.UnitTest.IntegrationTest
{
    [Collection("Integration Tests")]
    public class DriverEndPointTest
    {
 
        [Fact]
        public async Task Add_Driver_All_ListAsync()
        {

            await using var application = new ApplicationTestPlayGround();
            var VehiclePlate = "APP234HT";
            var expectedFirstName = "ADEBAYO";
            var expectedLastName = "ADEMOLA";
            var driver = new DriverDto()
            {
                FirstName = expectedFirstName,
                LastName = expectedFirstName,
                VehiclePlate = VehiclePlate
            };


            //var jsonString = "{\"test\":123}";
            using var jsonContent = new StringContent(JsonConvert.SerializeObject(driver));
            jsonContent.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");

            //ACT
            using var client = application.CreateClient();
            using var response = await client.PostAsync("/Driver", jsonContent);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            //var getQueryResponseString = await response.Content.ReadAsStringAsync();


            //var genericResponse = JsonConvert.DeserializeObject<ResponseModel<DriverDto>>(getQueryResponseString);

            //var driverResponse = genericResponse.data;

            ////ASSERT
            //Assert.Equal(VehiclePlate, driverResponse.VehiclePlate);
            //Assert.Equal(expectedFirstName, driverResponse.FirstName);
            //Assert.Equal(expectedLastName, driverResponse.LastName);


        }
    }
}
