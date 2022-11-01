using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using connect2door.Data.Entity;
using connect2door.Repository.Dto;
using connect2door.Repository.Interface;
using connect2door.Web.Models;
using static connect2door.Web.Enums.Enums;

namespace connect2door.Web.Controllers
{
    public class DriverController :  BaseController
    {
        private readonly IDriverService _driverService;
        private readonly IMapper _mapper;

        public DriverController(IDriverService driverService, IMapper mapper)
        {
            _driverService = driverService;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var driver = await _driverService.GetDrivers();

            var category = _mapper.Map<List<DriverViewModel>>(driver);

            return View(category);
        }

    



        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(DriverModel driver)
        {
            if (ModelState.IsValid)
            {

                var mappedDriver = _mapper.Map<DriverDto>(driver);

                var result = await _driverService.InsertDriver(mappedDriver);

                if (result.Succeed)
                {
                    Alert("Driver created successfully.", NotificationType.success);
                    return RedirectToAction("Index");
                }
                else
                {
                    Alert("SomeProblems were encountered while trying to perform operation. <br> Please try again.", NotificationType.error);
                }


            }

            return View(driver);
        }
        public async Task<IActionResult> Edit(string? Id)
        {
            try
            {
                var driver = await _driverService.GetDriver(Id);

                var mapDriver = _mapper.Map<DriverModel>(driver.Item3);
                if(mapDriver == null)
                {
                   Alert("Invalid Driver selected.", NotificationType.error);
                   return RedirectToAction("Index");
                }
                return View(mapDriver);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        [HttpPost]
        public async Task<IActionResult> Edit(DriverModel driver)
        {

            if (ModelState.IsValid)
            {
                var getDriver = await _driverService.GetDriver(driver.Id);

                if (getDriver.Item3 == null)
                    return View(driver);

                var mapDriver = _mapper.Map<DriverDto>(driver);

                var result = await _driverService.UpdateDriver(mapDriver);

              
                if (result.Succeed)
                {
                    Alert("Driver updated successfully.", NotificationType.success);
                    return RedirectToAction("Index");
                }
                else
                {
                    Alert("SomeProblems were encountered while trying to perform operation. Please try again.", NotificationType.error);
                }
            }
            return View(driver);
        }

        public async Task<IActionResult> Delete(string? Id)
        {
          
                var result = await _driverService.DeleteDriver(Id);

            if (result.Succeed)
            {
                Alert("Driver deleted successfully.", NotificationType.success);
                return RedirectToAction("Index");
            }
            else
            {
                Alert("SomeProblems were encountered while trying to perform operation.  Please try again.", NotificationType.error);
            }

            return View("Index");
        }


      
        


    }
}