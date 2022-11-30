using Api.Seed.Interface;
using Application.Interfaces;
using Application.Request.Role;
using Application.Request.User;
using Domain.Common;
using Domain.Entities;
using Domain.User;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Seed.Data
{
    /// <summary>
    ///
    /// </summary>
    /// <seealso cref="Api.Seed.Interface.ISeeder" />
    public class SeedData : ISeeder
    {
        private class SystemConstants
        {
            public const string SuperAdmin = "superAdmin";
            public const string UserRole = "userRole";
        }

        /// <summary>
        /// Seeds the asynchronous.
        /// </summary>
        /// <param name="app">The application.</param>
        public async Task SeedAsync(IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
                var logger = scope.ServiceProvider.GetRequiredService<ILogger<SeedData>>();
                var accountManager = scope.ServiceProvider.GetRequiredService<IMediator>();
                var context = scope.ServiceProvider.GetRequiredService<IApplicationDbContext>();
                await EnsureRoleAsync(SystemConstants.SuperAdmin, accountManager);
                await EnsureRoleAsync(SystemConstants.UserRole, accountManager);
                

                string superAdminUsername = "superAdmin";
                string userName = "inbuiltUser";

                if (!await userManager.Users.AnyAsync(x => string.Equals(x.UserName, superAdminUsername)))
                {
                    logger.LogInformation("Generating inbuilt accounts for super admin user");

                    await CreateUserAsync(superAdminUsername, "Ibrahim Abdullahi", "P@ssw0rd123", "ibrodex@gmail.com", "+234 7033696601", "6de30bc2-8152-42f3-8765-2fc0f6c05cda", new[] { SystemConstants.SuperAdmin }, accountManager);

                    logger.LogInformation("Inbuilt super admin account generation completed");
                }
                if (!await userManager.Users.AnyAsync(x => string.Equals(x.UserName, userName)))
                {
                    logger.LogInformation("Generating inbuilt accounts for user");

                    await CreateUserAsync(superAdminUsername, "Akera Musbau", "P@ssw0rd123", "akeramusbau@gmail.com", "+234 8054777993", "6de30bc2-8152-42f3-8765-2fc0f6c05cda", new[] { SystemConstants.UserRole }, accountManager);

                    logger.LogInformation("Inbuilt super admin account generation completed");
                }
            }
        }

        private async Task EnsureRoleAsync(string roleName, IMediator accountManager)
        {
            await accountManager.Send(new CreateRoleRequest { Name = roleName });
        }

        private async Task CreateUserAsync(string userName, string fullname, string password, string email, string phoneNumber, string locationId, string[] roles, IMediator accountManager)
        {
            var result = await accountManager.Send(new CreateUserRequest { UserName = userName, FullName = fullname, Email = email, BusinessId = locationId, Password = password, Roles = roles });

            if (!result.succeed)
                throw new System.Exception($"Seeding \"{userName}\" user failed. Errors: {string.Join(Environment.NewLine, result.message)}");
        }


       
        
    }
}