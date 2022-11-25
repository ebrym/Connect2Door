using Application.Interfaces;
using Application.Request.ServiceType;
using Application.Response.ServiceType;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.ServiceTypeFeature.Queries
{
    /// <summary>
    ///
    /// </summary>
    public class GetServiceTypeByIdQuery : IRequestHandler<GetServiceTypeByIdRequest, GetServiceTypeByIdResponse>
    {
        private readonly IApplicationDbContext applicationDbContext;
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetServiceTypeByIdQuery"/> class.
        /// </summary>
        /// <param name="applicationDbContext">The application database context.</param>
        /// <param name="mapper">The mapper.</param>
        public GetServiceTypeByIdQuery(IApplicationDbContext applicationDbContext, IMapper mapper)
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
        public async Task<GetServiceTypeByIdResponse> Handle(GetServiceTypeByIdRequest request, CancellationToken cancellationToken)
        {
            return await applicationDbContext.ServiceTypes.ProjectTo<GetServiceTypeByIdResponse>(mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(x => x.Id.Equals(request.Id), cancellationToken);
        }
    }
}