using Application.Interfaces;
using Application.Request.ItemType;
using Application.Response.ItemType;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.ItemTypeFeatures.Queries
{
    /// <summary>
    ///
    /// </summary>
    public class GetItemTypeByIdQuery : IRequestHandler<GetItemTypeByIdRequest, GetAllItemTypeByIdResponse>
    {
        private readonly IApplicationDbContext applicationDbContext;
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetItemTypeByIdQuery"/> class.
        /// </summary>
        /// <param name="applicationDbContext">The application database context.</param>
        /// <param name="mapper">The mapper.</param>
        public GetItemTypeByIdQuery(IApplicationDbContext applicationDbContext, IMapper mapper)
        {
            this.applicationDbContext = applicationDbContext;
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
        public async Task<GetAllItemTypeByIdResponse> Handle(GetItemTypeByIdRequest request, CancellationToken cancellationToken)
        {
            return await applicationDbContext.ItemTypes.ProjectTo<GetAllItemTypeByIdResponse>(mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(x => x.Id.Equals(request.Id), cancellationToken);
        }
    }
}