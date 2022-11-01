
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using connect2door.Api.Models;

namespace connect2door.Api.Controllers
{
    /// <summary>
    /// Base controller for all APIs
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    [ApiController]
    [Route("api/[controller]")]
    public class BaseController : Controller
    {
        /// <summary>
        /// Users the identifier.
        /// </summary>
        /// <returns></returns>
        protected string UserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
        /// <summary>
        /// Called before the action method is invoked.
        /// </summary>
        /// <param name="context">The action executing context.</param>
        public override void OnActionExecuting(ActionExecutingContext context)
        {


            if (!context.ModelState.IsValid)
            {
                var errors = context.ModelState.Values.Select(u => u.Errors);


                context.Result = new BadRequestObjectResult(
                    new ResponseModel<string>(null!, false,
                        string.Join(',',
                            (from error in errors
                                where error.FirstOrDefault() != null
                                select error.FirstOrDefault()?.ErrorMessage)
                            .ToArray())));
            }
            base.OnActionExecuting(context);


        }
    }
}