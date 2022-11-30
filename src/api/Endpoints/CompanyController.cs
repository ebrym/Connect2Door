using Api.ResponseWrapper;
using Application.Request.Company;
using Application.Response.Company;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Endpoints
{
    /// </summary>
    [ApiVersion("1.0")]
    public class CompanyController : BaseApiController
    {
        /// <summary>
        /// Uploads the asynchronous.
        /// </summary>
        /// <param name="uploadCompanyFileRequest">The file upload request.</param>
        /// <returns></returns>
        [HttpPost("Upload")]
        [ProducesDefaultResponseType(typeof(string))]
        public async Task<IActionResult> UploadAsync([FromForm] UploadCompanyFileRequest uploadCompanyFileRequest)
        {
            var upload = await Mediator.Send(uploadCompanyFileRequest);
            if (upload.Succeed)
                return Ok(upload.Message.ToResponse());
            return BadRequest(upload.Message.ToResponse());
        }

        /// <summary>
        /// Adds a new Company
        /// </summary>
        /// <param name="countryRequest"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesDefaultResponseType(typeof(CreateCompanyResponse))]
        public async Task<IActionResult> AddCompanyAsync([FromForm] CreateCompanyRequest countryRequest)
        {
            (bool succeed, string message, CreateCompanyResponse countryResponse) = await Mediator.Send(countryRequest);
            if (succeed)
                return Ok(countryResponse.ToResponse());
            return BadRequest(message.ToResponse(false, message));
        }

        /// <summary>
        /// Deletes a new Company
        /// </summary>
        /// <param name="countryRequest"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesDefaultResponseType(typeof(DeleteCompanyResponse))]
        public async Task<IActionResult> DeleteCompanyAsync(string id)
        {
            DeleteCompanyRequest deleteCompanyRequest = new DeleteCompanyRequest();
            deleteCompanyRequest.Id = id;
            (bool succeed, string message, DeleteCompanyResponse deleteCompanyResponse) = await Mediator.Send(deleteCompanyRequest);
            if (succeed)
                return Ok(deleteCompanyResponse.ToResponse());
            return BadRequest(message.ToResponse(false, message));
        }

        /// <summary>
        /// Gets all Companys
        /// </summary>
        /// <param name="countryRequest"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesDefaultResponseType(typeof(GetAllCompanyResponse))]
        public async Task<IActionResult> GetAllCompanyAsync()
        {
            List<GetAllCompanyResponse> country = await Mediator.Send(new GetAllCompanyRequest());

            return Ok(country.ToResponse());
        }

        /// <summary>
        /// Gets a specific Company
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        [ProducesDefaultResponseType(typeof(GetCompanyByIdResponse))]
        public async Task<IActionResult> GetByIdCompanyAsync(string Id)
        {
            GetCompanyByIdResponse Company = await Mediator.Send(new GetCompanyByIdRequest() { Id = Id });
            return Ok(Company.ToResponse());
        }

        /// <summary>
        /// Updates the Company
        /// </summary>
        /// <param name="countryRequest"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesDefaultResponseType(typeof(UpdateCompanyResponse))]
        public async Task<IActionResult> UpdateCompanyAsync([FromBody] UpdateCompanyRequest countryRequest)
        {
            UpdateCompanyRequest update = new UpdateCompanyRequest();
            update = countryRequest;

            (bool succeed, string message, UpdateCompanyResponse countryResponse) = await Mediator.Send(update);
            if (succeed)
                return Ok(countryResponse.ToResponse());
            return BadRequest(message.ToResponse(false, message));
        }
    }
}