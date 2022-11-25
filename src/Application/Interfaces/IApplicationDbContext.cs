using Domain.Entities;
using Domain.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    /// <summary>
    /// Application Db Context implemented in Persistence layer
    /// </summary>
    public interface IApplicationDbContext
    {
        
        /// <summary>
        /// Gets or sets the company settings.
        /// </summary>
        /// <value>
        /// The company settings.
        /// </value>
        DbSet<CompanySetting> CompanySettings { get; set; }

        

        
       

        /// <summary>
        /// Gets or sets the employees.
        /// </summary>
        /// <value>
        /// The employees.
        /// </value>
        public DbSet<Employee> Employees { get; set; }
       

        /// <summary>
        /// Gets or sets the unit of measurements.
        /// </summary>
        /// <value>
        /// The unit of measurements.
        /// </value>
        DbSet<UnitOfMeasurement> UnitOfMeasurements { get; set; }

        
        /// <summary>
        /// Gets or sets the ServiceType.
        /// </summary>
        /// <value>
        /// The ServiceType.
        /// </value>
        DbSet<ServiceType> ServiceTypes { get; set; }

        /// <summary>
        /// Gets or sets the ItemType.
        /// </summary>
        /// <value>
        /// The ItemType.
        /// </value>
        DbSet<ItemType> ItemTypes { get; set; }

        

        

        

        

        

       


       

        /// <summary>
        /// Gets or sets the counters.
        /// </summary>
        /// <value>
        /// The counters.
        /// </value>
        DbSet<Counter> Counters { get; set; }

        /// <summary>
        /// Gets or sets the settings.
        /// </summary>
        /// <value>
        /// The settings.
        /// </value>
        DbSet<Settings> Settings { get; set; }

        /// <summary>
        /// Gets or sets the file uploads.
        /// </summary>
        /// <value>
        /// The file uploads.
        /// </value>
        DbSet<FileUpload> FileUploads { get; set; }

        

        

        

        /// <summary>
        /// Gets or sets the reasons.
        /// </summary>
        /// <value>
        /// The reasons.
        /// </value>
        public DbSet<Reason> Reasons { get; set; }

        /// <summary>
        /// Gets or sets the units.
        /// </summary>
        /// <value>
        /// The units.
        /// </value>
        public DbSet<Unit> Units { get; set; }

        /// <summary>
        /// Gets or sets the countries.
        /// </summary>
        /// <value>
        /// The countries.
        /// </value>
        public DbSet<Country> Countries { get; set; }

        /// <summary>
        /// Gets or sets the companies.
        /// </summary>
        /// <value>
        /// The companies.
        /// </value>
        public DbSet<Company> Companies { get; set; }

        /// <summary>
        /// Gets or sets the states.
        /// </summary>
        /// <value>
        /// The states.
        /// </value>
        public DbSet<State> States { get; set; }

        /// <summary>
        /// Gets or sets the LocalGovernment.
        /// </summary>
        /// <value>
        /// The LocalGovernment.
        /// </value>
        public DbSet<LocalGovernment> LocalGovernments { get; set; }

        /// <summary>
        /// Gets or sets the NotificationMessages.
        /// </summary>
        /// <value>
        /// The NotificationMessages.
        /// </value>
        public DbSet<NotificationMessages> NotificationMessages { get; set; }

        /// <summary>
        /// Gets or sets the NotificationMessageTemplate.
        /// </summary>
        /// <value>
        /// The NotificationMessageTemplate.
        /// </value>
        public DbSet<NotificationMessageTemplate> NotificationMessageTemplates { get; set; }

        /// <summary>
        /// Gets or sets the NotificationReceivers.
        /// </summary>
        /// <value>
        /// The NotificationReceivers.
        /// </value>
        public DbSet<NotificationReceiver> NotificationReceivers { get; set; }

        

        /// <summary>
        ///
        /// </summary>
        /// <param name="cancellation"></param>
        /// <returns></returns>
        Task<int> SaveChangesAsync(CancellationToken cancellation);

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        Task<int> SaveChangesAsync();

        

        /// <summary>
        /// Gets or sets the mail configurations.
        /// </summary>
        /// <value>
        /// The mail configurations.
        /// </value>
        public DbSet<MailConfigurations> MailConfigurations { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DbSet<User> Users { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DbSet<Role> Roles { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DbSet<IdentityUserRole<string>> UserRoles { get; set; }

        
    }
}