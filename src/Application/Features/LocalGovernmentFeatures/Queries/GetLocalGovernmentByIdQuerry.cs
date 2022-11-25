using Application.Interfaces;
using Application.Request.LocalGovernment;
using Application.Response.LocalGovernment;
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

    public class GetLocalGovernmentByIdQuerry : IRequestHandler<GetLocalGovernmentByIdRequest, GetLocalGovernmentByIdResponse>
    {
        private readonly IApplicationDbContext applicationDbContext;
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetUnitByIdQuerry"/> class.
        /// </summary>
        /// <param name="applicationDbContext">The application database context.</param>
        /// <param name="mapper">The mapper.</param>
        public GetLocalGovernmentByIdQuerry(IApplicationDbContext applicationDbContext, IMapper mapper)
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
        public async Task<GetLocalGovernmentByIdResponse> Handle(GetLocalGovernmentByIdRequest request, CancellationToken cancellationToken)
        {
            return await applicationDbContext.LocalGovernments
                .Where(x => x.Id == request.Id && x.IsDeleted == false)
                .Include(x => x.State)
                .Include(x => x.State.Country)
                .ProjectTo<GetLocalGovernmentByIdResponse>(mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();
        }
    }
}