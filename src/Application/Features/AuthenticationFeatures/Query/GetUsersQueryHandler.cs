using Application.Interfaces;
using Application.Request.User;
using Application.Response.User;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.AuthenticationFeatures.Query
{
    /// <summary>
    ///
    /// </summary>
    /// <seealso cref="MediatR.IRequestHandler{GetUsersRequest, CreateUserResponse[]}" />
    public class GetUsersQueryHandler : IRequestHandler<GetUsersRequest, CreateUserResponse[]>
    {

        private readonly IApplicationDbContext applicationDbContext;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="applicationDbContext"></param>
        public GetUsersQueryHandler(IApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        /// <summary>
        /// Handles a request
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>
        /// Response from the request
        /// </returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public async Task<CreateUserResponse[]> Handle(GetUsersRequest request, CancellationToken cancellationToken)
        {
            var user = (from u in applicationDbContext.Users
                        join e in applicationDbContext.Employees on u.Id equals e.UserId into employee
                        from emp in employee.DefaultIfEmpty()
                        where !u.IsDeleted
                        orderby u.DateDeleted descending
                        select new CreateUserResponse
                        {
                            Id = u.Id,
                            Email = u.Email,
                            FullName = $"{u.FullName} -> ({u.Email})",
                            Phone = u.PhoneNumber,
                            UserName = u.UserName,
                            Roles = (from ur in applicationDbContext.UserRoles
                                     join r in applicationDbContext.Roles on ur.RoleId equals r.Id
                                     where ur.UserId == u.Id
                                     select r.Name
                                ).ToArray(),
                        });



            return await user.ToArrayAsync(cancellationToken: cancellationToken);
        }
    }
}