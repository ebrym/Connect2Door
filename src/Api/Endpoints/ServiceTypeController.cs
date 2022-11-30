using Api.ResponseWrapper;
using Application.Features.ServiceTypeFeature.Commands;
using Application.Request.ServiceType;
using Application.Response.ServiceType;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Endpoints
{
    /// <summary>
    ///
    /// </summary>
    [ApiVersion("1.0")]
    public class ServiceTypeController : BaseApiController
    {
        /// <summary>
        /// Adds the Add ServiceType asynchronous.
        /// </summary>
        /// <param name="serviceTypeRequest">The create group request.</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesDefaultResponseType(typeof(CreateServiceTypeResponse))]
        public async Task<IActionResult> AddserviceTypeAsync([FromBody] CreateServiceTypeRequest serviceTypeRequest)
        {
            (bool succeed, string message, CreateServiceTypeResponse serviceTypeResponse) = await Mediator.Send(serviceTypeRequest);
            if (succeed)
                return Ok(serviceTypeResponse.ToResponse());
            return BadRequest(message.ToResponse(false, message));
        }

        /// <summary>
        /// Adds the Add serviceType asynchronous.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesDefaultResponseType(typeof(GetAllServiceTypeResponse))]
        public async Task<IActionResult> GetAllserviceTypeAsync()
        {
            List<GetAllServiceTypeResponse> serviceType = await Mediator.Send(new GetAllServiceTypeRequest());

            return Ok(serviceType.ToResponse());
        }

        /// <summary>
        /// Adds the Get serviceType By asynchronous.
        /// </summary>
        /// <param name="Id">The add serviceType request.</param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        [ProducesDefaultResponseType(typeof(GetServiceTypeByIdResponse))]
        public async Task<IActionResult> GetByIdserviceTypeAsync(string Id)
        {
            GetServiceTypeByIdResponse serviceType = await Mediator.Send(new GetServiceTypeByIdRequest() { Id = Id });
            return Ok(serviceType.ToResponse());
        }

        /// <summary>
        /// Adds the Update Group asynchronous.
        /// </summary>
        /// <param name="serviceTypeRequest">The update group request.</param>
        /// <param name="Id">The update serviceType request.</param>
        /// <returns></returns>

        [HttpPut]
        [ProducesDefaultResponseType(typeof(UpdateServiceTypeResponse))]
        public async Task<IActionResult> UpdateserviceTypeAsync([FromBody] UpdateServiceTypeRequest serviceTypeRequest)
        {
            (bool succeed, string message, UpdateServiceTypeResponse serviceTypeResponse) = await Mediator.Send(serviceTypeRequest);
            if (succeed)
                return Ok(serviceTypeResponse.ToResponse());
            return BadRequest(message.ToResponse(false, message));
        }

        /// <summary>
        /// Deletes the service type asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesDefaultResponseType(typeof(string))]
        public async Task<IActionResult> DeleteServiceTypeAsync(string id)
        {
            (bool succeed, string message) = await Mediator.Send(new DeleteServiceTypeCommand { Id = id });
            if (succeed)
                return Ok(message.ToResponse());
            return BadRequest(message.ToResponse(false, message));
        }
    }
}