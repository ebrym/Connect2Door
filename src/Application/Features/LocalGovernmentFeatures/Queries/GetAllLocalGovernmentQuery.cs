using Application.Interfaces;
using Application.Request.LocalGovernment;
using Application.Response.LocalGovernment;
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
    public class GetAllLocalGovernmentQuery : IRequestHandler<GetAllLocalGovernmentRequest, List<GetAllLocalGovernmentResponse>>
    {
        private readonly IApplicationDbContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllUnitQuery"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public GetAllLocalGovernmentQuery(IApplicationDbContext context)
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
        public async Task<List<GetAllLocalGovernmentResponse>> Handle(GetAllLocalGovernmentRequest request, CancellationToken cancellationToken)
        {
            return await context.LocalGovernments
                .Where(u => u.IsDeleted == false)
                .Include(u => u.State)
                .Include(u => u.State.Country)
                .OrderByDescending(a => a.DateCreated)
                .Select(a => new GetAllLocalGovernmentResponse
                {
                    Code = a.Code,
                    Name = a.Name,
                    StateId = a.StateId,
                    State = a.State,
                    Id = a.Id
                }).ToListAsync(cancellationToken);
        }
    }
}