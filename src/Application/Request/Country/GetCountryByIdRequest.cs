using Application.Response.Country;

using MediatR;

namespace Application.Request.Country
{
    /// <summary>
    ///
    /// </summary>
    /// <seealso>
    ///     <cref>MediatR.IRequest{Application.Response.Vendor.GetAllVendorResponse}</cref>
    /// </seealso>
    public class GetCountryByIdRequest : IRequest<GetCountryByIdResponse>
    {
        public string Id { get; set; }
    }
}