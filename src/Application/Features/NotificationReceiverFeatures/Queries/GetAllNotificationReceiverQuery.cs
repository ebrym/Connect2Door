using Application.Interfaces;
using Application.Request.NotificationReceiver;
using Application.Response.NotificationReceiver;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.NotificationReceiverFeatures.Queries
{
    /// <summary>
    ///
    /// </summary>
    /// <seealso>
    ///     <cref>
    ///         MediatR.IRequestHandler{Application.Request.NotificationReceiver.GetAllNotificationReceiverRequest,
    ///         System.Collections.Generic.List{Application.Response.NotificationReceiver.GetAllNotificationReceiverResponse}}
    ///     </cref>
    /// </seealso>
    public class GetAllNotificationReceiverQuery : IRequestHandler<GetAllNotificationReceiverRequest, List<GetAllNotificationReceiverResponse>>
    {
        private readonly IApplicationDbContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllNotificationReceiverQuery"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public GetAllNotificationReceiverQuery(IApplicationDbContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Handles a request
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>
        /// Response from the request
        /// </returns>
        public async Task<List<GetAllNotificationReceiverResponse>> Handle(GetAllNotificationReceiverRequest request, CancellationToken cancellationToken)
        {
            var query = context.NotificationReceivers.Where(d => d.IsDeleted == false);

            if (!string.IsNullOrWhiteSpace(request.LocationId))
            {
                query = query.Where(d => d.LocationId == request.LocationId);
            }

            return await query.OrderByDescending(a => a.DateCreated)
                .Select(a => new GetAllNotificationReceiverResponse
                {
                    Id = a.Id,
                    NotificationActionType = a.NotificationActionType,
                    Roles = a.Roles,
                    UserEmails = a.UserEmails,
                    NotificationActionName = a.NotificationActionType.ToString()
                })
                .ToListAsync(cancellationToken);
        }
    }
}