using Api.Config;
using Application.Request.Role;
using Application.Request.User;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using OpenIddict.Abstractions;
using OpenIddict.Core;
using OpenIddict.EntityFrameworkCore.Models;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Api
{
    /// <summary>
    ///
    /// </summary>
    /// <seealso cref="Microsoft.Extensions.Hosting.IHostedService" />
    public class Worker : IHostedService
    {
        private readonly IServiceProvider serviceProvider;
        private readonly IConfiguration configuration;

        /// <summary>
        /// The system constants.
        /// </summary>
        private class SystemConstants
        {
            /// <summary>
            /// The super admin.
            /// </summary>
            public const string SuperAdmin = "superAdmin";

            /// <summary>
            /// The user role.
            /// </summary>
            public const string UserRole = "userRole";

            
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Worker"/> class.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <param name="configuration">The configuration.</param>
        public Worker(IServiceProvider serviceProvider, IConfiguration configuration)
        {
            this.serviceProvider = serviceProvider;
            this.configuration = configuration;
        }

        /// <summary>
        /// Triggered when the application host is ready to start the service.
        /// </summary>
        /// <param name="cancellationToken">Indicates that the start process has been aborted.</param>
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            using var scope = serviceProvider.CreateScope();

            var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            var logger = scope.ServiceProvider.GetRequiredService<ILogger<Worker>>();
            var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();
            await context.Database.MigrateAsync(cancellationToken: cancellationToken);
            await context.Database.EnsureCreatedAsync(cancellationToken);
         
            // Note: when using a custom entity or a custom key type, replace OpenIddictApplication by the appropriate type.
            var manager = scope.ServiceProvider.GetRequiredService<IOpenIddictApplicationManager>();
            var scopeManager = scope.ServiceProvider.GetRequiredService<IOpenIddictScopeManager>();
            var clientList = new List<Clients>();
            configuration.Bind("Clients", clientList);
            if (clientList.Any())
            {
                foreach (var item in clientList)
                {
                    if (await manager.FindByClientIdAsync(item.ClientId, cancellationToken) == null)
                    {
                        await manager.CreateAsync(new OpenIddictApplicationDescriptor
                        {
                            ClientId = item.ClientId,
                            ClientSecret = item.ClientSecret,
                            DisplayName = item.DisplayName,
                            Permissions =
                            {
                                OpenIddictConstants.Permissions.Endpoints.Token,
                                OpenIddictConstants.Permissions.GrantTypes.ClientCredentials,
                                OpenIddictConstants.Permissions.Endpoints.Authorization,
                                OpenIddictConstants.Permissions.Endpoints.Logout,
                                OpenIddictConstants.Permissions.Endpoints.Introspection
                            },
                            RedirectUris = { new Uri(item.RedirectUris) }
                        }, cancellationToken);
                    }
                }
            }
            var clientResourceList = new List<ClientResource>();
            configuration.Bind("ApiResourceScope", clientResourceList);
            foreach (var item in clientResourceList)
            {
                if (await scopeManager.FindByNameAsync(item.Name, cancellationToken) == null)
                {
                    var descriptor = new OpenIddictScopeDescriptor
                    {
                        Name = item.Name,
                        Resources = { item.Resources }
                    };

                    await scopeManager.CreateAsync(descriptor, cancellationToken);
                }
            }
            //creating roles;
            await EnsureRoleAsync(SystemConstants.SuperAdmin, mediator);
            await EnsureRoleAsync(SystemConstants.UserRole, mediator);

            string superAdminUsername = "superAdmin";
            string userName = "inbuiltUser";

            if (!await context.Users.AnyAsync(x => string.Equals(x.UserName, superAdminUsername)))
            {
                logger.LogInformation("Generating inbuilt accounts for super admin user");

                await CreateUserAsync(superAdminUsername, 
                    "Ibrahim Abdullahi", 
                    "P@ssw0rd123", 
                    "ibrodex@gmail.com", 
                    "+234 7033696601", 
                    "6de30bc2-8152-42f3-8765-2fc0f6c05cda", 
                    new[] { SystemConstants.SuperAdmin }, mediator);

                logger.LogInformation("Inbuilt super admin account generation completed");
            }
            if (!await context.Users.AnyAsync(x => string.Equals(x.UserName, userName)))
            {
                logger.LogInformation("Generating inbuilt accounts for user");

                await CreateUserAsync(superAdminUsername, 
                    "Akera Musbau", 
                    "P@ssw0rd123", 
                    "akeramusbau@gmail.com", 
                    "+234 8054777993", 
                    "6de30bc2-8152-42f3-8765-2fc0f6c05cda", 
                    new[] { SystemConstants.UserRole }, mediator);

                logger.LogInformation("Inbuilt super admin account generation completed");
            }
            

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="roleName"></param>
        /// <param name="accountManager"></param>
        /// <returns></returns>
        private async Task EnsureRoleAsync(string roleName, IMediator accountManager)
        {
            await accountManager.Send(new CreateRoleRequest { Name = roleName });
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="fullname"></param>
        /// <param name="password"></param>
        /// <param name="email"></param>
        /// <param name="phoneNumber"></param>
        /// <param name="BusinessId"></param>
        /// <param name="roles"></param>
        /// <param name="accountManager"></param>
        /// <returns></returns>
        private async Task CreateUserAsync(string userName, string fullname, string password, string email, string phoneNumber, string locationId, string[] roles, IMediator accountManager)
        {
            var result = await accountManager.Send(new CreateUserRequest { UserName = userName, FullName = fullname, Email = email, BusinessId = locationId, Password = password, Roles = roles });

            if (!result.succeed)
                throw new System.Exception($"Seeding \"{userName}\" user failed. Errors: {string.Join(Environment.NewLine, result.message)}");
        }


       
        /// <summary>
        /// Triggered when the application host is performing a graceful shutdown.
        /// </summary>
        /// <param name="cancellationToken">Indicates that the shutdown process should no longer be graceful.</param>
        /// <returns></returns>

        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
    }
}