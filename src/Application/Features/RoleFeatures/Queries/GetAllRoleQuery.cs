using Application.Interfaces;
using Application.Request.Role;
using Application.Response.Role;

using AutoMapper;
using Domain.User;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.RoleFeatures.Queries
{
    /// <summary>
    ///
    /// </summary>
    public class GetAllRoleQuery : IRequestHandler<GetAllRoleRequest, List<GetAllRoleResponse>>
    {
        private readonly IApplicationDbContext context;
        private readonly IMapper mapper;
        private readonly RoleManager<Role> roleManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllRoleQuery"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public GetAllRoleQuery(IApplicationDbContext context, IMapper mapper, RoleManager<Role> roleManager)
        {
            this.context = context;
            this.mapper = mapper;
            this.roleManager = roleManager;
        }

        /// <summary>
        /// Handles a request
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>
        /// Response from the request
        /// </returns>
        public async Task<List<GetAllRoleResponse>> Handle(GetAllRoleRequest request, CancellationToken cancellationToken)
        {
            return await roleManager.Roles.Where(d => d.IsDeleted == false)
                .OrderByDescending(a => a.DateCreated)
                .Select(a => new GetAllRoleResponse
                {
                    Name = a.Name,
                    Id = a.Id
                })
                .ToListAsync(cancellationToken);
        }
    }
}