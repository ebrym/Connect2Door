using Application.Interfaces;
using Application.Request.State;
using Application.Response.State;
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
    public class GetAllStateQuery : IRequestHandler<GetAllStateRequest, List<GetAllStateResponse>>
    {
        private readonly IApplicationDbContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllUnitQuery"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public GetAllStateQuery(IApplicationDbContext context)
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
        public async Task<List<GetAllStateResponse>> Handle(GetAllStateRequest request, CancellationToken cancellationToken)
        {
            return await context.States.Where(u => u.IsDeleted == false)
                .Include(u => u.Country)
                .OrderByDescending(a => a.DateCreated)
                .Select(a => new GetAllStateResponse
                {
                    Code = a.Code,
                    Name = a.Name,
                    Country = a.Country,
                    CountryId = a.CountryId,
                    Id = a.Id
                }).ToListAsync(cancellationToken);
        }
    }
}