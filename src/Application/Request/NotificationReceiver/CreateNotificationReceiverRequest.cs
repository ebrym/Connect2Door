using Application.Interfaces;
using Application.Response.NotificationReceiver;
using Domain.Common;
using MediatR;

namespace Application.Request.NotificationReceiver
{
    /// <summary>
    /// 1.Name (unique)
    /// 2.Website
    /// 3.Description
    /// 4.Email
    /// 5.PhoneNo
    /// 6.ContactPerson
    /// 7. Status(True or false)
    /// </summary>
    /// <seealso>
    ///     <cref>
    ///         MediatR.IRequest{(System.Boolean Succeed, System.String Message,
    ///         Application.Response.NotificationReceiver.CreateNotificationReceiverResponse Response)}
    ///     </cref>
    /// </seealso>
    /// <seealso>
    ///     <cref>Application.Interfaces.IMapFrom{Domain.Entities.NotificationReceiver}</cref>
    /// </seealso>
    public class CreateNotificationReceiverRequest : IRequest<(bool Succeed, string Message, CreateNotificationReceiverResponse Response)>, IMapFrom<Domain.Entities.NotificationReceiver>
    {
        /// <summary>
        /// Gets or sets the roles.
        /// </summary>
        /// <value>
        /// The roles.
        /// </value>
        public string Roles { get; set; }

        /// <summary>
        /// Gets or sets the user emails.
        /// </summary>
        /// <value>
        /// The user emails.
        /// </value>
        public string UserEmails { get; set; }

        /// <summary>
        /// Gets or sets the location identifier.
        /// </summary>
        /// <value>
        /// The location identifier.
        /// </value>
        public string LocationId { get; set; }

        // public NotificationType NotificationType { get; set; }
        /// <summary>
        /// Gets or sets the type of the notification action.
        /// </summary>
        /// <value>
        /// The type of the notification action.
        /// </value>
        public NotificationActionType NotificationActionType { get; set; }
    }
}