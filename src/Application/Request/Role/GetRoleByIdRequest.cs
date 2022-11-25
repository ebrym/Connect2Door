using Application.Response.Role;
using MediatR;

namespace Application.Request.Role
{
    /// <summary>
    ///
    /// </summary>
    /// <seealso>
    ///     <cref>MediatR.IRequest{Application.Response.Vendor.GetAllVendorResponse}</cref>
    /// </seealso>
    public class GetRoleByIdRequest : IRequest<GetRoleByIdResponse>
    {
        public string Id { get; set; }
    }
}