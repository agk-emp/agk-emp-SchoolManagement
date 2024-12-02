using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolProject.Data.Entities.Identity;

namespace SchoolProject.Infrastructure.Context.Configurations
{
    public class ClaimSpecConfiguration : IEntityTypeConfiguration<ClaimSpec>
    {
        public void Configure(EntityTypeBuilder<ClaimSpec> builder)
        {
            builder.ToTable("Claims");
            builder.HasKey(clm => clm.Id);
            builder.Property(clm => clm.ClaimType).IsRequired()
                .HasMaxLength(128);
            builder.Property(clm => clm.ClaimValue).IsRequired()
                .HasMaxLength(256);
        }
    }
}
