using Application.FeaturesNotification.NotificationGenerators;
using Application.FeaturesNotification.Notifications;
using Application.FeaturesNotification.Utilities;
using Application.Interfaces;
using Domain.Common;
using Domain.User;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.Threading;
using System.Threading.Tasks;

namespace Application.FeaturesNotification.NotificationHandlers
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso>
    ///     <cref>MediatR.INotificationHandler{Application.FeaturesNotification.Notifications.NotificationMessage}</cref>
    /// </seealso>
    public class UserActionsNotificationMessageHandler : INotificationHandler<NotificationMessage>
    {
        private readonly IApplicationDbContext applicationDbContext;
        private readonly IMediator mediator;
        private readonly RoleManager<Role> roleManager;
        private readonly IOptionsSnapshot<AssetURLS> assetUrls;
        private readonly UserManager<User> userManager;
        /// <summary>
        /// Initializes a new instance of the <see cref="UserActionsNotificationMessageHandler"/> class.
        /// </summary>
        /// <param name="applicationDbContext">The application database context.</param>
        /// <param name="mediator">The mediator.</param>
        /// <param name="roleManager">The role manager.</param>
        /// <param name="assetURLS">The asset urls.</param>
        /// <param name="userManager">The user manager.</param>
        public UserActionsNotificationMessageHandler(IApplicationDbContext applicationDbContext, IMediator mediator, RoleManager<Role> roleManager, IOptionsSnapshot<AssetURLS> assetURLS, UserManager<User> userManager)
        {
            this.applicationDbContext = applicationDbContext;
            this.mediator = mediator;
            this.roleManager = roleManager;
            this.assetUrls = assetURLS;
            this.userManager = userManager;
        }
        /// <summary>
        /// Handles a notification
        /// </summary>
        /// <param name="notification">The notification</param>
        /// <param name="cancellationToken">Cancellation token</param>
        public async Task Handle(NotificationMessage notification, CancellationToken cancellationToken)
        {
            GenerateEmail generateEmail = new GenerateEmail(applicationDbContext, mediator, roleManager, assetUrls, userManager);

            if (notification.NotificationActionType == NotificationActionType.UserCreated)
            {
                bool generated = await generateEmail.UserCreated(notification);
            }
        }
    }
}