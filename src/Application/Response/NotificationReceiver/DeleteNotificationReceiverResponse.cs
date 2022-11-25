using Application.Interfaces;
using Application.Request.NotificationReceiver;

namespace Application.Response.NotificationReceiver
{
    /// <summary>
    ///
    /// </summary>
    public class DeleteNotificationReceiverResponse : IMapFrom<CreateNotificationReceiverRequest>
    {
        /// <summary>
        ///
        /// </summary>
        public string Id { get; set; }
    }
}