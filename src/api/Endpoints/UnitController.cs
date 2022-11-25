using Api.ResponseWrapper;
using Application.Request.Unit;
using Application.Response.Unit;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Endpoints
{
    /// </summary>
    [ApiVersion("1.0")]
    public class UnitController : BaseApiController
    {
        /// <summary>
        /// Adds a new Unit
        /// </summary>
        /// <param name="unitRequest"></param>
        /// <returns></returns>
        [HttpPost("create")]
        [ProducesDefaultResponseType(typeof(CreateUnitResponse))]
        public async Task<IActionResult> AddUnitAsync([FromBody] CreateUnitRequest unitRequest)
        {
            (bool succeed, string message, CreateUnitResponse unitResponse) = await Mediator.Send(unitRequest);
            if (succeed)
                return Ok(unitResponse.ToResponse());
            return BadRequest(message.ToResponse(false, message));
        }

        /// <summary>
        /// Adds a new Unit
        /// </summary>
        /// <param name="unitRequest"></param>
        /// <returns></returns>
        [HttpGet("delete/{id}")]
        [ProducesDefaultResponseType(typeof(DeleteUnitResponse))]
        public async Task<IActionResult> DeleteUnitAsync(string id)
        {
            DeleteUnitRequest deleteUnitRequest = new DeleteUnitRequest();
            deleteUnitRequest.Id = id;
            (bool succeed, string message, DeleteUnitResponse deleteUnitResponse) = await Mediator.Send(deleteUnitRequest);
            if (succeed)
                return Ok(deleteUnitResponse.ToResponse());
            return BadRequest(message.ToResponse(false, message));
        }

        /// <summary>
        /// Gets all Units
        /// </summary>
        /// <param name="unitRequest"></param>
        /// <returns></returns>
        [HttpGet("get")]
        [ProducesDefaultResponseType(typeof(GetAllUnitResponse))]
        public async Task<IActionResult> GetAllUnitAsync()
        {
            List<GetAllUnitResponse> unit = await Mediator.Send(new GetAllUnitRequest());

            return Ok(unit.ToResponse());
        }

        /// <summary>
        /// Gets a specific Unit
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        [ProducesDefaultResponseType(typeof(GetUnitByIdResponse))]
        public async Task<IActionResult> GetByIdUnitAsync(string Id)
        {
            GetUnitByIdResponse Unit = await Mediator.Send(new GetUnitByIdRequest() { Id = Id });
            return Ok(Unit.ToResponse());
        }

        /// <summary>
        /// Updates the Unit
        /// </summary>
        /// <param name="unitRequest"></param>
        /// <returns></returns>
        [HttpPost("update")]
        [ProducesDefaultResponseType(typeof(UpdateUnitResponse))]
        public async Task<IActionResult> UpdateUnitAsync([FromBody] UpdateUnitRequest unitRequest)
        {
            UpdateUnitRequest update = new UpdateUnitRequest();
            update = unitRequest;

            (bool succeed, string message, UpdateUnitResponse unitResponse) = await Mediator.Send(update);
            if (succeed)
                return Ok(unitResponse.ToResponse());
            return BadRequest(message.ToResponse(false, message));
        }
    }
}