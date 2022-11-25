
using Application.FeaturesNotification.Notifications;
using Application.Interfaces;
using Application.Request.Employee;
using Application.Response.Employee;
using AutoMapper;
using Domain.Common;
using Domain.Entities;
using Domain.User;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.EmployeeFeature.Commands
{
    /// <summary>
    ///
    /// </summary>
    public class CreateEmployeeCommand : IRequestHandler<CreateEmployeeRequest, (bool Succeed, string Message, CreateEmployeeResponse Response)>
    {
        private readonly IApplicationDbContext applicationDb;
        private readonly IMapper mapper;
        private readonly IMediator mediator;
        private readonly UserManager<User> userManager;
        private readonly RoleManager<Role> roleManager;
        private readonly IHttpContextAccessor contextAccessor;

        /// <summary>
        ///
        /// </summary>
        /// <param name="applicationDb"></param>
        /// <param name="mapper"></param>
        /// <param name="mediator"></param>
        /// <param name="userManager"></param>
        /// <param name="roleManager"></param>
        /// <param name="contextAccessor"></param>
        /// <param name="WorkflowApprovalSettings"></param>
        public CreateEmployeeCommand(IApplicationDbContext applicationDb, IMapper mapper, IMediator mediator, UserManager<User> userManager,
            RoleManager<Role> roleManager, IHttpContextAccessor contextAccessor)
        {
            this.applicationDb = applicationDb;
            this.mapper = mapper;
            this.mediator = mediator;
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.contextAccessor = contextAccessor;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>

        public async Task<(bool Succeed, string Message, CreateEmployeeResponse Response)> Handle(CreateEmployeeRequest request, CancellationToken cancellationToken)
        {
            var employee = mapper.Map<Employee>(request);
            var employeeStaffIdExist = await applicationDb.Employees.FirstOrDefaultAsync(x => x.StaffId.Equals(request.StaffId), cancellationToken);
            if (employeeStaffIdExist != null)
                return (false, $"This Employee with the staff id: {employeeStaffIdExist.StaffId} has already been created", null);

            var employeeEmailExist = await applicationDb.Employees.FirstOrDefaultAsync(x => x.Email.Equals(request.Email), cancellationToken);
            if (employeeEmailExist != null)
                return (false, $"This Employee with the email address: {employeeEmailExist.Email} has already been created", null);

            //perform insert
            employee.DateCreated = DateTimeOffset.Now;
            employee.DateModified = DateTime.Now;
            employee.CreatedBy = "Test";
            employee.Status = true;

            await applicationDb.Employees.AddAsync(employee, cancellationToken);

            await applicationDb.SaveChangesAsync(cancellationToken);
            //create user for new employee
            var currentUser = contextAccessor?.HttpContext?.User?.Identity?.Name;
            var user = new User
            {
                Email = request.Email,
                UserName = request.Email,
                PhoneNumber = request.PhoneNo,
                FullName = $"{ request.FirstName} {request.LastName}",
                CreatedBy = currentUser,
                DateCreated = DateTime.Now
            };

            var userCreated = await userManager.CreateAsync(user);
           
            
           
            //end
            // mapper can be used here
            var response = mapper.Map<CreateEmployeeResponse>(request);
            // return response object
            response.Id = employee.Id;
            //Notification Message
            NotificationMessage notificationMessage = new NotificationMessage();
            notificationMessage.MainEntity = employee;
            notificationMessage.NotificationType = NotificationType.Configuration;
            notificationMessage.NotificationActionType = NotificationActionType.EmployeeCreated;
            //add location to message
            
            //end
            await mediator.Publish(notificationMessage, cancellationToken);
            //end
            //Notification Message
            NotificationMessage notificationMessage2 = new NotificationMessage();
            notificationMessage2.User = user;
            notificationMessage2.NewUserRoles = new System.Collections.Generic.List<string>();
            
            //notificationMessage2.NewUserPassword = this.WorkflowApprovalSettings.DefaultEmployeePassword;
            notificationMessage2.NotificationType = NotificationType.Authentication;
            notificationMessage2.NotificationActionType = NotificationActionType.UserCreated;
            await mediator.Publish(notificationMessage2, cancellationToken);
            //end
            return (true, "Employee Created Successfully", response);
        }
    }
}