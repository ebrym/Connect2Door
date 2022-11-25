using Application.Response.NotificationReceiver;
using MediatR;

namespace Application.Request.NotificationReceiver
{
    /// <summary>
    ///
    /// </summary>
    /// <seealso>
    ///     <cref>MediatR.IRequest{Application.Response.Vendor.GetAllVendorResponse}</cref>
    /// </seealso>
    public class GetNotificationReceiverByIdRequest : IRequest<GetNotificationReceiverByIdResponse>
    {
        public string Id { get; set; }
    }
}