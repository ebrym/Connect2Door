using Application.Interfaces;
using Application.Request.Role;
using Application.Response.Role;
using AutoMapper;
using Domain.User;
using MediatR;
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
    public class CreateRoleCommand : IRequestHandler<CreateRoleRequest, (bool Succeed, string Message, CreateRoleResponse Response)>
    {
        private readonly IApplicationDbContext applicationDb;
        private readonly IMapper mapper;

        // private readonly GetRoleByNameQuery roleManager;

        private readonly RoleManager<Role> roleManager;

        /// <summary>
        ///
        /// </summary>
        /// <param name="applicationDb"></param>
        /// <param name="mapper"></param>
        /// <param name="roleManager"></param>

        public CreateRoleCommand(IApplicationDbContext applicationDb, IMapper mapper/*,GetRoleByNameQuery roleManager*/, RoleManager<Role> roleManager)
        {
            this.applicationDb = applicationDb;
            this.mapper = mapper;
            this.roleManager = roleManager;
            //this.roleManager2 = roleManager2;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>

        public async Task<(bool Succeed, string Message, CreateRoleResponse Response)> Handle(CreateRoleRequest request, CancellationToken cancellationToken)
        {
            var role = mapper.Map<Role>(request);

            var roleNameExist = await roleManager.Roles.FirstOrDefaultAsync(x => x.Name.Equals(request.Name), cancellationToken); ;
            if (roleNameExist != null)
                return (false, "A Role with this name has already been created", null);
            //perform insert
            //role.CreatedBy = "System";
            await roleManager.CreateAsync(role);

            // mapper can be used here
            var response = mapper.Map<CreateRoleResponse>(request);
            // return response object
            response.Id = role.Id;
            return (true, "Role Created successfully", response);
        }
    }
}