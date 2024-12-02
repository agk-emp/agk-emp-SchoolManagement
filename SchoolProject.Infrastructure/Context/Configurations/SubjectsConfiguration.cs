using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolProject.Data.Entities;

namespace SchoolProject.Infrastructure.Context.Configurations
{
    public class SubjectsConfiguration : IEntityTypeConfiguration<Subjects>
    {
        public void Configure(EntityTypeBuilder<Subjects> builder)
        {
            builder.HasKey(s => s.SubID);
            builder.Property(s => s.SubID)
                .ValueGeneratedOnAdd();

            builder.Property(s => s.SubjectNameEn)
                .HasMaxLength(500);

            builder.Property(s => s.SubjectNameAr)
               .HasMaxLength(500);

            builder.Property(s => s.Period)
                .IsRequired(false);

            builder.ToTable(s => s.HasCheckConstraint("positive_subject_period", $"{nameof(Subjects.Period)}>0"));
        }
    }
}
