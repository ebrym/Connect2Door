using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using connect2door.Repository.Interface;
using static connect2door.Web.Enums.Enums;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace connect2door.Web.Controllers
{
    public class HomeController : BaseController
    {

        private readonly IDriverService _driverService;
        private readonly IShipmentService _shipmentService;
        public HomeController(IDriverService driverService,
                                     IShipmentService shipmentService)
        {
            _driverService = driverService;
            _shipmentService = shipmentService;
        }
        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            try
            {
                var driver =await _driverService.GetDrivers();
                var shipment = await _shipmentService.GetShipments();


                ViewBag.TotalDriver = driver.Count();
                ViewBag.TotalShipment = shipment.Count();

            }
            catch(Exception)
            {

            }
            Alert("Welcome to Ship Manager.", NotificationType.info);

            return View();
        }
    }
}
