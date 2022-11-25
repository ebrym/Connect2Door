using Application.Interfaces;
using Domain.Common;
using Domain.Entities;
using Domain.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Persistence.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Persistence;

    /// <summary>
    ///
    /// </summary>
    public class ApplicationDbContext : IdentityDbContext<User, Role, string>, IApplicationDbContext
    {
        private readonly IHttpContextAccessor contextAccessor;
        private readonly ILogger<ApplicationDbContext> logger;

        /// <summary>
        ///
        /// </summary>
        /// <param name="options"></param>
        /// <param name="contextAccessor"></param>
        /// <param name="logger"></param>
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IHttpContextAccessor contextAccessor, ILogger<ApplicationDbContext> logger)
            : base(options)
        {
            this.contextAccessor = contextAccessor;
            this.logger = logger;
        }

        /// <summary>
        /// Gets or sets the settings.
        /// </summary>
        /// <value>
        /// The settings.
        /// </value>
        public DbSet<Settings> Settings { get; set; }
        
        /// <summary>
        /// Gets or sets the unit of measurements.
        /// </summary>
        /// <value>
        /// The unit of measurements.
        /// </value>
        public DbSet<UnitOfMeasurement> UnitOfMeasurements { get; set; }
       
     
       
        /// <summary>
        /// Gets or sets the company settings.
        /// </summary>
        /// <value>
        /// The company settings.
        /// </value>
        public DbSet<CompanySetting> CompanySettings { get; set; }

  
        ///// <summary>
        ///// Gets or sets the units.
        ///// </summary>
        ///// <value>
        ///// The units.
        ///// </value>
        public DbSet<Unit> Units { get; set; }
 
     
       
        /// <summary>
        /// Gets or sets the employees.
        /// </summary>
        /// <value>
        /// The employees.
        /// </value>
        public DbSet<Employee> Employees { get; set; }
     
        /// <summary>
        /// Gets or sets the mail configurations.
        /// </summary>
        /// <value>
        /// The mail configurations.
        /// </value>
        public DbSet<MailConfigurations> MailConfigurations { get; set; }
       
    
        /// <summary>
        /// Gets or sets the ItemType.
        /// </summary>
        /// <value>
        /// The ItemType.
        /// </value>
        public DbSet<ItemType> ItemTypes { get; set; }

        /// <summary>
        /// Gets or sets the ItemType.
        /// </summary>
        /// <value>
        /// The ItemType.
        /// </value>
        public DbSet<ServiceType> ServiceTypes { get; set; }

        /// <summary>
        /// Gets or sets the counters.
        /// </summary>
        /// <value>
        /// The counters.
        /// </value>
        public DbSet<Counter> Counters { get; set; }

        
        
 
     
    
     
      
       
        
      
        /// <summary>
        /// Gets or sets the file uploads.
        /// </summary>
        /// <value>
        /// The file uploads.
        /// </value>
        public DbSet<FileUpload> FileUploads { get; set; }

        
 
       
        /// <summary>
        /// Gets or sets the reasons.
        /// </summary>
        /// <value>
        /// The reasons.
        /// </value>

        public DbSet<Reason> Reasons { get; set; }

      
      

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
        /// Configures the schema needed for the identity framework.
        /// </summary>
        /// <param name="builder">The builder being used to construct the model for this context.</param>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // builder.ApplyConfigurationsFromAssembly(typeof(AssetConfiguration).Assembly);
            // builder.Entity<ApprovalConfig>().Property(x => x.MinAmount).HasColumnType("decimal(18,2)");

           
            
        }

        //Task<int> IApplicationDbContext.SaveChangesAsync(CancellationToken cancellation)
        //{
        //    return base.SaveChangesAsync(cancellation);

        //}

        ///// <summary>
        /////
        ///// </summary>
        ///// <returns></returns>
        //public Task<int> SaveChangesAsync()
        //{
        //    return base.SaveChangesAsync();
        //}

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public async Task<int> SaveChangesAsync()
        {
            //Set current user and datetime just before saving to db
            int saved = 0;
            var currentUser = "";
            if (contextAccessor != null && contextAccessor.HttpContext != null && contextAccessor.HttpContext.User != null)
            {
                currentUser = contextAccessor.HttpContext.User.Identity.Name;
            }
            var currentDate = DateTime.Now;
            try
            {
                foreach (var entry in ChangeTracker.Entries<BaseEntity>()
               .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified))
                {
                    if (entry.State == EntityState.Added)
                    {
                        entry.Entity.DateCreated = currentDate;
                        entry.Entity.CreatedBy = currentUser;
                        entry.Entity.DateModified = currentDate;
                        entry.Entity.ModifiedBy = currentUser;
                    }
                    if (entry.State == EntityState.Modified)
                    {
                        entry.Entity.DateModified = currentDate;
                        entry.Entity.ModifiedBy = currentUser;
                        if (entry.Entity.IsDeleted == true)
                        {
                            var IsDeletedOriginalValue = entry.OriginalValues.GetValue<bool>("IsDeleted");
                            //If the avlues changed then item was just marked for deletion
                            if (IsDeletedOriginalValue != entry.Entity.IsDeleted)
                            {
                                entry.Entity.DateDeleted = currentDate;
                                entry.Entity.DeletedBy = currentUser;
                            }
                        }
                    }
                }
                saved = await base.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                logger.Log(LogLevel.Error, ex.Message);
            }

            return saved;
        }

        /// <summary>
        /// <para>
        /// Saves all changes made in this context to the database.
        /// </para>
        /// <para>
        /// This method will automatically call <see cref="M:Microsoft.EntityFrameworkCore.ChangeTracking.ChangeTracker.DetectChanges" /> to discover any
        /// changes to entity instances before saving to the underlying database. This can be disabled via
        /// <see cref="P:Microsoft.EntityFrameworkCore.ChangeTracking.ChangeTracker.AutoDetectChangesEnabled" />.
        /// </para>
        /// <para>
        /// Multiple active operations on the same context instance are not supported.  Use 'await' to ensure
        /// that any asynchronous operations have completed before calling another method on this context.
        /// </para>
        /// </summary>
        /// <param name="cancellationToken">A <see cref="T:System.Threading.CancellationToken" /> to observe while waiting for the task to complete.</param>
        /// <returns>
        /// A task that represents the asynchronous save operation. The task result contains the
        /// number of state entries written to the database.
        /// </returns>
        public async override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            //Set current user and datetime just before saving to db
            int saved = 0;
            var currentUser = "";
            if (contextAccessor != null && contextAccessor.HttpContext != null && contextAccessor.HttpContext.User != null)
            {
                currentUser = contextAccessor.HttpContext.User.Identity.Name;
            }
            var currentDate = DateTime.Now;
            try
            {
                foreach (var entry in ChangeTracker.Entries<BaseEntity>()
               .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified))
                {
                    if (entry.State == EntityState.Added)
                    {
                        entry.Entity.DateCreated = currentDate;
                        entry.Entity.CreatedBy = currentUser;
                        entry.Entity.DateModified = currentDate;
                        entry.Entity.ModifiedBy = currentUser;
                    }
                    if (entry.State == EntityState.Modified)
                    {
                        entry.Entity.DateModified = currentDate;
                        entry.Entity.ModifiedBy = currentUser;
                        if (entry.Entity.IsDeleted == true)
                        {
                            var IsDeletedOriginalValue = entry.OriginalValues.GetValue<bool>("IsDeleted");
                            //If the avlues changed then item was just marked for deletion
                            if (IsDeletedOriginalValue != entry.Entity.IsDeleted)
                            {
                                entry.Entity.DateDeleted = currentDate;
                                entry.Entity.DeletedBy = currentUser;
                            }
                        }
                    }
                }
                saved = await base.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                logger.Log(LogLevel.Error, ex.Message);
            }

            return saved;
        }
    }
