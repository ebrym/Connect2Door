using Application.Common.Behaviors;
using Application.Common.Validation;
using Application.Interfaces;
using Application.Service;
using AutoMapper;
using FluentValidation;
using MediatR;
using MediatR.Pipeline;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application
{
    /// <summary>
    /// Register Dependency for application layer
    /// </summary>
    public static class DependencyInjection
    {
        /// <summary>
        /// Extension method to register application dependency
        /// </summary>
        /// <param name="services"></param>
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient<Mediator>();
            
            
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidation<,>));
            services.AddTransient(typeof(IRequestPostProcessor<,>), typeof(AuditTrail<,>));
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            #region Service Registration

            services.AddScoped<IGeneratorService, GeneratorService>();
            services.AddScoped<IBarcodeGeneratorService, BarcodeGeneratorService>();
            services.AddScoped<IQrCodeGeneratorService, QrCodeGeneratorService>();

            #endregion Service Registration
        }
    }
}