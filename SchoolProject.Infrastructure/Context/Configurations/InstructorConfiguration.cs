using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolProject.Data.Entities;

namespace SchoolProject.Infrastructure.Context.Configurations
{
    public class InstructorConfiguration : IEntityTypeConfiguration<Instructor>
    {
        public void Configure(EntityTypeBuilder<Instructor> builder)
        {
            builder.HasKey(ins => ins.InsId);
            builder.Property(ins => ins.InsId)
                .ValueGeneratedOnAdd();

            builder.HasOne(ins => ins.department)
                .WithMany(dep => dep.Instructors)
                .HasForeignKey(ins => ins.DID);

            builder.HasOne(ins => ins.Supervisor)
                .WithMany(ins => ins.Instructors)
                .HasForeignKey(ins => ins.SupervisorId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
