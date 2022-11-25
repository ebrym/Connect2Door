using Application.Response.LocalGovernment;

using MediatR;

namespace Application.Request.LocalGovernment
{
    /// <summary>
    ///
    /// </summary>
    /// <seealso>
    ///     <cref>MediatR.IRequest{Application.Response.Vendor.GetAllVendorResponse}</cref>
    /// </seealso>
    public class GetLocalGovernmentByIdRequest : IRequest<GetLocalGovernmentByIdResponse>
    {
        public string Id { get; set; }
    }
}