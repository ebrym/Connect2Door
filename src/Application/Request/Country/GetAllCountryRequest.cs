using Application.Response.Country;
using MediatR;
using System.Collections.Generic;

namespace Application.Request.Country
{
    /// <summary>
    ///
    /// </summary>
    /// <seealso>
    ///     <cref>MediatR.IRequest{Application.Response.Vendor.GetAllVendorResponse}</cref>
    /// </seealso>
    public class GetAllCountryRequest : IRequest<List<GetAllCountryResponse>>
    {
    }
}