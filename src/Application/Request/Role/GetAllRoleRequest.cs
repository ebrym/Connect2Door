using Application.Response.Role;
using MediatR;
using System.Collections.Generic;

namespace Application.Request.Role
{
    /// <summary>
    ///
    /// </summary>
    /// <seealso>
    ///     <cref>MediatR.IRequest{Application.Response.Vendor.GetAllVendorResponse}</cref>
    /// </seealso>
    public class GetAllRoleRequest : IRequest<List<GetAllRoleResponse>>
    {
    }
}