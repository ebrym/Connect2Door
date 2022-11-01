using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using connect2door.Api.Models;
using connect2door.Api.Models.Request;
using connect2door.Api.Models.Response;
using connect2door.Repository.Dto;
using connect2door.Repository.Interface;

namespace connect2door.Api.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class ShipmentController : BaseController
    {
      

        private readonly ILogger<ShipmentController> _logger;
        private readonly IShipmentService _shipmentService;
        private readonly IMapper _mapper;

        public ShipmentController(ILogger<ShipmentController> logger, IShipmentService shipmentService,
        IMapper mapper)
        {
            _logger = logger;
            _shipmentService = shipmentService;
            _mapper = mapper;
        }


        #region Query
        /// <summary>
        /// Gets all shipments.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesDefaultResponseType(typeof(List<ShipmentResponseModel>))]
        public async Task<IActionResult> GetAllShipments()
        {
            var result = await _shipmentService.GetShipments();
            var shipment = _mapper.Map<List<ShipmentResponseModel>>(result);

            return Ok(shipment.ToResponse());

        }

        /// <summary>
        /// Gets a specifc shipment
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesDefaultResponseType(typeof(ShipmentResponseModel))]
        public async Task<IActionResult> GetShipmentById(string? id)
        {
            
                var result = await _shipmentService.GetShipment(id);
                if (result.Succeed)
                return Ok(_mapper.Map<ShipmentResponseModel>(result.Item3).ToResponse());
            return NotFound(result.ToResponse(false,result.Message));
           
            
        }


        #endregion


        #region Command
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ProducesDefaultResponseType(typeof(ShipmentResponseModel))]
        public async Task<IActionResult> AddShipment([FromBody] CreateShipmentRequestModel shipmentRequstModel)
        {
            var shipment = _mapper.Map<ShipmentDto>(shipmentRequstModel);
            var result = await _shipmentService.InsertShipment(shipment);
            if(result.Succeed)
                return Ok(_mapper.Map<ShipmentResponseModel>(result.Item3).ToResponse());

            return NotFound(result.ToResponse(false, result.Message));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ProducesDefaultResponseType(typeof(ShipmentResponseModel))]
        public async Task<IActionResult> UpdateShipment([FromBody] ShipmentRequestModel shipmentRequstModel)
        {
            var shipment = _mapper.Map<ShipmentDto>(shipmentRequstModel);
            var result = await _shipmentService.UpdateShipment(shipment);
            if (result.Succeed)
                return Ok(_mapper.Map<ShipmentResponseModel>(result.Item3).ToResponse());

            return NotFound(result.ToResponse(false, result.Message));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPost("status")]
        [ProducesDefaultResponseType(typeof(ShipmentResponseModel))]
        public async Task<IActionResult> UpdateShipmentStatus([FromBody] ShipmentStatusUpdateRequestModel shipment)
        {
            //var shipment = _mapper.Map<ShipmentDto>(shipmentRequstModel);
            var result = await _shipmentService.UpdateShipmentStatus(shipment.Status, shipment.Id);
            if (result.Succeed)
                return Ok(_mapper.Map<ShipmentResponseModel>(result.Item3).ToResponse());

            return NotFound(result.ToResponse(false, result.Message));
        }
        /// <summary>
        /// Deletes a new Country
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShipment(string? id)
        {
            var result = await _shipmentService.DeleteShipment(id);
            if(result.Succeed)
                return Ok(result.ToResponse());
            return BadRequest(result.ToResponse(false, result.Message));
        }
        #endregion
    }
}