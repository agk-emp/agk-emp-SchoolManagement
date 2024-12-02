using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolProject.Data.Entities;

namespace SchoolProject.Infrastructure.Context.Configurations
{
    public class Ins_SubjectConfiguration : IEntityTypeConfiguration<Ins_Subject>
    {
        public void Configure(EntityTypeBuilder<Ins_Subject> builder)
        {
            builder.HasKey(insSub => new { insSub.SubId, insSub.InsId });

            builder.HasOne(insSub => insSub.instructor)
                .WithMany()
                .HasForeignKey(insSub => insSub.InsId);

            builder.HasOne(insSub => insSub.Subject)
                .WithMany().
                HasForeignKey(insSub => insSub.SubId);
        }
    }
}
