using Application.Interfaces;

namespace Application.Response.Role
{
    public class GetAllRoleResponse : IMapFrom<Domain.User.Role>
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}