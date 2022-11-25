using Application.Interfaces;
using Application.Request.ItemType;
using Application.Response.ItemType;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.ItemTypeFeatures.Queries
{
    /// <summary>
    ///
    /// </summary>
    public class GetAllItemTypeQuery : IRequestHandler<GetAllItemTypeRequest, List<GetAllItemTypeResponse>>
    {
        private readonly IApplicationDbContext context;
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllItemTypeQuery"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="mapper"></param>
        public GetAllItemTypeQuery(IApplicationDbContext context, IMapper mapper)
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
        public async Task<List<GetAllItemTypeResponse>> Handle(GetAllItemTypeRequest request, CancellationToken cancellationToken)
        {
            // return await context.ItemTypes.Select(a => new GetAllItemTypeResponse { ItemTypeName = a.ItemTypeName, Status = a.Status, Id = a.Id }).ToListAsync(cancellationToken);
            return await context.ItemTypes.OrderByDescending(a => a.DateCreated).ProjectTo<GetAllItemTypeResponse>(mapper.ConfigurationProvider).ToListAsync(cancellationToken);
        }
    }
}