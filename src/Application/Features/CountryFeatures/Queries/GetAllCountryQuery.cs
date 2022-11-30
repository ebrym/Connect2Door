using Application.Interfaces;
using Application.Request.Country;
using Application.Response.Country;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.UnitFeatures.Queries
{
    /// <summary>
    ///
    /// </summary>
    public class GetAllCountryQuery : IRequestHandler<GetAllCountryRequest, List<GetAllCountryResponse>>
    {
        private readonly IApplicationDbContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllUnitQuery"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public GetAllCountryQuery(IApplicationDbContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Handles a request
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>
        /// Response from the request
        /// </returns>
        public async Task<List<GetAllCountryResponse>> Handle(GetAllCountryRequest request, CancellationToken cancellationToken)
        {
            return await context.Countries.Where(u => u.IsDeleted == false).OrderByDescending(a => a.DateCreated).Select(a => new GetAllCountryResponse
            {
                Code = a.Code,
                Name = a.Name,
                Id = a.Id
            }).ToListAsync(cancellationToken);
        }
    }
}