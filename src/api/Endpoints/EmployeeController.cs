using Api.ResponseWrapper;
using Application.Features.EmployeeFeature.Commands;
using Application.Request.Employee;
using Application.Response.Employee;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Endpoints
{
    /// <summary>
    ///
    /// </summary>
    [ApiVersion("1.0")]
    public class EmployeeController : BaseApiController
    {
        /// <summary>
        /// Adds the Add Group asynchronous.
        /// </summary>
        /// <param name="employeeRequest">The create group request.</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesDefaultResponseType(typeof(CreateEmployeeResponse))]
        public async Task<IActionResult> AddEmployeeAsync([FromBody] CreateEmployeeRequest employeeRequest)
        {
            (bool succeed, string message, CreateEmployeeResponse employeeResponse) = await Mediator.Send(employeeRequest);
            if (succeed)
                return Ok(employeeResponse.ToResponse());
            return BadRequest(message.ToResponse(false, message));
        }

        /// <summary>
        /// Deletes a Employee
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesDefaultResponseType(typeof(DeleteEmployeeResponse))]
        public async Task<IActionResult> DeleteEmployeeAsync(string id)
        {
            DeleteEmployeeRequest deleteEmployeeRequest = new DeleteEmployeeRequest
            {
                Id = id
            };
            (bool succeed, string message, DeleteEmployeeResponse deleteEmployeeResponse) =
                await Mediator.Send(deleteEmployeeRequest);
            if (succeed)
                return Ok(deleteEmployeeResponse.ToResponse());
            return BadRequest(message.ToResponse(false, message));
        }

        /// <summary>
        /// Adds the Add Group asynchronous.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesDefaultResponseType(typeof(GetAllEmployeeResponse))]
        public async Task<IActionResult> GetAllEmployeeAsync()
        {
            List<GetAllEmployeeResponse> employee = await Mediator.Send(new GetAllEmployeeRequest());

            return Ok(employee.ToResponse());
        }

        /// <summary>
        /// Adds the Get Group By asynchronous.
        /// </summary>
        /// <param name="Id">The add group request.</param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        [ProducesDefaultResponseType(typeof(GetEmployeeByIdResponse))]
        public async Task<IActionResult> GetByIdEmployeeAsync(string Id)
        {
            GetEmployeeByIdResponse employee = await Mediator.Send(new GetEmployeeByIdRequest() { Id = Id });
            return Ok(employee.ToResponse());
        }

        /// <summary>
        /// Adds the Update employee asynchronous.
        /// </summary>
        /// <param name="employeeRequest">The update employee request.</param>
        /// <param name="Id">The update employee request.</param>
        /// <returns></returns>

        [HttpPut]
        [ProducesDefaultResponseType(typeof(UpdateEmployeeResponse))]
        public async Task<IActionResult> UpdateEmployeeAsync([FromBody] UpdateEmployeeRequest employeeRequest)
        {
            (bool succeed, string message, UpdateEmployeeResponse employeeResponse) = await Mediator.Send(employeeRequest);
            if (succeed)
                return Ok(employeeResponse.ToResponse());
            return BadRequest(message.ToResponse(false, message));
        }

        /*/// <summary>
        /// 
        /// </summary>
        /// <param name="employeeRequest"></param>
        /// <returns></returns>
        [HttpPost("upload")]
        [ProducesDefaultResponseType(typeof(CreateEmployeeResponse[]))]
        public async Task<IActionResult> UploadEmployeeAsync([FromForm] UploadEmployeeRequest employeeRequest)
        {
            (bool succeed, string message, CreateEmployeeResponse[] employeeResponse) = await Mediator.Send(employeeRequest);
            if (succeed)
                return Ok(employeeResponse.ToResponse());
            return BadRequest(message.ToResponse(false, message));
        }*/
    }
}