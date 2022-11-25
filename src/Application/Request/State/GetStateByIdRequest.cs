using Application.Response.State;

using MediatR;

namespace Application.Request.State
{
    /// <summary>
    ///
    /// </summary>
    /// <seealso>
    ///     <cref>MediatR.IRequest{Application.Response.Vendor.GetAllVendorResponse}</cref>
    /// </seealso>
    public class GetStateByIdRequest : IRequest<GetStateByIdResponse>
    {
        public string Id { get; set; }
    }
}