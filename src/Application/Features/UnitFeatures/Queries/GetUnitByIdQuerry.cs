using Application.Interfaces;
using Application.Request.Unit;
using Application.Response.Unit;
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

    public class GetUnitByIdQuerry : IRequestHandler<GetUnitByIdRequest, GetUnitByIdResponse>
    {
        private readonly IApplicationDbContext applicationDbContext;
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetUnitByIdQuerry"/> class.
        /// </summary>
        /// <param name="applicationDbContext">The application database context.</param>
        /// <param name="mapper">The mapper.</param>
        public GetUnitByIdQuerry(IApplicationDbContext applicationDbContext, IMapper mapper)
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
        public async Task<GetUnitByIdResponse> Handle(GetUnitByIdRequest request, CancellationToken cancellationToken)
        {
            return await applicationDbContext.Units.Where(x => x.Id == request.Id && x.IsDeleted == false).ProjectTo<GetUnitByIdResponse>(mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();
        }
    }
}