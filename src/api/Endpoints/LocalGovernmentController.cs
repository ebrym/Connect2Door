using Api.ResponseWrapper;
using Application.Request.LocalGovernment;
using Application.Response.LocalGovernment;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Endpoints
{
    /// </summary>
    [ApiVersion("1.0")]
    public class LocalGovernmentController : BaseApiController
    {
        /// <summary>
        /// Adds a new LocalGovernment
        /// </summary>
        /// <param name="localGovernmentRequest"></param>
        /// <returns></returns>
        [HttpPost("create")]
        [ProducesDefaultResponseType(typeof(CreateLocalGovernmentResponse))]
        public async Task<IActionResult> AddLocalGovernmentAsync([FromBody] CreateLocalGovernmentRequest localGovernmentRequest)
        {
            (bool succeed, string message, CreateLocalGovernmentResponse localGovernmentResponse) = await Mediator.Send(localGovernmentRequest);
            if (succeed)
                return Ok(localGovernmentResponse.ToResponse());
            return BadRequest(message.ToResponse(false, message));
        }

        /// <summary>
        /// Adds a new LocalGovernment
        /// </summary>
        /// <param name="localGovernmentRequest"></param>
        /// <returns></returns>
        [HttpGet("delete/{id}")]
        [ProducesDefaultResponseType(typeof(DeleteLocalGovernmentResponse))]
        public async Task<IActionResult> DeleteLocalGovernmentAsync(string id)
        {
            DeleteLocalGovernmentRequest deleteLocalGovernmentRequest = new DeleteLocalGovernmentRequest();
            deleteLocalGovernmentRequest.Id = id;
            (bool succeed, string message, DeleteLocalGovernmentResponse deleteLocalGovernmentResponse) = await Mediator.Send(deleteLocalGovernmentRequest);
            if (succeed)
                return Ok(deleteLocalGovernmentResponse.ToResponse());
            return BadRequest(message.ToResponse(false, message));
        }

        /// <summary>
        /// Gets all LocalGovernments
        /// </summary>
        /// <param name="localGovernmentRequest"></param>
        /// <returns></returns>
        [HttpGet("get")]
        [ProducesDefaultResponseType(typeof(GetAllLocalGovernmentResponse))]
        public async Task<IActionResult> GetAllLocalGovernmentAsync()
        {
            List<GetAllLocalGovernmentResponse> localGovernment = await Mediator.Send(new GetAllLocalGovernmentRequest());

            return Ok(localGovernment.ToResponse());
        }

        /// <summary>
        /// Gets a specific LocalGovernment
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        [ProducesDefaultResponseType(typeof(GetLocalGovernmentByIdResponse))]
        public async Task<IActionResult> GetByIdLocalGovernmentAsync(string Id)
        {
            GetLocalGovernmentByIdResponse LocalGovernment = await Mediator.Send(new GetLocalGovernmentByIdRequest() { Id = Id });
            return Ok(LocalGovernment.ToResponse());
        }

        /// <summary>
        /// Updates the LocalGovernment
        /// </summary>
        /// <param name="localGovernmentRequest"></param>
        /// <returns></returns>
        [HttpPost("update")]
        [ProducesDefaultResponseType(typeof(UpdateLocalGovernmentResponse))]
        public async Task<IActionResult> UpdateLocalGovernmentAsync([FromBody] UpdateLocalGovernmentRequest localGovernmentRequest)
        {
            UpdateLocalGovernmentRequest update = new UpdateLocalGovernmentRequest();
            update = localGovernmentRequest;

            (bool succeed, string message, UpdateLocalGovernmentResponse localGovernmentResponse) = await Mediator.Send(update);
            if (succeed)
                return Ok(localGovernmentResponse.ToResponse());
            return BadRequest(message.ToResponse(false, message));
        }
    }
}