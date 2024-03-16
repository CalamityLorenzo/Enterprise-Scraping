using DbService.DbModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DbService.Builders
{
    internal class AuditBaseBuilder<T> : IEntityTypeConfiguration<T> where T : DbBaseModel
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(x => x.Id);
            
            builder.Property(aud => aud.Created).IsRequired()
                                                .HasDefaultValueSql("getutcdate()")
                                                .ValueGeneratedOnAdd()
                                                .HasConversion(b => b, b => DateTime.SpecifyKind(b, DateTimeKind.Utc));
            builder.Property(aud => aud.Updated).IsRequired()
                                                .HasDefaultValueSql("getutcdate()")
                                                .ValueGeneratedOnAdd()
                                                .HasConversion(b => b, b => DateTime.SpecifyKind(b, DateTimeKind.Utc));



        }
    }
}
