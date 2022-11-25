using Application.Interfaces;
using Application.Response.NotificationReceiver;
using MediatR;

namespace Application.Request.NotificationReceiver
{
    /// <summary>
    /// 1.Name (unique)
    ///2.Website
    ///3.Description
    ///4.Email
    ///5.PhoneNo
    ///6.ContactPerson
    ///7. Status(True or false)
    /// </summary>
    ///     public class CreateVendorRequest :  IRequest<(bool Succeed, string Message, CreateMinistryResponse Response)>, IMapFrom<Domain.Entities.Vendor>

    public class DeleteNotificationReceiverRequest : IRequest<(bool Succeed, string Message, DeleteNotificationReceiverResponse Response)>, IMapFrom<Domain.Entities.NotificationReceiver>
    {
        /// <summary>
        ///
        /// </summary>
        public string Id { get; set; }
    }
}