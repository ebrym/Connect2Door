using Application.Interfaces;
using Application.Request.NotificationReceiver;
using Application.Response.NotificationReceiver;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.NotificationReceiverFeatures.Commands
{
    /// <summary>
    ///
    /// </summary>
    /// <seealso>
    ///     <cref>
    ///         MediatR.IRequestHandler{Application.Request.NotificationReceiver.CreateNotificationReceiverRequest, (System.Boolean Succeed,
    ///         System.String Message, Application.Response.NotificationReceiver.CreateNotificationReceiverResponse Response)}
    ///     </cref>
    /// </seealso>
    public class CreateNotificationReceiverCommand : IRequestHandler<CreateNotificationReceiverRequest, (bool Succeed, string Message, CreateNotificationReceiverResponse Response)>
    {
        private readonly IApplicationDbContext applicationDb;
        private readonly IMapper mapper;

        /// <summary>
        ///
        /// </summary>
        /// <param name="applicationDb"></param>
        /// <param name="mapper"></param>
        public CreateNotificationReceiverCommand(IApplicationDbContext applicationDb, IMapper mapper)
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

        public async Task<(bool Succeed, string Message, CreateNotificationReceiverResponse Response)> Handle(CreateNotificationReceiverRequest request, CancellationToken cancellationToken)
        {
            var notificationReceiver = mapper.Map<NotificationReceiver>(request);

            var notificationReceiverNameExist = await applicationDb.NotificationReceivers
                .FirstOrDefaultAsync(x => x.IsDeleted == false && x.LocationId == request.LocationId
                && x.NotificationActionType == request.NotificationActionType);
            if (notificationReceiverNameExist != null)
                return (false, "The NotificationReceiver for this location and NotificationActionType already exists", null);
            //perform insert
            notificationReceiver.DateCreated = DateTime.Now;
            await applicationDb.NotificationReceivers.AddAsync(notificationReceiver, cancellationToken);

            await applicationDb.SaveChangesAsync(cancellationToken);

            // mapper can be used here
            var response = mapper.Map<CreateNotificationReceiverResponse>(request);
            // return response object
            response.Id = notificationReceiver.Id;
            return (true, "NotificationReceiver Created Successfully", response);
        }
    }
}