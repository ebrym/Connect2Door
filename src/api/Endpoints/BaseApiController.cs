using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using OpenIddict.Validation;
using System.Linq;
using OpenIddict.Validation.AspNetCore;

namespace Api.Endpoints
{
    /// <summary>
    ///
    /// </summary>
    [Authorize(AuthenticationSchemes = OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme)]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public abstract class BaseApiController : ControllerBase
    {
        private IMediator mediator;

        /// <summary>
        ///
        /// </summary>
        protected IMediator Mediator => mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        /// <summary>
        /// Users the identifier.
        /// </summary>
        /// <returns></returns>
        protected string UserId()
        {
            return User.Claims.FirstOrDefault(x => x.Type == "sub")?.Value;
        }
    }
}