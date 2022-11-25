using Api.ResponseWrapper;
using Application.Request.State;
using Application.Response.State;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Endpoints
{
    /// </summary>
    [ApiVersion("1.0")]
    public class StateController : BaseApiController
    {
        /// <summary>
        /// Adds a new State
        /// </summary>
        /// <param name="stateRequest"></param>
        /// <returns></returns>
        [HttpPost("create")]
        [ProducesDefaultResponseType(typeof(CreateStateResponse))]
        public async Task<IActionResult> AddStateAsync([FromBody] CreateStateRequest stateRequest)
        {
            (bool succeed, string message, CreateStateResponse stateResponse) = await Mediator.Send(stateRequest);
            if (succeed)
                return Ok(stateResponse.ToResponse());
            return BadRequest(message.ToResponse(false, message));
        }

        /// <summary>
        /// Adds a new State
        /// </summary>
        /// <param name="stateRequest"></param>
        /// <returns></returns>
        [HttpGet("delete/{id}")]
        [ProducesDefaultResponseType(typeof(DeleteStateResponse))]
        public async Task<IActionResult> DeleteStateAsync(string id)
        {
            DeleteStateRequest deleteStateRequest = new DeleteStateRequest();
            deleteStateRequest.Id = id;
            (bool succeed, string message, DeleteStateResponse deleteStateResponse) = await Mediator.Send(deleteStateRequest);
            if (succeed)
                return Ok(deleteStateResponse.ToResponse());
            return BadRequest(message.ToResponse(false, message));
        }

        /// <summary>
        /// Gets all States
        /// </summary>
        /// <param name="stateRequest"></param>
        /// <returns></returns>
        [HttpGet("get")]
        [ProducesDefaultResponseType(typeof(GetAllStateResponse))]
        public async Task<IActionResult> GetAllStateAsync()
        {
            List<GetAllStateResponse> state = await Mediator.Send(new GetAllStateRequest());

            return Ok(state.ToResponse());
        }

        /// <summary>
        /// Gets a specific State
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        [ProducesDefaultResponseType(typeof(GetStateByIdResponse))]
        public async Task<IActionResult> GetByIdStateAsync(string Id)
        {
            GetStateByIdResponse State = await Mediator.Send(new GetStateByIdRequest() { Id = Id });
            return Ok(State.ToResponse());
        }

        /// <summary>
        /// Updates the State
        /// </summary>
        /// <param name="stateRequest"></param>
        /// <returns></returns>
        [HttpPost("update")]
        [ProducesDefaultResponseType(typeof(UpdateStateResponse))]
        public async Task<IActionResult> UpdateStateAsync([FromBody] UpdateStateRequest stateRequest)
        {
            UpdateStateRequest update = new UpdateStateRequest();
            update = stateRequest;

            (bool succeed, string message, UpdateStateResponse stateResponse) = await Mediator.Send(update);
            if (succeed)
                return Ok(stateResponse.ToResponse());
            return BadRequest(message.ToResponse(false, message));
        }
    }
}