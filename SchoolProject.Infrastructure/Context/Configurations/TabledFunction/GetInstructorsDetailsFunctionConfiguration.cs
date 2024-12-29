using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolProject.Data.Entities.TabledFunctions;

namespace SchoolProject.Infrastructure.Context.Configurations.TabledFunction
{
    public class GetInstructorsDetailsFunctionConfiguration : IEntityTypeConfiguration<GetInstructorsDetailsFunction>
    {
        public void Configure(EntityTypeBuilder<GetInstructorsDetailsFunction> builder)
        {
            builder.HasNoKey();
        }
    }
}