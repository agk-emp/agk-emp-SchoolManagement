using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolProject.Data.Entities;

namespace SchoolProject.Infrastructure.Context.Configurations
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasKey(d => d.DID);
            builder.Property(d => d.DID)
                .ValueGeneratedOnAdd();
            builder.Property(d => d.DNameEn)
                .HasMaxLength(500);
            builder.Property(d => d.DNameAr)
                .HasMaxLength(500);

            builder.HasOne(st => st.Instructor)
                .WithOne(d => d.departmentManager)
                .HasForeignKey<Department>(dep => dep.InsManager)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
