using Application.Interfaces;
using Application.Request.Unit;
using Application.Response.Unit;
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
    public class GetAllUnitQuery : IRequestHandler<GetAllUnitRequest, List<GetAllUnitResponse>>
    {
        private readonly IApplicationDbContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllUnitQuery"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public GetAllUnitQuery(IApplicationDbContext context)
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
        public async Task<List<GetAllUnitResponse>> Handle(GetAllUnitRequest request, CancellationToken cancellationToken)
        {
            return await context
                .Units
                .OrderByDescending(a => a.DateCreated)
                .Where(u => u.IsDeleted == false).Select(a => new GetAllUnitResponse
                {
                    Code = a.Code,
                    Name = a.Name,
                    Id = a.Id,
                }).ToListAsync(cancellationToken);
        }
    }
}