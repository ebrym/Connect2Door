using Application.Interfaces;
using Application.Request.State;
using Application.Response.State;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.UnitFeatures.Queries
{
    /// <summary>
    ///
    /// </summary>

    public class GetStateByIdQuerry : IRequestHandler<GetStateByIdRequest, GetStateByIdResponse>
    {
        private readonly IApplicationDbContext applicationDbContext;
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetUnitByIdQuerry"/> class.
        /// </summary>
        /// <param name="applicationDbContext">The application database context.</param>
        /// <param name="mapper">The mapper.</param>
        public GetStateByIdQuerry(IApplicationDbContext applicationDbContext, IMapper mapper)
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
        public async Task<GetStateByIdResponse> Handle(GetStateByIdRequest request, CancellationToken cancellationToken)
        {
            return await applicationDbContext.States
                .Where(x => x.Id == request.Id && x.IsDeleted == false)
                .Include(x => x.Country)
                .ProjectTo<GetStateByIdResponse>(mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();
        }
    }
}