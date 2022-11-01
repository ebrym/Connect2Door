
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.Http.Json;

namespace connect2door.Api.Exception
{
    /// <summary>
    ///
    /// </summary>
    public static class GlobalExceptionFilter
    {
        /// <summary>
        /// Configures the exception handler.
        /// </summary>
        /// <param name="app">The application.</param>
        /// <param name="logger">The logger.</param>
        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";

                    var contextFeature =  context.Features.Get<IExceptionHandlerFeature>();

                    if (contextFeature != null)
                    {

                        if (contextFeature.Error.GetType() == typeof(ValidationException))
                        {
                            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                            var error = contextFeature.Error as ValidationException;
                           
                        }
                        else 
                        {
                            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                          
                        }
                    }

                    return Task.CompletedTask;
                });
            });
        }
    }
}