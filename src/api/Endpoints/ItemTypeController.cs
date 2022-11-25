using Api.ResponseWrapper;
using Application.Request.ItemType;
using Application.Response.ItemType;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Endpoints
{ /// <summary>
  ///
  /// </summary>
    [ApiVersion("1.0")]
    public class ItemTypeController : BaseApiController
    {
        /// <summary>
        /// Adds the Add ItemType asynchronous.
        /// </summary>
        /// <param name="ItemTypeRequest">The create group request.</param>
        /// <returns></returns>
        [HttpPost("create")]
        [ProducesDefaultResponseType(typeof(CreateItemTypeResponse))]
        public async Task<IActionResult> AddItemTypeAsync([FromBody] CreateItemTypeRequest ItemTypeRequest)
        {
            (bool succeed, string message, CreateItemTypeResponse ItemTypeResponse) = await Mediator.Send(ItemTypeRequest);
            if (succeed)
                return Ok(ItemTypeResponse.ToResponse());
            return BadRequest(message.ToResponse(false, message));
        }

        /// <summary>
        /// Adds the Add ItemType asynchronous.
        /// </summary>
        /// <returns></returns>
        [HttpGet("getall")]
        [ProducesDefaultResponseType(typeof(GetAllItemTypeResponse))]
        public async Task<IActionResult> GetAllItemTypeAsync()
        {
            List<GetAllItemTypeResponse> ItemType = await Mediator.Send(new GetAllItemTypeRequest());

            return Ok(ItemType.ToResponse());
        }

        /// <summary>
        /// Adds the Get ItemType By asynchronous.
        /// </summary>
        /// <param name="Id">The Get ItemType request.</param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        [ProducesDefaultResponseType(typeof(GetAllItemTypeByIdResponse))]
        public async Task<IActionResult> GetByIdItemTypeAsync(string Id)
        {
            GetAllItemTypeByIdResponse serviceType = await Mediator.Send(new GetItemTypeByIdRequest() { Id = Id });
            return Ok(serviceType.ToResponse());
        }

        /// <summary>
        /// Adds the Update Item asynchronous.
        /// </summary>
        /// <param name="ItemTypeRequest">The update Item request.</param>
        /// <param name="Id">The update ItemType request.</param>
        /// <returns></returns>

        [HttpPost("update")]
        [ProducesDefaultResponseType(typeof(UpdateItemTypeResponse))]
        public async Task<IActionResult> UpdateItemTypeAsync([FromBody] UpdateItemTypeRequest ItemTypeRequest)
        {
            (bool succeed, string message, UpdateItemTypeResponse ItemTypeResponse) = await Mediator.Send(ItemTypeRequest);
            if (succeed)
                return Ok(ItemTypeResponse.ToResponse());
            return BadRequest(message.ToResponse(false, message));
        }
    }
}