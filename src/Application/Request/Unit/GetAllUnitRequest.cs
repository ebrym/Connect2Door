using Application.Response.Unit;
using MediatR;
using System.Collections.Generic;

namespace Application.Request.Unit
{
    /// <summary>
    ///
    /// </summary>
    /// <seealso>
    ///     <cref>MediatR.IRequest{Application.Response.Vendor.GetAllVendorResponse}</cref>
    /// </seealso>
    public class GetAllUnitRequest : IRequest<List<GetAllUnitResponse>>
    {
    }
}