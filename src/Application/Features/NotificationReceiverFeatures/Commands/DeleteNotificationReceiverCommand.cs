using Application.Interfaces;
using Application.Request.NotificationReceiver;
using Application.Response.NotificationReceiver;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.NotificationReceiverFeatures.Commands
{
    /// <summary>
    ///
    /// </summary>
    public class DeleteNotificationReceiverCommand : IRequestHandler<DeleteNotificationReceiverRequest, (bool Succeed, string Message, DeleteNotificationReceiverResponse Response)>
    {
        private readonly IApplicationDbContext applicationDb;
        private readonly IMapper mapper;

        /// <summary>
        ///
        /// </summary>
        /// <param name="applicationDb"></param>
        /// <param name="mapper"></param>
        public DeleteNotificationReceiverCommand(IApplicationDbContext applicationDb, IMapper mapper)
        {
            this.applicationDb = applicationDb;
            this.mapper = mapper;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>

        public async Task<(bool Succeed, string Message, DeleteNotificationReceiverResponse Response)> Handle(DeleteNotificationReceiverRequest request, CancellationToken cancellationToken)
        {
            var notificationReceiver = await applicationDb.NotificationReceivers.Where(u => u.Id == request.Id)
                .FirstOrDefaultAsync(cancellationToken: cancellationToken);

            notificationReceiver.IsDeleted = true;
            applicationDb.NotificationReceivers.Update(notificationReceiver);

            int saved = await applicationDb.SaveChangesAsync(cancellationToken);

            // mapper can be used here
            var response = new DeleteNotificationReceiverResponse();
            // return response object
            response.Id = notificationReceiver.Id;

            if (saved > 0)
            {
                return (true, "NotificationReceiver Deleted successfully", response);
            }
            return (false, "There was a problem deleting the specified NotificationReceiver.", response);
        }
    }
}