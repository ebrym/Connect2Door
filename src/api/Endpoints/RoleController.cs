using Api.ResponseWrapper;
using Application.Request.Role;
using Application.Response.Role;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace Api.Endpoints
{
    /// </summary>
    [ApiVersion("1.0")]
    public class RoleController : BaseApiController
    {
        /// <summary>
        /// Adds a new Role
        /// </summary>
        /// <param name="roleRequest"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("create")]
        [ProducesDefaultResponseType(typeof(CreateRoleResponse))]
        public async Task<IActionResult> AddRoleAsync([FromBody] CreateRoleRequest roleRequest)
        {
            (bool succeed, string message, CreateRoleResponse roleResponse) = await Mediator.Send(roleRequest);
            if (succeed)
                return Ok(roleResponse.ToResponse());
            return BadRequest(message.ToResponse(false, message));
        }

        /// <summary>
        /// Delete a  Role
        /// </summary>
        /// <param name="roleRequest"></param>
        /// <returns></returns>
        [HttpPost("delete")]
        [ProducesDefaultResponseType(typeof(CreateRoleResponse))]
        public async Task<IActionResult> DeleteRoleAsync([FromBody] DeleteRoleRequest roleRequest)
        {
            (bool succeed, string message, DeleteRoleResponse roleResponse) = await Mediator.Send(roleRequest);
            if (succeed)
                return Ok(roleResponse.ToResponse());
            return BadRequest(message.ToResponse(false, message));
        }

        /// <summary>
        /// Gets all Roles
        /// </summary>
        /// <param name="roleRequest"></param>
        /// <returns></returns>
        [HttpGet("get")]
        [ProducesDefaultResponseType(typeof(GetAllRoleResponse))]
        public async Task<IActionResult> GetAllRoleAsync()
        {
            List<GetAllRoleResponse> role = await Mediator.Send(new GetAllRoleRequest());

            return Ok(role.ToResponse());
        }

        /// <summary>
        /// Gets a specific Role
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        [ProducesDefaultResponseType(typeof(GetRoleByIdResponse))]
        public async Task<IActionResult> GetByIdRoleAsync(string Id)
        {
            GetRoleByIdResponse role = await Mediator.Send(new GetRoleByIdRequest() { Id = Id });
            return Ok(role.ToResponse());
        }

        /// <summary>
        /// Updates the Role
        /// </summary>
        /// <param name="roleRequest"></param>
        /// <returns></returns>
        [HttpPost("update")]
        [ProducesDefaultResponseType(typeof(UpdateRoleResponse))]
        public async Task<IActionResult> UpdateRoleAsync([FromBody] UpdateRoleRequest roleRequest)
        {
            UpdateRoleRequest update = new UpdateRoleRequest();
            update = roleRequest;

            (bool succeed, string message, UpdateRoleResponse roleResponse) = await Mediator.Send(update);
            if (succeed)
                return Ok(roleResponse.ToResponse());
            return BadRequest(message.ToResponse(false, message));
        }
    }
}