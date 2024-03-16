using DbService.DbModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DbService.Builders
{
    internal class SearchProviderTableBuilder : AuditBaseBuilder<DbSearchProvider>
    {
        public override void Configure(EntityTypeBuilder<DbSearchProvider> builder)
        {
            base.Configure(builder);
            builder.Property(a => a.Base64Image).HasColumnType("NVARCHAR(MAX)");

        }
    }
}
