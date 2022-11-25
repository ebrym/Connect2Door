using Application.Request.NotificationReceiver;
using FluentValidation;

namespace Application.Features.NotificationReceiverFeatures.Commands
{
    /// <summary>
    ///
    /// </summary>
    public class CreateNotificationReceiverValidation : AbstractValidator<CreateNotificationReceiverRequest>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateNotificationReceiverValidation"/> class.
        /// </summary>
        public CreateNotificationReceiverValidation()
        {
            RuleFor(x => x.LocationId).NotEmpty().WithMessage("NotificationReceiver LocationId is required");
            RuleFor(x => x.NotificationActionType).NotEmpty().WithMessage("NotificationReceiver NotificationActionType is required");
        }
    }
}