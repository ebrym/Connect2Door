using Application.Interfaces;
using Application.Request.Employee;
using Application.Response.Employee;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.EmployeeFeature.Commands
{
    /// <summary>
    ///
    /// </summary>
    public class DeleteEmployeeCommand : IRequestHandler<DeleteEmployeeRequest, (bool Succeed, string Message, DeleteEmployeeResponse Response)>
    {
        private readonly IApplicationDbContext applicationDb;
        private readonly IMapper mapper;

        /// <summary>
        ///
        /// </summary>
        /// <param name="applicationDb"></param>
        /// <param name="mapper"></param>
        public DeleteEmployeeCommand(IApplicationDbContext applicationDb, IMapper mapper)
        {
            this.applicationDb = applicationDb;
            this.mapper = mapper;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>

        public async Task<(bool Succeed, string Message, DeleteEmployeeResponse Response)> Handle(DeleteEmployeeRequest request, CancellationToken cancellationToken)
        {
            var employee = await applicationDb.Employees.Where(u => u.Id == request.Id)
                .FirstOrDefaultAsync(cancellationToken: cancellationToken);

            employee.IsDeleted = true;
            applicationDb.Employees.Update(employee);

            int saved = await applicationDb.SaveChangesAsync(cancellationToken);

            // mapper can be used here
            var response = new DeleteEmployeeResponse();
            // return response object
            response.Id = employee.Id;

            if (saved > 0)
            {
                return (true, "Employee Deleted successfully", response);
            }
            return (false, "There was a problem deleting the specified Employee.", response);
        }
    }
}