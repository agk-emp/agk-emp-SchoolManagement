using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolProject.Data.Entities.Procedures;

namespace SchoolProject.Infrastructure.Context.Configurations.Procedures
{
    public class GETStudentsCountForDepartmentProcedureConfiguration :
        IEntityTypeConfiguration<GETStudentsCountForDepartmentProcedure>
    {
        public void Configure(EntityTypeBuilder<GETStudentsCountForDepartmentProcedure> builder)
        {
            builder.HasNoKey();
        }
    }
}