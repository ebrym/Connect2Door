using Application.Response.LocalGovernment;
using MediatR;
using System.Collections.Generic;

namespace Application.Request.LocalGovernment
{
    /// <summary>
    ///
    /// </summary>
    /// <seealso>
    ///     <cref>MediatR.IRequest{Application.Response.Vendor.GetAllVendorResponse}</cref>
    /// </seealso>
    public class GetAllLocalGovernmentRequest : IRequest<List<GetAllLocalGovernmentResponse>>
    {
    }
}