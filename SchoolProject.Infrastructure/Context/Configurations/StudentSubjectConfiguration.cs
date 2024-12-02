using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolProject.Data.Entities;

namespace SchoolProject.Infrastructure.Context.Configurations
{
    public class StudentSubjectConfiguration : IEntityTypeConfiguration<StudentSubject>
    {
        public void Configure(EntityTypeBuilder<StudentSubject> builder)
        {
            builder.HasKey(sts => new { sts.StudID, sts.SubID });

            builder.HasOne(sts => sts.Subject)
                .WithMany(s => s.StudentsSubjects)
                .HasForeignKey(sts => sts.SubID);

            builder.HasOne(sts => sts.Student)
            .WithMany()
            .HasForeignKey(sts => sts.StudID);

            builder.HasOne(sts => sts.Subject)
                .WithMany(s => s.StudentsSubjects)
                .HasForeignKey(sts => sts.SubID);
        }
    }
}
