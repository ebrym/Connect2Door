using Microsoft.AspNetCore.Builder;
using System.Threading.Tasks;

namespace Api.Seed.Interface
{
    /// <summary>
    ///
    /// </summary>
    public interface ISeeder
    {
        /// <summary>
        /// Seeds the asynchronous.
        /// </summary>
        /// <param name="app">The application.</param>
        /// <returns></returns>
        Task SeedAsync(IApplicationBuilder app);
    }
}