using Application.Interfaces;
using Application.Request.Company;
using Application.Response.Company;
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

    public class GetCompanyByIdQuerry : IRequestHandler<GetCompanyByIdRequest, GetCompanyByIdResponse>
    {
        private readonly IApplicationDbContext applicationDbContext;
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetUnitByIdQuerry"/> class.
        /// </summary>
        /// <param name="applicationDbContext">The application database context.</param>
        /// <param name="mapper">The mapper.</param>
        public GetCompanyByIdQuerry(IApplicationDbContext applicationDbContext, IMapper mapper)
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
        public async Task<GetCompanyByIdResponse> Handle(GetCompanyByIdRequest request, CancellationToken cancellationToken)
        {
            return await applicationDbContext.Companies
                .Where(x => x.Id == request.Id && x.IsDeleted == false)
                .Include(x => x.State)
                .Include(x => x.Country)
                .ProjectTo<GetCompanyByIdResponse>(mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();
        }
    }
}