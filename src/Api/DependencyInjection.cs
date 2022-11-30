﻿
using Application.BackgroundService;
using AspNet.Security.OpenIdConnect.Primitives;
using AspNet.Security.OpenIdConnect.Server;
using Domain.User;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NSwag;
using NSwag.Generation.Processors.Security;
using OpenIddict.Abstractions;
using OpenIddict.Validation;
using Serilog;
using System;
using System.Linq;
using Api.Seed.Data;
using Api.Seed.Interface;
using OpenIddict.Server.AspNetCore;
using OpenIddict.Validation.AspNetCore;
using Persistence;

namespace Api
{
    /// <summary>
    ///
    /// </summary>
    public static class DependencyInjection
    {
        /// <summary>
        /// Adds the identity.
        /// </summary>
        /// <param name="services">The services.</param>
        public static void AddIdentity(this IServiceCollection services)
        {
            services.AddIdentity<User, Role>(/*options => options.SignIn.RequireConfirmedAccount = true*/)
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                // Password settings.
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;

                // Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                // User settings.
                options.User.AllowedUserNameCharacters =
                    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = true;

                options.ClaimsIdentity.UserNameClaimType = OpenIdConnectConstants.Claims.Name;
                options.ClaimsIdentity.UserIdClaimType = OpenIdConnectConstants.Claims.Subject;
                options.ClaimsIdentity.RoleClaimType = OpenIdConnectConstants.Claims.Role;
            });
            services.AddAuthentication(options =>
            {

                options.DefaultScheme = OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme;   
                //options.DefaultAuthenticateScheme = OpenIddictServerAspNetCoreDefaults.AuthenticationScheme;
                //OpenIddict.Server.AspNetCore.OpenIddictServerAspNetCoreDefaults
                // options.DefaultAuthenticateScheme = OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme;
                
            });
            services.Configure<OpenIdConnectServerOptions>(opt =>
            {
                opt.AllowInsecureHttp = true;
            });
            services.AddOpenIddict()
                .AddCore(options =>
                {
                    options.UseEntityFrameworkCore()
                        .UseDbContext<ApplicationDbContext>();
                })
                .AddServer(options =>
                {
                    options.SetAuthorizationEndpointUris("/connect/authorize")
                        .SetIntrospectionEndpointUris("/connect/introspect")
                        .SetTokenEndpointUris("/connect/token");
                    
                    options.AllowPasswordFlow();
                    options.AllowAuthorizationCodeFlow();
                    options.AllowImplicitFlow();
                    options.AllowClientCredentialsFlow();
                    options.AcceptAnonymousClients();
                    options.RegisterScopes(
                        OpenIdConnectConstants.Scopes.OpenId,
                        OpenIdConnectConstants.Scopes.Email,
                        OpenIdConnectConstants.Scopes.Phone,
                        OpenIdConnectConstants.Scopes.Profile,
                        OpenIdConnectConstants.Scopes.OfflineAccess,
                        OpenIddictConstants.Scopes.Roles);
                    //   if (!hostEnvironment.IsDevelopment())
                    //    options.AddSigningCertificate(new X509Certificate2(file, password));
                    //    else
                    //options.AddDevelopmentSigningCertificate();
                    options
                        .AddDevelopmentEncryptionCertificate()
                        .AddDevelopmentSigningCertificate();
                    
                    options.RegisterClaims();
                    
                    options.AddEphemeralEncryptionKey()
                        .AddEphemeralSigningKey();

                    options.UseAspNetCore()
                        .EnableTokenEndpointPassthrough()
                        // Gateways call with http
                        .DisableTransportSecurityRequirement();
                }).AddValidation(options =>
                {
                    // Import the configuration from the local OpenIddict server instance.
                    options.UseLocalServer();

                    // Register the ASP.NET Core host.
                    options.UseAspNetCore();

                    // Enable authorization entry validation, which is required to be able
                    // to reject access tokens retrieved from a revoked authorization code.
                    options.EnableAuthorizationEntryValidation();
                    options.EnableTokenEntryValidation();
                });
           
            services.AddScoped<ISeeder, SeedData>();
            //services.AddHostedService<Worker>();
            services.AddHostedService<NotificationWorkerService>();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="service"></param>
        public static void AddApiVersion(this IServiceCollection service)
        {
            service.AddApiVersioning(config =>
            {
                // Specify the default API Version as 1.0
                config.DefaultApiVersion = new ApiVersion(1, 0);
                // If the client hasn't specified the API version in the request, use the default API version number
                config.AssumeDefaultVersionWhenUnspecified = true;
                // Advertise the API versions supported for the particular endpoint
                config.ReportApiVersions = true;
            });
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="service"></param>
        public static void AddDocSwagger(this IServiceCollection service)
        {
            service.AddSwaggerDocument(x =>
            {
                x.GenerateXmlObjects = true;
                x.GenerateEnumMappingDescription = true;
                x.DocumentName = "Connect 2 door Apis";
                x.Title = "Connect to door";
                x.Description = "Connect to door Apis";
                x.AddSecurity("oauth2", Enumerable.Empty<string>(), new OpenApiSecurityScheme
                {
                    Type = OpenApiSecuritySchemeType.ApiKey,
                    Name = "Authorization",
                    In = OpenApiSecurityApiKeyLocation.Header,
                    Description = "Type into the text-box: Bearer {your JWT token}.",
                    Scheme = "Bearer"
                });
                x.OperationProcessors.Add(
                    new AspNetCoreOperationSecurityScopeProcessor("oauth2"));
            });
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="app"></param>
        public static void UseDocSwagger(this IApplicationBuilder app)
        {
            app.UseOpenApi();
            app.UseSwaggerUi3(s =>
            {
                s.Path = "";
                s.DocumentTitle = "Asset Management Api";
            });
            app.UseReDoc(d =>
            {
                d.Path = "/redoc";
            });
        }

        /// <summary>
        /// Adds the serilog logger.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <param name="config">The configuration.</param>
        public static void AddSerilogLogger(this IServiceCollection services, IConfiguration config)
        {
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(config).Enrich.FromLogContext().CreateLogger();

            services.AddSingleton(Log.Logger);
        }
    }
}