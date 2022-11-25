using Application.Interfaces;
using Application.Request.Role;

namespace Application.Response.Role
{
    public class UpdateRoleResponse : IMapFrom<UpdateRoleRequest>
    {
        public string Id { get; set; }
    }
}