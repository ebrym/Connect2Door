using Application.Interfaces;

namespace Application.Response.Role
{
    public class GetRoleByIdResponse : IMapFrom<Domain.User.Role>
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}