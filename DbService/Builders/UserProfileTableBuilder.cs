using DbService.DbModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DbService.Builders
{
    internal class UserProfileTableBuilder : AuditBaseBuilder<DbUserProfile>
    {
        public override void Configure(EntityTypeBuilder<DbUserProfile> builder)
        {
            base.Configure(builder);
            builder.HasIndex(x => x.Name);

        }
    }
}


