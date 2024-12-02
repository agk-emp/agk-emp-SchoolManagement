using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolProject.Data.Entities.Identity;

namespace SchoolProject.Infrastructure.Context.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasMany(user => user.UserRefreshTokens)
                .WithOne(refTok => refTok.User)
                .HasForeignKey(refTok => refTok.UserId);
        }
    }
}
