using Application.Response.Unit;

using MediatR;

namespace Application.Request.Unit
{
    /// <summary>
    ///
    /// </summary>
    /// <seealso>
    ///     <cref>MediatR.IRequest{Application.Response.Vendor.GetAllVendorResponse}</cref>
    /// </seealso>
    public class GetUnitByIdRequest : IRequest<GetUnitByIdResponse>
    {
        public string Id { get; set; }
    }
}