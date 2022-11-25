using Application.Interfaces;
using Application.Request.NotificationReceiver;
using Application.Response.NotificationReceiver;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.NotificationReceiverFeatures.Queries
{
    /// <summary>
    ///
    /// </summary>
    public class GetNotificationReceiverByIdQuery : IRequestHandler<GetNotificationReceiverByIdRequest, GetNotificationReceiverByIdResponse>
    {
        private readonly IApplicationDbContext applicationDbContext;
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetNotificationReceiverByIdQuery"/> class.
        /// </summary>
        /// <param name="applicationDbContext">The application database context.</param>
        /// <param name="mapper">The mapper.</param>
        public GetNotificationReceiverByIdQuery(IApplicationDbContext applicationDbContext, IMapper mapper)
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
        public async Task<GetNotificationReceiverByIdResponse> Handle(GetNotificationReceiverByIdRequest request, CancellationToken cancellationToken)
        {
            return await applicationDbContext.NotificationReceivers.Where(d => d.IsDeleted == false)
                ?.ProjectTo<GetNotificationReceiverByIdResponse>(mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(x => x.Id.Equals(request.Id), cancellationToken);
        }
    }
}