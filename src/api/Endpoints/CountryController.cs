using Api.ResponseWrapper;
using Application.Request.Country;
using Application.Response.Country;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Endpoints
{
    /// </summary>
    [ApiVersion("1.0")]
    public class CountryController : BaseApiController
    {
        /// <summary>
        /// Adds a new Country
        /// </summary>
        /// <param name="countryRequest"></param>
        /// <returns></returns>
        [HttpPost("create")]
        [ProducesDefaultResponseType(typeof(CreateCountryResponse))]
        public async Task<IActionResult> AddCountryAsync([FromBody] CreateCountryRequest countryRequest)
        {
            (bool succeed, string message, CreateCountryResponse countryResponse) = await Mediator.Send(countryRequest);
            if (succeed)
                return Ok(countryResponse.ToResponse());
            return BadRequest(message.ToResponse(false, message));
        }

        /// <summary>
        /// Deletes a new Country
        /// </summary>
        /// <param name="countryRequest"></param>
        /// <returns></returns>
        [HttpGet("delete/{id}")]
        [ProducesDefaultResponseType(typeof(DeleteCountryResponse))]
        public async Task<IActionResult> DeleteCountryAsync(string id)
        {
            DeleteCountryRequest deleteCountryRequest = new DeleteCountryRequest();
            deleteCountryRequest.Id = id;
            (bool succeed, string message, DeleteCountryResponse deleteCountryResponse) = await Mediator.Send(deleteCountryRequest);
            if (succeed)
                return Ok(deleteCountryResponse.ToResponse());
            return BadRequest(message.ToResponse(false, message));
        }

        /// <summary>
        /// Gets all Countrys
        /// </summary>
        /// <param name="countryRequest"></param>
        /// <returns></returns>
        [HttpGet("get")]
        [ProducesDefaultResponseType(typeof(GetAllCountryResponse))]
        public async Task<IActionResult> GetAllCountryAsync()
        {
            List<GetAllCountryResponse> country = await Mediator.Send(new GetAllCountryRequest());

            return Ok(country.ToResponse());
        }

        /// <summary>
        /// Gets a specific Country
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        [ProducesDefaultResponseType(typeof(GetCountryByIdResponse))]
        public async Task<IActionResult> GetByIdCountryAsync(string Id)
        {
            GetCountryByIdResponse Country = await Mediator.Send(new GetCountryByIdRequest() { Id = Id });
            return Ok(Country.ToResponse());
        }

        /// <summary>
        /// Updates the Country
        /// </summary>
        /// <param name="countryRequest"></param>
        /// <returns></returns>
        [HttpPost("update")]
        [ProducesDefaultResponseType(typeof(UpdateCountryResponse))]
        public async Task<IActionResult> UpdateCountryAsync([FromBody] UpdateCountryRequest countryRequest)
        {
            UpdateCountryRequest update = new UpdateCountryRequest();
            update = countryRequest;

            (bool succeed, string message, UpdateCountryResponse countryResponse) = await Mediator.Send(update);
            if (succeed)
                return Ok(countryResponse.ToResponse());
            return BadRequest(message.ToResponse(false, message));
        }
    }
}