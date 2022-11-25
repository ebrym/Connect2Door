using Application.Interfaces;
using Application.Request.Company;
using Application.Response.Company;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.UnitFeatures.Queries
{
    /// <summary>
    ///
    /// </summary>
    public class GetAllCompanyQuery : IRequestHandler<GetAllCompanyRequest, List<GetAllCompanyResponse>>
    {
        private readonly IApplicationDbContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllUnitQuery"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public GetAllCompanyQuery(IApplicationDbContext context)
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
        public async Task<List<GetAllCompanyResponse>> Handle(GetAllCompanyRequest request, CancellationToken cancellationToken)
        {
            return await context.Companies
                .Where(u => u.IsDeleted == false)
                .Include(x => x.State)
                .Include(x => x.Country)
                .OrderByDescending(a => a.DateCreated)
                .Select(a => new GetAllCompanyResponse
                {
                    Id = a.Id,
                    Name = a.Name,
                    CountryId = a.CountryId,
                    StateId = a.StateId,
                    Address = a.Address,
                    Banner = a.Banner,
                    Email = a.Email,
                    Logo = a.Logo,
                    Website = a.Website,
                    Country = a.Country,
                    State = a.State
                }).ToListAsync(cancellationToken);
        }
    }
}