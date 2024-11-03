using DRR.Domain.Profile;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;


namespace DRR.CommandDb.EntitiesConfigurations.Profile
{
    public class UserProfileConfiguration : IEntityTypeConfiguration<UserProfile>
    {
        public void Configure(EntityTypeBuilder<UserProfile> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.User)
                .WithMany(x => x.UserProfiles)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.SmeProfile)
                .WithMany(x => x.UserProfiles)
                .HasForeignKey(x => x.SmeProfileId)
                .OnDelete(DeleteBehavior.NoAction);
        }

    }
}
