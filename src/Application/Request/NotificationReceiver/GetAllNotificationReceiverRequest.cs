using Application.Response.NotificationReceiver;
using MediatR;
using System.Collections.Generic;

namespace Application.Request.NotificationReceiver
{
    /// <summary>
    ///
    /// </summary>
    /// <seealso>
    ///     <cref>MediatR.IRequest{Application.Response.Vendor.GetAllVendorResponse}</cref>
    /// </seealso>
    public class GetAllNotificationReceiverRequest : IRequest<List<GetAllNotificationReceiverResponse>>
    {
        public string LocationId { get; set; }
    }
}