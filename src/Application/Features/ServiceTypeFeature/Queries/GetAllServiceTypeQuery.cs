using Application.Interfaces;
using Application.Request.ServiceType;
using Application.Response.ServiceType;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.ServiceTypeFeature.Queries
{
    /// <summary>
    ///
    /// </summary>
    public class GetAllServiceTypeQuery : IRequestHandler<GetAllServiceTypeRequest, List<GetAllServiceTypeResponse>>
    {
        private readonly IApplicationDbContext context;
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllServiceTypeQuery"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="mapper"></param>
        public GetAllServiceTypeQuery(IApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        /// <summary>
        /// Handles a request
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>
        /// Response from the request
        /// </returns>
        public async Task<List<GetAllServiceTypeResponse>> Handle(GetAllServiceTypeRequest request, CancellationToken cancellationToken)
        {
            //return await context.ServiceTypes.Select(a => new GetAllServiceTypeResponse { ServiceTypeName = a.ServiceTypeName, Status = a.Status, Id = a.Id }).ToListAsync(cancellationToken);
            return await context.ServiceTypes.OrderByDescending(a => a.DateCreated).Where(x => !x.IsDeleted).ProjectTo<GetAllServiceTypeResponse>(mapper.ConfigurationProvider).ToListAsync(cancellationToken);
        }
    }
}