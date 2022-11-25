﻿using Application.Interfaces;
using Application.Request.NotificationReceiver;
using Domain.Common;

namespace Application.Response.NotificationReceiver
{
    /// <summary>
    ///
    /// </summary>
    public class CreateNotificationReceiverResponse : IMapFrom<CreateNotificationReceiverRequest>
    {
        public string Id { get; set; }

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