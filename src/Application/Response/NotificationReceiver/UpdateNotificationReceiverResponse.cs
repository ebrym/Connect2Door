using Application.Interfaces;
using Application.Request.NotificationReceiver;

namespace Application.Response.NotificationReceiver
{
    public class UpdateNotificationReceiverResponse : IMapFrom<UpdateNotificationReceiverRequest>
    {
        public string Id { get; set; }
    }
}