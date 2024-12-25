using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolProject.Data.Entities.Views;

namespace SchoolProject.Infrastructure.Context.Configurations.Views
{
    public class StudentsCountPerDepartmentViewConfiguration :
        IEntityTypeConfiguration<StudentsCountPerDepartmentView>
    {
        public void Configure(EntityTypeBuilder<StudentsCountPerDepartmentView> builder)
        {
            builder.HasNoKey();
            builder.ToView("StudentsCountPerDepartment");
        }
    }
}
