using Application.Interfaces;
using Application.Response.Role;
using MediatR;

namespace Application.Request.Role
{
    /// <summary>
    /// 1.Name (unique)
    ///2.Website
    ///3.Description
    ///4.Email
    ///5.PhoneNo
    ///6.ContactPerson
    ///7. Status(True or false)
    /// </summary>
    ///     public class DeleteVendorRequest :  IRequest<(bool Succeed, string Message, DeleteMinistryResponse Response)>, IMapFrom<Domain.Entities.Vendor>

    public class DeleteRoleRequest : IRequest<(bool Succeed, string Message, DeleteRoleResponse Response)>, IMapFrom<Domain.User.Role>
    {
        /// <summary>
        ///
        /// </summary>
        public string Name { get; set; }
    }
}