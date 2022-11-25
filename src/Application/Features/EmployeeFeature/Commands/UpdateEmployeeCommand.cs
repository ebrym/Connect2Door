using Application.Interfaces;
using Application.Request.Employee;
using Application.Response.Employee;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.EmployeeFeature.Commands
{
    /// <summary>
    ///
    /// </summary>
    public class UpdateEmployeeCommand : IRequestHandler<UpdateEmployeeRequest, (bool Succeed, string Message, UpdateEmployeeResponse Response)>
    {
        private readonly IApplicationDbContext applicationDb;
        private readonly IMapper mapper;

        /// <summary>
        ///
        /// </summary>
        /// <param name="applicationDb"></param>
        /// <param name="mapper"></param>
        public UpdateEmployeeCommand(IApplicationDbContext applicationDb, IMapper mapper)
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

        public async Task<(bool Succeed, string Message, UpdateEmployeeResponse Response)> Handle(UpdateEmployeeRequest request, CancellationToken cancellationToken)
        {
            var employee = mapper.Map<Employee>(request);

            var entity = await applicationDb.Employees.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            if (entity != null && entity.Id == employee.Id)
            {
                if (entity.StaffId != employee.StaffId)
                {
                    var employeeStaffIdExist = await applicationDb.Employees.FirstOrDefaultAsync(x => x.StaffId.Equals(request.StaffId), cancellationToken);
                    if (employeeStaffIdExist != null)
                        return (false, $"This Employee with the staff id: {employeeStaffIdExist.StaffId} already exist", null);
                }
                if (entity.Email != employee.Email)
                {
                    var employeeEmailExist = await applicationDb.Employees.FirstOrDefaultAsync(x => x.Email.Equals(request.Email), cancellationToken);
                    if (employeeEmailExist != null)
                        return (false, $"This Employee with the email address: {employeeEmailExist.Email} already exist", null);
                }

                //entity = Employee;
                //entity.ModifiedBy = "Test";
                //entity.DateModified = DateTime.Now;
                //applicationDb.Employees.Update(entity);
                entity.LastName = employee.LastName;
                entity.FirstName = employee.FirstName;
                entity.Email = employee.Email;
                entity.UnitId = employee.UnitId;
                entity.Designation = employee.Designation;
                entity.PhoneNo = employee.PhoneNo;
                entity.UserId = employee.UserId;
                entity.Address = employee.Address;
                entity.Status = employee.Status;
                entity.Picture = employee.Picture;
                // entity.ModifiedBy = "Test";
                entity.DateModified = DateTime.Now;
                await applicationDb.SaveChangesAsync(cancellationToken);
            }
            else
            {
                return (false, "The Employee can not be updated because it does not exist", null);
            }

            // mapper can be used here
            var response = mapper.Map<UpdateEmployeeResponse>(request);
            response.Id = employee.Id;
            // return response object
            return (true, "Employee updated successfully", response);
        }
    }
}