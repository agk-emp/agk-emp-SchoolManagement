using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolProject.Data.Entities;

namespace SchoolProject.Infrastructure.Context.Configurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(st => st.StudID);
            builder.Property(st => st.StudID)
                .ValueGeneratedOnAdd();

            builder.Property(st => st.NameEn)
                .HasMaxLength(200);
            builder.Property(st => st.NameAr)
                .HasMaxLength(200);
            builder.Property(st => st.Address)
                .HasMaxLength(500);
            builder.Property(st => st.Phone)
                .HasMaxLength(500);

            builder.HasOne(st => st.Department)
                .WithMany(d => d.Students)
                .HasForeignKey(st => st.DID);
        }
    }
}
