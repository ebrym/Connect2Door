using Application.Interfaces;
using Application.Request.Country;
using Application.Response.Country;
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

    public class GetCountryByIdQuerry : IRequestHandler<GetCountryByIdRequest, GetCountryByIdResponse>
    {
        private readonly IApplicationDbContext applicationDbContext;
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetUnitByIdQuerry"/> class.
        /// </summary>
        /// <param name="applicationDbContext">The application database context.</param>
        /// <param name="mapper">The mapper.</param>
        public GetCountryByIdQuerry(IApplicationDbContext applicationDbContext, IMapper mapper)
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
        public async Task<GetCountryByIdResponse> Handle(GetCountryByIdRequest request, CancellationToken cancellationToken)
        {
            return await applicationDbContext.Countries.Where(x => x.Id == request.Id && x.IsDeleted == false).ProjectTo<GetCountryByIdResponse>(mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();
        }
    }
}