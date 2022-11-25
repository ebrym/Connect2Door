using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.FeaturesNotification.Notifications;
using Domain.Common;
using Domain.User;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace Application.Features.AuthenticationFeatures.Commands
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="bool.String message)}" />
    public class ResetPasswordCommandHandler : IRequestHandler<ResetPasswordCommand, (bool succeed, string message)>
    {
        private readonly UserManager<User> userManager;
        private readonly IMediator mediator;
        private readonly ILogger<ResetPasswordCommandHandler> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="ResetPasswordCommandHandler"/> class.
        /// </summary>
        /// <param name="userManager">The user manager.</param>
        /// <param name="mediator"></param>
        /// <param name="logger"></param>
        public ResetPasswordCommandHandler(UserManager<User> userManager, IMediator mediator, ILogger<ResetPasswordCommandHandler> logger)
        {
            this.userManager = userManager;
            this.mediator = mediator;
            this.logger = logger;
        }
        /// <summary>
        /// Handles a request
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>
        /// Response from the request
        /// </returns>
        public async Task<(bool succeed, string message)> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
        {
            var rnd = new Random();
            var user = await userManager.FindByEmailAsync(request.Email);

            if (user == null)
            {
                logger.LogInformation($"User not found");
                return (false, "The cannot be found");
            }

            var resetToken = await userManager.GeneratePasswordResetTokenAsync(user);
            var password = rnd.Next(10000, 1000000);

            logger.LogInformation($"Password token generated {resetToken}");
            logger.LogInformation($"Password generated {password}");

            var passCode = await userManager.ResetPasswordAsync(user, resetToken, password.ToString());

            if (passCode.Succeeded)
            {
                // send mail
                //Notification Message
                NotificationMessage notificationMessage = new NotificationMessage
                {
                    User = user,
                    NotificationType = NotificationType.Authentication,
                    NotificationActionType = NotificationActionType.PasswordReset,
                    NewUserPassword = password.ToString()
                };
                await mediator.Publish(notificationMessage, cancellationToken);
                return (true, "Password has been successfully reset, check your email");
            }

            return (false, string.Join(" ", passCode.Errors.Select(x => x.Description)));
        }
    }
}