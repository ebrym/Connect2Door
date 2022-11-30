using Application.Interfaces;
using Application.Request.UnitOfMeasurement;
using Application.Response.UnitOfMeasurement;
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
    public class GetAllUnitOfMeasurementQuery : IRequestHandler<GetAllUnitOfMeasurementRequest, List<GetAllUnitOfMeasurementResponse>>
    {
        private readonly IApplicationDbContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllUnitQuery"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public GetAllUnitOfMeasurementQuery(IApplicationDbContext context)
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
        public async Task<List<GetAllUnitOfMeasurementResponse>> Handle(GetAllUnitOfMeasurementRequest request, CancellationToken cancellationToken)
        {
            return await context.UnitOfMeasurements.Where(u => u.IsDeleted == false).OrderByDescending(a => a.DateCreated).Select(a => new GetAllUnitOfMeasurementResponse
            {
                Code = a.Code,
                Name = a.Name,
                Id = a.Id
            }).ToListAsync(cancellationToken);
        }
    }
}