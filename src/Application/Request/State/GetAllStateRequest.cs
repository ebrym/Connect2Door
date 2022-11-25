using Application.Response.State;
using MediatR;
using System.Collections.Generic;

namespace Application.Request.State
{
    /// <summary>
    ///
    /// </summary>
    /// <seealso>
    ///     <cref>MediatR.IRequest{Application.Response.Vendor.GetAllVendorResponse}</cref>
    /// </seealso>
    public class GetAllStateRequest : IRequest<List<GetAllStateResponse>>
    {
    }
}