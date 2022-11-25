using Application.Interfaces;
using Application.Request.Role;

namespace Application.Response.Role
{
    /// <summary>
    ///
    /// </summary>
    public class CreateRoleResponse : IMapFrom<CreateRoleRequest>
    {
        /// <summary>
        ///
        /// </summary>
        public string Id { get; set; }
    }
}