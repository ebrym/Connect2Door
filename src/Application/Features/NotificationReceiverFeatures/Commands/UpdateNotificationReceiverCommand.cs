using Application.Interfaces;
using Application.Request.NotificationReceiver;
using Application.Response.NotificationReceiver;
using AutoMapper;
using Domain.Entities;
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
    /// <seealso>
    ///     <cref>
    ///         MediatR.IRequestHandler{Application.Request.NotificationReceiver.UpdateNotificationReceiverRequest, (System.Boolean Succeed,
    ///         System.String Message, Application.Response.NotificationReceiver.UpdateNotificationReceiverResponse Response)}
    ///     </cref>
    /// </seealso>
    public class UpdateNotificationReceiverCommand : IRequestHandler<UpdateNotificationReceiverRequest, (bool Succeed, string Message, UpdateNotificationReceiverResponse Response)>
    {
        private readonly IApplicationDbContext applicationDb;
        private readonly IMapper mapper;

        /// <summary>
        ///
        /// </summary>
        /// <param name="applicationDb"></param>
        /// <param name="mapper"></param>
        public UpdateNotificationReceiverCommand(IApplicationDbContext applicationDb, IMapper mapper)
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

        public async Task<(bool Succeed, string Message, UpdateNotificationReceiverResponse Response)> Handle(UpdateNotificationReceiverRequest request, CancellationToken cancellationToken)
        {
            // mapper can be used here
            var response = mapper.Map<UpdateNotificationReceiverResponse>(request);
            try
            {
                var notificationReceiver = mapper.Map<NotificationReceiver>(request);

                var entity = await applicationDb.NotificationReceivers.Where(a => a.Id == request.Id).AsNoTracking().FirstOrDefaultAsync();

                if (entity == null)
                {
                    return (false, "The NotificationReceiver does not exist", null);
                }

                applicationDb.NotificationReceivers.Update(notificationReceiver);
                var saved = await applicationDb.SaveChangesAsync(cancellationToken);

                if (saved <= 0)
                {
                    return (false, "The UserRoleLocationMapping was not updated.", null);
                }
                response.Id = notificationReceiver.Id;
            }
            catch (Exception ex)
            { }

            // return response object
            return (true, "NotificationReceiver updated successfully", response);
        }
    }
}