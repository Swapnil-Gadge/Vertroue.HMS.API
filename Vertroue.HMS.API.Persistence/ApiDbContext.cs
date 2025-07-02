using Vertroue.HMS.API.Application.Contracts;
using Vertroue.HMS.API.Domain.Common;
using Vertroue.HMS.API.Domain.Entities;

using Microsoft.EntityFrameworkCore;

namespace Vertroue.HMS.API.Persistence
{
    public class ApiDbContext: DbContext
    {
        private readonly ILoggedInUserService? _loggedInUserService;

        public ApiDbContext(DbContextOptions<ApiDbContext> options, ILoggedInUserService loggedInUserService)
            : base(options)
        {
            _loggedInUserService = loggedInUserService;
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<CorporateMaster> Corporate_Master { get; set; }
        public DbSet<UserMaster> User_Master { get; set; }
        public DbSet<UserRoleMaster> User_Role_Master { get; set; }
        public DbSet<UserTypeMaster> User_Type_Master { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApiDbContext).Assembly);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            if (_loggedInUserService == null)
                throw new InvalidOperationException();

            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.UtcNow;
                        entry.Entity.CreatedBy = _loggedInUserService.UserId;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.UtcNow;
                        entry.Entity.LastModifiedBy = _loggedInUserService.UserId;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
