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
    public class ShipmentController :  BaseController
    {
        private readonly IDriverService _driverService;
        private readonly IShipmentService _shipmentService;
        private readonly IMapper _mapper;

        public ShipmentController(IShipmentService shipmentService,IDriverService driverService, IMapper mapper)
        {
            _driverService = driverService;
            _shipmentService = shipmentService;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var shipment = await _shipmentService.GetShipments("Driver");

            var shipments = _mapper.Map<List<ShipmentViewModel>>(shipment);

            return View(shipments);
        }

    



        public async Task<IActionResult> Create()
        {
            var driverList = await _driverService.GetDrivers();
            var drivers = driverList.Select(a => new SelectListItem()
            {
                Value = a.Id.ToString(),
                Text = a.FirstName + " " + a.LastName + " (" + a.VehiclePlate + ")"
            }).ToList();

            ViewBag.driver = drivers;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ShipmentModel shipment)
        {
            if (ModelState.IsValid)
            {

                var mappedShipment = _mapper.Map<ShipmentDto>(shipment);

                var result = await _shipmentService.InsertShipment(mappedShipment);

                if (result.Succeed)
                {
                    Alert("Shipment created successfully.", NotificationType.success);
                    return RedirectToAction("Index");
                }
                else
                {
                    Alert(result.Message, NotificationType.error);
                }


            }

            return View(shipment);
        }
        public async Task<IActionResult> Edit(string? Id)
        {
            try
            {
                var driverList = await _driverService.GetDrivers();
                var drivers = driverList.Select(a => new SelectListItem()
                {
                    Value = a.Id.ToString(),
                    Text = a.FirstName + " " + a.LastName + " (" + a.VehiclePlate + ")"
                }).ToList();

                ViewBag.driver = drivers;

                var shipment = await _shipmentService.GetShipment(Id);
                var mapDriver = _mapper.Map<ShipmentModel>(shipment.Item3);
                if(mapDriver == null)
                {
                   Alert("Invalid Shipment selected.", NotificationType.error);
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
        public async Task<IActionResult> Edit(ShipmentModel shipment)
        {

            if (ModelState.IsValid)
            {
                //var shipment = await _shipmentService.GetShipment(Id);

                //if (shipment.Item3 == null)
                //    return View(driver);

                var mapShipment = _mapper.Map<ShipmentDto>(shipment);

                var result = await _shipmentService.UpdateShipment(mapShipment);

              
                if (result.Succeed)
                {
                    Alert("Shipment updated successfully.", NotificationType.success);
                    return RedirectToAction("Index");
                }
                else
                {
                    Alert(result.Message, NotificationType.error);
                }
            }
            return View(shipment);
        }

        public async Task<IActionResult> Delete(string? Id)
        {
          
                var result = await _shipmentService.DeleteShipment(Id);

            if (result.Succeed)
            {
                Alert("Shipment deleted successfully.", NotificationType.success);
                return RedirectToAction("Index");
            }
            else
            {
                Alert(result.Message, NotificationType.error);
            }

            return View("Index");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateStatus(ShipmentViewModel shipment)
        {
            var result = await _shipmentService.UpdateShipmentStatus(shipment.Status, shipment.Id);


                if (result.Succeed)
                {
                    Alert("Shipment status updated successfully.", NotificationType.success);
                    
                }
                else
                {
                    Alert(result.Message, NotificationType.error);
                }

            return RedirectToAction("Index");
        }

        public async Task<ActionResult> UpdateShipmentStatus(string? id)
        {
            var shipment = await _shipmentService.GetShipment(id);
            var mapDriver = _mapper.Map<ShipmentViewModel>(shipment.Item3);
            return PartialView("~/Views/Shared/_UpdateShipmentPartial.cshtml", mapDriver);
        }

       

    }
}