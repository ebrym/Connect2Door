using Application.Interfaces;
using Application.Request.Employee;
using Application.Response.Employee;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.EmployeeFeature.Queries
{
    /// <summary>
    ///
    /// </summary>
    public class GetAllEmployeeQuery : IRequestHandler<GetAllEmployeeRequest, List<GetAllEmployeeResponse>>
    {
        private readonly IApplicationDbContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllEmployeeQuery"/> class.
        /// </summary>
        /// <param name="context">The context.</param>

        public GetAllEmployeeQuery(IApplicationDbContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Handles a request
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>
        /// Response from the request
        /// </returns>
        public async Task<List<GetAllEmployeeResponse>> Handle(GetAllEmployeeRequest request, CancellationToken cancellationToken)
        {
            var query = await (from employee in context.Employees
                               where employee.IsDeleted == false
                               join country in context.Countries on employee.CountryId equals country.Id
                               join state in context.States on employee.StateId equals state.Id
                               join localGovernment in context.LocalGovernments on employee.LocalGovernmentId equals localGovernment.Id
                               orderby employee.DateCreated descending
                               select new GetAllEmployeeResponse
                               {
                                   Address = employee.Address,
                                   Designation = employee.Designation,
                                   Email = employee.Email,
                                   FirstName = employee.FirstName,
                                   FullName = $"{employee.FirstName} {employee.LastName} ({employee.StaffId})",
                                   LastName = employee.LastName,
                                   Id = employee.Id,
                                   StaffId = employee.StaffId,
                                   PhoneNo = employee.PhoneNo,
                                   Country = country,
                                   State = state,
                                   LocalGovernment = localGovernment
                               }).ToListAsync(cancellationToken: cancellationToken);

            return query;
        }
    }
}