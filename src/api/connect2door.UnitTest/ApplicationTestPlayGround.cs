using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using connect2door.Data;
using Microsoft.EntityFrameworkCore;
using connect2door.Repository.Interface;
using connect2door.Repository.Services;
using connect2door.Repository.Repository;
using Microsoft.Extensions.Hosting;
using Xunit;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace connect2door.UnitTest
{
    internal class ApplicationTestPlayGround : WebApplicationFactory<Program>
    {
        private readonly string _environment;

        public ApplicationTestPlayGround(string environment = "Development")
        {
            _environment = environment;
        }

        protected override IHost CreateHost(IHostBuilder builder)
        {
            builder.UseEnvironment(_environment);

            // Add mock/test services to the builder here
            builder.ConfigureServices(services =>
            {
                services.AddScoped(sp =>
                {
                    // Replace SQLite with in-memory database for tests
                    return new DbContextOptionsBuilder<DataContext>()
                    .UseInMemoryDatabase("Tests")
                    .UseApplicationServiceProvider(sp)
                    .Options;
                });

                services.AddScoped(typeof(Repository<>),typeof(IRepository<>));
                services.AddScoped<IDriverService, DriverService>();
            });

            return base.CreateHost(builder);
        }

    }

}