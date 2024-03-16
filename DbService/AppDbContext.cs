using DbService.Builders;
using DbService.DbModels;
using Microsoft.EntityFrameworkCore;
using ScrapingAppDefinitions.Models;

namespace DbService
{
    public  class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { 
        
        }

        internal DbSet<DbSearchProvider> SearchProviders { get; set; }
        internal DbSet<DbUserProfile> UserProfiles { get; set; }
        internal DbSet<DbUserSearch> UserSearches { get; set; }

        private void SetAuditData()
        {
            var items = ChangeTracker
                            .Entries<DbBaseModel>()
                            .Where(o => o.State == EntityState.Modified || o.State == EntityState.Added);
            var now = DateTime.Now;
            foreach (var item in items)
            {
                item.Property(o => o.Updated).CurrentValue = now;
                if (item.State == EntityState.Added)
                {
                    item.Property(o => o.Created).CurrentValue = now;
                }
            }
        }

        public override int SaveChanges()
        {
            SetAuditData();
            return base.SaveChanges();
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            SetAuditData();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            SetAuditData();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            SetAuditData();
            return base.SaveChangesAsync(cancellationToken);
        }


        protected override void OnModelCreating(ModelBuilder mb)
        {
            //base.OnModelCreating(mb);
            new SearchProviderTableBuilder().Configure(mb.Entity<DbSearchProvider>());
            new UserProfileTableBuilder().Configure(mb.Entity<DbUserProfile>());
            new UserSearchTableBuilder().Configure(mb.Entity<DbUserSearch>());
        }
    }
}
