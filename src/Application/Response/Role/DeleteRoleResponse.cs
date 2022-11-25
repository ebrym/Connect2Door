using Application.Interfaces;
using Application.Request.Role;

namespace Application.Response.Role
{
    /// <summary>
    ///
    /// </summary>
    public class DeleteRoleResponse : IMapFrom<DeleteRoleRequest>
    {
        /// <summary>
        ///
        /// </summary>
        public string Id { get; set; }
    }
}