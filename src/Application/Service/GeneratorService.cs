using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Application.Service
{
    /// <summary>
    ///
    /// </summary>
    public class GeneratorService : IGeneratorService
    {
        private readonly IApplicationDbContext applicationDbContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="GeneratorService"/> class.
        /// </summary>
        /// <param name="applicationDbContext">The application database context.</param>
        public GeneratorService(IApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        /// <summary>
        /// Generates the asset identifier.
        /// </summary>
        /// <returns></returns>
        public async Task<string> GenerateAssetId()
        {
            Settings settings = await applicationDbContext.Settings.FirstOrDefaultAsync();
            Counter lastNumber = await applicationDbContext.Counters.FirstOrDefaultAsync();
            string uniqueId;
            if (lastNumber != null)
            {
                lastNumber.LastNumber++;
                uniqueId = $"{settings?.AssetIdPrefix}-{lastNumber.LastNumber:D8}";
            }
            else
            {
                await applicationDbContext.Counters.AddAsync(new Counter() { LastNumber = 1, Id = Guid.NewGuid().ToString() });
                uniqueId = $"{settings?.AssetIdPrefix}-{1:D8}";
            }

            await applicationDbContext.SaveChangesAsync();

            return uniqueId;
        }

        /// <summary>
        /// configuration code
        /// </summary>
        /// <param name="initial"></param>
        /// <returns></returns>
        public async Task<string> GenerateId(string initial)
        {
            Counter lastNumber = await applicationDbContext.Counters.FirstOrDefaultAsync();
            string uniqueId;
            //takes the first 3 letters of configuration code
            var ConfigCode = initial.Substring(0, 3).ToUpper();
            if (lastNumber != null)
            {
                lastNumber.LastNumber++;
                uniqueId = $"{ConfigCode}-{lastNumber.LastNumber:D8}";
            }
            else
            {
                await applicationDbContext.Counters.AddAsync(new Counter() { LastNumber = 1, Id = Guid.NewGuid().ToString() });
                uniqueId = $"{ConfigCode}-{1:D8}";
            }

            await applicationDbContext.SaveChangesAsync();

            return uniqueId;
        }
    }
}