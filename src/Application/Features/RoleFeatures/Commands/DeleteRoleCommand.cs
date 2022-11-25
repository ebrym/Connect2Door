using Application.Interfaces;
using Application.Request.Role;
using Application.Response.Role;
using AutoMapper;
using Domain.User;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.RoleFeatures.Commands
{
    /// <summary>
    ///
    /// </summary>
    public class DeleteRoleCommand : IRequestHandler<DeleteRoleRequest, (bool Succeed, string Message, DeleteRoleResponse Response)>
    {
        private readonly IApplicationDbContext applicationDb;
        private readonly IMapper mapper;
        private readonly IHttpContextAccessor contextAccessor;
        // private readonly GetRoleByNameQuery roleManager;

        private readonly RoleManager<Role> roleManager;

        /// <summary>
        ///
        /// </summary>
        /// <param name="applicationDb"></param>
        /// <param name="mapper"></param>
        /// <param name="roleManager"></param>

        public DeleteRoleCommand(IApplicationDbContext applicationDb, IMapper mapper/*,GetRoleByNameQuery roleManager*/, RoleManager<Role> roleManager, IHttpContextAccessor contextAccessor)
        {
            this.applicationDb = applicationDb;
            this.mapper = mapper;
            this.roleManager = roleManager;
            //this.roleManager2 = roleManager2;
            this.contextAccessor = contextAccessor;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>

        public async Task<(bool Succeed, string Message, DeleteRoleResponse Response)> Handle(DeleteRoleRequest request, CancellationToken cancellationToken)
        {
            var role = mapper.Map<Role>(request);

            var roleNameExist = await roleManager.Roles.FirstOrDefaultAsync(x => x.Name.Equals(request.Name), cancellationToken); ;
            if (roleNameExist == null)
                return (false, "The specified role does not exist", null);
            //perform insert
            roleNameExist.IsDeleted = true;
            roleNameExist.DateDeleted = DateTimeOffset.Now;
            roleNameExist.DeletedBy = contextAccessor?.HttpContext?.User?.Identity?.Name;
            await roleManager.UpdateAsync(roleNameExist);

            // mapper can be used here
            var response = mapper.Map<DeleteRoleResponse>(request);
            // return response object
            response.Id = role.Id;
            return (true, "Role Deleted successfully", response);
        }
    }
}