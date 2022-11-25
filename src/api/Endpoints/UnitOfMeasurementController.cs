using Api.ResponseWrapper;
using Application.Request.UnitOfMeasurement;
using Application.Response.UnitOfMeasurement;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Endpoints
{
    /// </summary>
    [ApiVersion("1.0")]
    public class UnitOfMeasurementController : BaseApiController
    {
        /// <summary>
        /// Adds a new UnitOfMeasurement
        /// </summary>
        /// <param name="unitOfMeasurementRequest"></param>
        /// <returns></returns>
        [HttpPost("create")]
        [ProducesDefaultResponseType(typeof(CreateUnitOfMeasurementResponse))]
        public async Task<IActionResult> AddUnitOfMeasurementAsync([FromBody] CreateUnitOfMeasurementRequest unitOfMeasurementRequest)
        {
            (bool succeed, string message, CreateUnitOfMeasurementResponse unitOfMeasurementResponse) = await Mediator.Send(unitOfMeasurementRequest);
            if (succeed)
                return Ok(unitOfMeasurementResponse.ToResponse());
            return BadRequest(message.ToResponse(false, message));
        }

        /// <summary>
        /// Adds a new UnitOfMeasurement
        /// </summary>
        /// <param name="unitOfMeasurementRequest"></param>
        /// <returns></returns>
        [HttpGet("delete/{id}")]
        [ProducesDefaultResponseType(typeof(DeleteUnitOfMeasurementResponse))]
        public async Task<IActionResult> DeleteUnitOfMeasurementAsync(string id)
        {
            DeleteUnitOfMeasurementRequest deleteUnitOfMeasurementRequest = new DeleteUnitOfMeasurementRequest();
            deleteUnitOfMeasurementRequest.Id = id;
            (bool succeed, string message, DeleteUnitOfMeasurementResponse deleteUnitOfMeasurementResponse) = await Mediator.Send(deleteUnitOfMeasurementRequest);
            if (succeed)
                return Ok(deleteUnitOfMeasurementResponse.ToResponse());
            return BadRequest(message.ToResponse(false, message));
        }

        /// <summary>
        /// Gets all UnitOfMeasurements
        /// </summary>
        /// <param name="unitOfMeasurementRequest"></param>
        /// <returns></returns>
        [HttpGet("get")]
        [ProducesDefaultResponseType(typeof(GetAllUnitOfMeasurementResponse))]
        public async Task<IActionResult> GetAllUnitOfMeasurementAsync()
        {
            List<GetAllUnitOfMeasurementResponse> unitOfMeasurement = await Mediator.Send(new GetAllUnitOfMeasurementRequest());

            return Ok(unitOfMeasurement.ToResponse());
        }

        /// <summary>
        /// Gets a specific UnitOfMeasurement
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        [ProducesDefaultResponseType(typeof(GetUnitOfMeasurementByIdResponse))]
        public async Task<IActionResult> GetByIdUnitOfMeasurementAsync(string Id)
        {
            GetUnitOfMeasurementByIdResponse UnitOfMeasurement = await Mediator.Send(new GetUnitOfMeasurementByIdRequest() { Id = Id });
            return Ok(UnitOfMeasurement.ToResponse());
        }

        /// <summary>
        /// Updates the UnitOfMeasurement
        /// </summary>
        /// <param name="unitOfMeasurementRequest"></param>
        /// <returns></returns>
        [HttpPost("update")]
        [ProducesDefaultResponseType(typeof(UpdateUnitOfMeasurementResponse))]
        public async Task<IActionResult> UpdateUnitOfMeasurementAsync([FromBody] UpdateUnitOfMeasurementRequest unitOfMeasurementRequest)
        {
            UpdateUnitOfMeasurementRequest update = new UpdateUnitOfMeasurementRequest();
            update = unitOfMeasurementRequest;

            (bool succeed, string message, UpdateUnitOfMeasurementResponse unitOfMeasurementResponse) = await Mediator.Send(update);
            if (succeed)
                return Ok(unitOfMeasurementResponse.ToResponse());
            return BadRequest(message.ToResponse(false, message));
        }
    }
}