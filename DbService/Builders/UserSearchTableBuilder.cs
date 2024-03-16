using DbService.DbModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DbService.Builders
{
    internal class UserSearchTableBuilder : AuditBaseBuilder<DbUserSearch>
    {
        public override void Configure(EntityTypeBuilder<DbUserSearch> builder)
        {
            base.Configure(builder);
            builder.HasIndex(x => x.SearchTerms);
            builder.HasOne<DbUserProfile>(a => a.UserProfile).WithMany()
                .OnDelete(DeleteBehavior.NoAction).HasForeignKey(a=>a.ProfileId);
            builder.HasOne<DbSearchProvider>(a=>a.SearchProvider).WithMany()
                .OnDelete(DeleteBehavior.NoAction).HasForeignKey(a=>a.ProviderId);
            //builder.HasOne<DbUserProfile>().WithMany();
            //builder.HasOne<DbSearchProvider>().WithMany();
        }
    }
    
}
