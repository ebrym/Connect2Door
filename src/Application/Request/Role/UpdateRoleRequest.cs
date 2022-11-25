using Application.Interfaces;
using Application.Response.Role;
using MediatR;

namespace Application.Request.Role
{
    public class UpdateRoleRequest : IRequest<(bool Succeed, string Message, UpdateRoleResponse Response)>, IMapFrom<Domain.User.Role>
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}