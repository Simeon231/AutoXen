namespace AutoXen.Data
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Threading;
    using System.Threading.Tasks;

    using AutoXen.Data.Common.Models;
    using AutoXen.Data.Models;
    using AutoXen.Data.Models.AnnualTechnicalInspection;
    using AutoXen.Data.Models.Car;
    using AutoXen.Data.Models.CarWash;
    using AutoXen.Data.Models.Insurance;
    using AutoXen.Data.Models.RoadsideAssistance;
    using AutoXen.Data.Models.Workshop;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        private static readonly MethodInfo SetIsDeletedQueryFilterMethod =
            typeof(ApplicationDbContext).GetMethod(
                nameof(SetIsDeletedQueryFilter),
                BindingFlags.NonPublic | BindingFlags.Static);

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ApplicationUser> ApplicationUser { get; set; }

        // public DbSet<Message> Messages { get; set; }
        public DbSet<Car> Cars { get; set; }

        public DbSet<OtherCarUser> OtherCarUsers { get; set; }

        public DbSet<CarExtra> CarExtras { get; set; }

        public DbSet<Extra> Extras { get; set; }

        public DbSet<CarWashRequest> CarWashRequests { get; set; }

        public DbSet<CarWash> CarWashes { get; set; }

        public DbSet<Insurance> Insurances { get; set; }

        public DbSet<InsurersRequest> InsurersRequests { get; set; }

        public DbSet<Insurer> Insurers { get; set; }

        public DbSet<InsurerInsurances> InsurerInsurances { get; set; }

        public DbSet<Province> Provinces { get; set; }

        public DbSet<RoadsideAssistance> RoadsideAssistances { get; set; }

        public DbSet<RoadsideAssistanceProvince> RoadsideAssistanceProvinces { get; set; }

        public DbSet<RoadsideAssistanceRequest> RoadsideAssistanceRequests { get; set; }

        public DbSet<RoadsideAssistanceService> RoadsideAssistanceServices { get; set; }

        public DbSet<RService> RServices { get; set; }

        public DbSet<AnnualTechnicalInspection> AnnualTechnicalInspections { get; set; }

        public DbSet<AnnualTechnicalInspectionRequest> AnnualTechnicalInspectionRequests { get; set; }

        public DbSet<Workshop> Workshops { get; set; }

        public DbSet<WorkshopRequest> WorkshopRequests { get; set; }

        public DbSet<WorkshopService> WorkshopServices { get; set; }

        public DbSet<WService> WServices { get; set; }

        public DbSet<WorkshopRequestServices> WorkshopRequestServices { get; set; }

        public override int SaveChanges() => this.SaveChanges(true);

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            this.ApplyAuditInfoRules();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) =>
            this.SaveChangesAsync(true, cancellationToken);

        public override Task<int> SaveChangesAsync(
            bool acceptAllChangesOnSuccess,
            CancellationToken cancellationToken = default)
        {
            this.ApplyAuditInfoRules();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Needed for Identity models configuration
            base.OnModelCreating(builder);

            this.ConfigureUserIdentityRelations(builder);

            EntityIndexesConfiguration.Configure(builder);

            var entityTypes = builder.Model.GetEntityTypes().ToList();

            // Set global query filter for not deleted entities only
            var deletableEntityTypes = entityTypes
                .Where(et => et.ClrType != null && typeof(IDeletableEntity).IsAssignableFrom(et.ClrType));
            foreach (var deletableEntityType in deletableEntityTypes)
            {
                var method = SetIsDeletedQueryFilterMethod.MakeGenericMethod(deletableEntityType.ClrType);
                method.Invoke(null, new object[] { builder });
            }

            // Disable cascade delete
            var foreignKeys = entityTypes
                .SelectMany(e => e.GetForeignKeys().Where(f => f.DeleteBehavior == DeleteBehavior.Cascade));
            foreach (var foreignKey in foreignKeys)
            {
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }

        private static void SetIsDeletedQueryFilter<T>(ModelBuilder builder)
            where T : class, IDeletableEntity
        {
            builder.Entity<T>().HasQueryFilter(e => !e.IsDeleted);
        }

        // Applies configurations
        private void ConfigureUserIdentityRelations(ModelBuilder builder)
             => builder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);

        private void ApplyAuditInfoRules()
        {
            var changedEntries = this.ChangeTracker
                .Entries()
                .Where(e =>
                    e.Entity is IAuditInfo &&
                    (e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach (var entry in changedEntries)
            {
                var entity = (IAuditInfo)entry.Entity;
                if (entry.State == EntityState.Added && entity.CreatedOn == default)
                {
                    entity.CreatedOn = DateTime.UtcNow;
                }
                else
                {
                    entity.ModifiedOn = DateTime.UtcNow;
                }
            }
        }
    }
}
