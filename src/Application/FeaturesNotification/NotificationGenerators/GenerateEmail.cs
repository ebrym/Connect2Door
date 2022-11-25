using Application.FeaturesNotification.Notifications;
using Application.FeaturesNotification.Utilities;
using Application.Interfaces;
using Domain.Common;
using Domain.Entities;
using Domain.User;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.FeaturesNotification.NotificationGenerators
{
    /// <summary>
    ///
    /// </summary>
    public class GenerateEmail
    {
        private readonly IApplicationDbContext applicationDbContext;
        private readonly IMediator mediator;
        private readonly RoleManager<Role> roleManager;
        private readonly AssetURLS assetUrls;
        private readonly UserManager<User> userManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="GenerateEmail"/> class.
        /// </summary>
        /// <param name="applicationDbContext">The application database context.</param>
        /// <param name="mediator">The mediator.</param>
        /// <param name="roleManager">The role manager.</param>
        /// <param name="assetUrls">The asset urls.</param>
        /// <param name="userManager">The user manager.</param>
        public GenerateEmail(IApplicationDbContext applicationDbContext,
            IMediator mediator,
            RoleManager<Role> roleManager,
            IOptionsSnapshot<AssetURLS> assetUrls,
            UserManager<User> userManager)
        {
            this.applicationDbContext = applicationDbContext;
            this.mediator = mediator;
            this.roleManager = roleManager;
            this.assetUrls = assetUrls.Value;
            this.userManager = userManager;
        }
        /// <summary>
        /// Gets the users to notify asynchronous.
        /// </summary>
        /// <param name="notificationReceivers">The notification receivers.</param>
        /// <param name="notification">The notification.</param>
        /// <returns></returns>
        public async Task<List<User>> GetUsersToNotifyAsync(NotificationReceiver notificationReceivers, NotificationMessage notification)
        {
            var users = new List<User>();
            try
            {
                if (notificationReceivers != null)
                {
                    var tempUserList = new List<User>();
                    if (!string.IsNullOrWhiteSpace(notificationReceivers.Roles) && notificationReceivers.Roles.Contains(@","))
                    {
                        var roles = notificationReceivers.Roles.Split(@",");
                        foreach (var role in roles)
                        {
                            //var usersInRole = (List<User>)await userManager.GetUsersInRoleAsync(role);
                            //new users from userlocation mapping
                            // var userMappings = await applicationDbContext.UserRoleLocationMappings
                            //     .Where(u => u.LocationId == notificationReceivers.LocationId && u.Role.Name.ToLower() == role.ToLower())
                            //     .Include(u => u.User)
                            //     .ToListAsync();
                            // var usersInRole = userMappings.Select(u => u.User).ToList();
                            // //end
                            // if (usersInRole != null)
                            // {
                            //     tempUserList.AddRange(usersInRole);
                            // }
                        }
                    }
                    else if (!string.IsNullOrWhiteSpace(notificationReceivers.Roles) && !notificationReceivers.Roles.Contains(@","))
                    {
                        //var usersInRole = (List<User>)await userManager.GetUsersInRoleAsync(notificationReceivers.Roles);
                       
                       
                        // if (usersInRole != null)
                        // {
                        //     tempUserList.AddRange(usersInRole);
                        // }
                    }

                    if (!string.IsNullOrWhiteSpace(notificationReceivers.UserEmails) && notificationReceivers.UserEmails.Contains(@","))
                    {
                        var userEmails = notificationReceivers.UserEmails.Split(@",");
                        foreach (var userEmail in userEmails)
                        {
                            var user = await userManager.FindByEmailAsync(userEmail);
                            if (user != null)
                            {
                                tempUserList.Add(user);
                            }
                        }
                    }
                    else if (!string.IsNullOrWhiteSpace(notificationReceivers.UserEmails) && !notificationReceivers.UserEmails.Contains(@","))
                    {
                        var user = await userManager.FindByEmailAsync(notificationReceivers.UserEmails);
                        if (user != null)
                        {
                            tempUserList.Add(user);
                        }
                    }

                    users = tempUserList;
                }

               
            }
            catch (Exception ex)
            {
            }

            return users;
        }
        /// <summary>
        /// Generates the user details.
        /// </summary>
        /// <param name="notification">The notification.</param>
        /// <param name="template">The template.</param>
        /// <returns></returns>
        public async Task<string> GenerateUserDetails(NotificationMessage notification, string template)
        {
            try
            {
                var user = notification.User;

                if (!string.IsNullOrWhiteSpace(template))
                {
                    if (template.Contains(@"{UserFullName}"))
                    {
                        template = template.Replace(@"{UserFullName}", user.FullName);
                    }
                    if (template.Contains(@"{UserEmail}"))
                    {
                        template = template.Replace(@"{UserEmail}", user.Email);
                    }
                    if (template.Contains(@"{Username}"))
                    {
                        template = template.Replace(@"{Username}", user.UserName);
                    }
                    if (template.Contains(@"{Roles}"))
                    {
                        var roles = notification.NewUserRoles;
                        var rolesString = "";
                        if (roles != null && roles.Count > 0)
                        {
                            foreach (var role in roles)
                            {
                                if (!string.IsNullOrWhiteSpace(role))
                                {
                                    rolesString += role + ",";
                                }
                            }
                        }
                        template = template.Replace(@"{Roles}", rolesString);
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return template;
        }
     
        /// <summary>
        /// Generates the employee details.
        /// </summary>
        /// <param name="notification">The notification.</param>
        /// <param name="template">The template.</param>
        /// <returns></returns>
        public async Task<string> GenerateEmployeeDetails(NotificationMessage notification, string template)
        {
            try
            {
                var currentEmployee = notification.MainEntity as Employee;
                var employee = await applicationDbContext.Employees
                    .Where(a => a.Id == currentEmployee.Id)
                    .Include(a => a.Unit)
                    .FirstOrDefaultAsync();

                if (!string.IsNullOrWhiteSpace(template))
                {
                    if (template.Contains(@"{EmployeeFullName}"))
                    {
                        template = template.Replace(@"{EmployeeFullName}", $"{employee?.FirstName} {employee?.LastName}");
                    }
                    if (template.Contains(@"{EmployeeEmail}"))
                    {
                        template = template.Replace(@"{EmployeeEmail}", employee.Email);
                    }
                    
                    if (template.Contains(@"{EmployeeUnit}"))
                    {
                        template = template.Replace(@"{EmployeeUnit}", employee?.Unit?.Name);
                    }
                }
            }
            catch (Exception ex)
            {
                // ignored
            }

            return template;
        }
   
        

        /// <summary>
        /// Generates the initiator details.
        /// </summary>
        /// <param name="initiator">The initiator.</param>
        /// <param name="initiatedDate">The initiated date.</param>
        /// <param name="template">The template.</param>
        /// <returns></returns>
        public async Task<string> GenerateInitiatorDetails(User initiator, DateTimeOffset initiatedDate, string template)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(template))
                {
                    if (template.Contains(@"{InitiatorName}"))
                    {
                        template = template.Replace(@"{InitiatorName}", initiator?.FullName);
                    }

                    if (template.Contains(@"{InitiatedDate}"))
                    {
                        template = template.Replace(@"{InitiatedDate}", initiatedDate.ToString("MMMM dd, yyyy HH:mm"));
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return template;
        }

        
        /// <summary>
        /// Generates the view link.
        /// </summary>
        /// <param name="notification">The notification.</param>
        /// <param name="template">The template.</param>
        /// <param name="link">The link.</param>
        /// <param name="linkText">The link text.</param>
        /// <returns></returns>
        public async Task<string> GenerateViewLink(NotificationMessage notification, string template, string link, string linkText)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(template))
                {
                    if (template.Contains(@"{ItemURL}"))
                    {
                        template = template.Replace(@"{ItemURL}", link);
                    }
                    if (template.Contains(@"{EmailLogoURL}"))
                    {
                        template = template.Replace(@"{EmailLogoURL}", this.assetUrls?.EmailLogoURL);
                    }

                    //if (template.Contains(@"{LinkText}"))
                    //{
                    //    template = template.Replace(@"{LinkText}", linkText);
                    //}
                }
            }
            catch (Exception ex)
            {
            }
            return template;
        }

        /// <summary>
        /// Generates the recipient details and save.
        /// </summary>
        /// <param name="notification">The notification.</param>
        /// <param name="template">The template.</param>
        /// <returns></returns>
        public async Task<bool> GenerateRecipientDetailsAndSave(NotificationMessage notification, string template)
        {
            bool saved = false;
            try
            {
                if (!string.IsNullOrWhiteSpace(template))
                {
                    var tempTemplate = template;
                    List<NotificationMessages> notificationMessagesList = new List<NotificationMessages>();

                    var notificationReceivers = await applicationDbContext.NotificationReceivers.Where(n =>
                            n.NotificationActionType == notification.NotificationActionType && n.IsDeleted == false 
                            && n.LocationId == notification.LocationId)
                        .FirstOrDefaultAsync();

                    var users = await GetUsersToNotifyAsync(notificationReceivers, notification);

                    foreach (var user in users)
                    {
                        template = tempTemplate;

                        NotificationMessages notificationMessages = new NotificationMessages();

                        if (template.Contains(@"{RecipientFullName}"))
                        {
                            template = template.Replace(@"{RecipientFullName}", user.FullName);
                        }

                        notificationMessages.NotificationActionType = notification.NotificationActionType;
                        notificationMessages.Body = template;
                        notificationMessages.To = user.Email;
                        notificationMessagesList.Add(notificationMessages);
                    }

                    if (notificationMessagesList != null && notificationMessagesList.Count > 0)
                    {
                        applicationDbContext.NotificationMessages.AddRange(notificationMessagesList);
                        int saveStatus = await applicationDbContext.SaveChangesAsync();
                        saved = saveStatus > 0 ? true : false;
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return saved;
        }

        /// <summary>
        /// Generates the initiator details and save.
        /// </summary>
        /// <param name="notification">The notification.</param>
        /// <param name="template">The template.</param>
        /// <param name="initiator">The initiator.</param>
        /// <returns></returns>
        public async Task<bool> GenerateInitiatorDetailsAndSave(NotificationMessage notification, string template, User initiator)
        {
            bool saved = false;
            try
            {
                if (!string.IsNullOrWhiteSpace(template))
                {
                    var tempTemplate = template;
                    List<NotificationMessages> notificationMessagesList = new List<NotificationMessages>();

                    template = tempTemplate;

                    NotificationMessages notificationMessages = new NotificationMessages();

                    if (template.Contains(@"{RecipientFullName}"))
                    {
                        template = template.Replace(@"{RecipientFullName}", initiator.FullName);
                    }
                    if (notification.NoMoreApproval && notification.NotificationType == NotificationType.Approval)
                    {
                        if (notification.NotificationActionType == NotificationActionType.AssetCheckOut)
                        {
                            string stringToReplace = "Please be informed that the following activity has happened on asset management solution for the state:";
                            string replacementString = "Please be informed that approval is now complete and you can now proceed to the store/transport office to retrieve your requested item.";
                            template = template.Replace(stringToReplace, replacementString);
                        }
                        if (notification.NotificationActionType == NotificationActionType.AssetCheckIn)
                        {
                            string stringToReplace = "Please be informed that the following activity has happened on asset management solution for the state:";
                            string replacementString = "Please be informed that approval is now complete and you can now proceed to the store/transport office to return the specified item.";
                            template = template.Replace(stringToReplace, replacementString);
                        }

                        notificationMessages.NotificationActionType = notification.NotificationActionType;
                        notificationMessages.Body = template;
                        notificationMessages.To = initiator.Email;
                        notificationMessagesList.Add(notificationMessages);

                        if (notificationMessagesList != null && notificationMessagesList.Count > 0)
                        {
                            applicationDbContext.NotificationMessages.AddRange(notificationMessagesList);
                            int saveStatus = await applicationDbContext.SaveChangesAsync();
                            saved = saveStatus > 0 ? true : false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return saved;
        }

       
        /// <summary>
        /// Generates the concerned recipient details and save.
        /// </summary>
        /// <param name="notification">The notification.</param>
        /// <param name="template">The template.</param>
        /// <param name="users">The users.</param>
        /// <returns></returns>
        public async Task<bool> GenerateConcernedRecipientDetailsAndSave(NotificationMessage notification, string template, List<User> users)
        {
            bool saved = false;
            try
            {
                if (!string.IsNullOrWhiteSpace(template))
                {
                    var tempTemplate = template;
                    List<NotificationMessages> notificationMessagesList = new List<NotificationMessages>();

                    foreach (var user in users)
                    {
                        template = tempTemplate;

                        NotificationMessages notificationMessages = new NotificationMessages();

                        if (template.Contains(@"{RecipientFullName}"))
                        {
                            template = template.Replace(@"{RecipientFullName}", user.FullName);
                        }

                        notificationMessages.NotificationActionType = notification.NotificationActionType;
                        notificationMessages.Body = template;
                        notificationMessages.To = user.Email;
                        notificationMessagesList.Add(notificationMessages);
                    }

                    if (notificationMessagesList != null && notificationMessagesList.Count > 0)
                    {
                        applicationDbContext.NotificationMessages.AddRange(notificationMessagesList);
                        int saveStatus = await applicationDbContext.SaveChangesAsync();
                        saved = saveStatus > 0 ? true : false;
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return saved;
        }

        public async Task<bool> EmployeeCreated(NotificationMessage notification)
        {
            bool generated = false;

            try
            {
                var employee = notification.MainEntity as Employee;

                var initiator = await userManager.FindByNameAsync(employee?.CreatedBy);


                var initiatedDate = employee.DateCreated;

                var notificationMessageTemplate = await applicationDbContext.NotificationMessageTemplates
                    .Where(n => n.NotificationActionType == notification.NotificationActionType && n.IsDeleted == false)
                    .FirstOrDefaultAsync();

                var template = notificationMessageTemplate?.MessageTemplate;

                if (!string.IsNullOrWhiteSpace(template))
                {
                    var itemActionName = "New Employee";

                    if (notification.NotificationType == NotificationType.Approval)
                    {
                        itemActionName += " Approval";
                    }

                    if (template.Contains(@"{ItemActionName}"))
                    {
                        template = template.Replace(@"{ItemActionName}", itemActionName);
                    }
                }

                template = await GenerateEmployeeDetails(notification, template);
                template = await GenerateInitiatorDetails(initiator,  initiatedDate, template);
                var linkText = "";

                var link = "";
                if (notification.NotificationType == NotificationType.Approval)
                {
                    link = assetUrls.ViewEmployeeApproval;
                }
                else
                {
                    link = assetUrls.ViewEmployee;
                }
                template = await GenerateViewLink(notification, template, link, linkText);

                generated = await GenerateRecipientDetailsAndSave(notification, template);
            }
            catch (Exception ex)
            {
            }

            return generated;
        }

        /// <summary>
        /// Users the created.
        /// </summary>
        /// <param name="notification">The notification.</param>
        /// <returns></returns>
        public async Task<bool> UserCreated(NotificationMessage notification)
        {
            bool generated = false;

            try
            {
                var user = notification.User;

                var initiator = await userManager.FindByNameAsync(user?.CreatedBy);

                var initiatedDate = user.DateCreated;

                var notificationMessageTemplate = await applicationDbContext.NotificationMessageTemplates
                    .Where(n => n.NotificationActionType == notification.NotificationActionType && n.IsDeleted == false)
                    .FirstOrDefaultAsync();

                var template = notificationMessageTemplate?.MessageTemplate;

                if (!string.IsNullOrWhiteSpace(template))
                {
                    var itemActionName = "New User";

                    if (notification.NotificationType == NotificationType.Approval)
                    {
                        itemActionName += " Approval";
                    }

                    if (template.Contains(@"{ItemActionName}"))
                    {
                        template = template.Replace(@"{ItemActionName}", itemActionName);
                    }
                }

                template = await GenerateUserDetails(notification, template);
                template = await GenerateInitiatorDetails(initiator,  initiatedDate, template);
                var linkText = "";

                var link = "";
                if (notification.NotificationType == NotificationType.Approval)
                {
                    link = assetUrls.ViewUserApproval;
                }
                else
                {
                    link = assetUrls.ViewUser;
                }
                template = await GenerateViewLink(notification, template, link, linkText);

                generated = await GenerateRecipientDetailsAndSave(notification, template);

                if (!string.IsNullOrWhiteSpace(template))
                {
                    var password = notification?.NewUserPassword;
                    if (template.Contains(@"{Password}"))
                    {
                        template = template.Replace(@"{Password}", password);
                    }
                    var htmlToReplace = "display: none;";
                    var htmlToReplaceWith = "";
                    template = template.Replace(htmlToReplace, htmlToReplaceWith);

                    htmlToReplace = "Details of the user";
                    htmlToReplaceWith = "Your details";
                    template = template.Replace(htmlToReplace, htmlToReplaceWith);
                    //notify newly created user
                    var users = new List<User>();
                    users.Add(user);
                    bool generatedForUser = await GenerateConcernedRecipientDetailsAndSave(notification, template, users);
                }
            }
            catch (Exception ex)
            {
            }

            return generated;
        }

       
        
    }
}