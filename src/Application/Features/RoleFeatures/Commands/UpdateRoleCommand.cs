namespace Application.Features.RoleFeatures.Commands
{
    //// <summary>
    ////
    //// </summary>
    //public class UpdateRoleCommand : IRequestHandler<UpdateRoleRequest, (bool Succeed, string Message, UpdateRoleResponse Response)>
    //{
    //    private readonly IApplicationDbContext applicationDb;
    //    private readonly IMapper mapper;
    //    private readonly RoleManager<Role> roleManager;
    //    /// <summary>
    //    ///
    //    /// </summary>
    //    /// /// <param name="roleManager"></param>
    //    /// <param name="applicationDb"></param>
    //    /// <param name="mapper"></param>
    //    public UpdateRoleCommand(IApplicationDbContext applicationDb, IMapper mapper, RoleManager<Role> roleManager)
    //    {
    //        this.applicationDb = applicationDb;
    //        this.mapper = mapper;
    //        this.roleManager = roleManager;

    //    }

    //    /// <summary>
    //    ///
    //    /// </summary>
    //    /// <param name="request"></param>
    //    /// <param name="cancellationToken"></param>
    //    /// <returns></returns>

    //    public async Task<(bool Succeed, string Message, UpdateRoleResponse Response)> Handle(UpdateRoleRequest request, CancellationToken cancellationToken)
    //    {
    //        var role = mapper.Map<Role>(request);
    //        var roleNameExist = await roleManager.Roles.FirstOrDefaultAsync(x => x.Name.Equals(request.Name), cancellationToken); ;
    //        var entity = await applicationDb.Ministries.FindAsync(role.Id);
    //        if (entity.Id == role.Id)
    //        {
    //            entity.Name = role.Name;

    //            await applicationDb.SaveChangesAsync();
    //        }
    //        else
    //        {
    //            return (false, "The Role does not exist", null);
    //        }

    //        // mapper can be used here
    //        var response = mapper.Map<UpdateRoleResponse>(request);
    //        response.Id = role.Id;
    //        // return response object
    //        return (true, "Role Updated successfully", response);
    //    }
    //}
}