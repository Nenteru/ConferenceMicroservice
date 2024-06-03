

using ConferenceMicroservice.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConferenceMicroservice.Persistence.Configurations;

public class UserConferenceConfiguration : IEntityTypeConfiguration<UserConferenceEntity>
{
    public void Configure(EntityTypeBuilder<UserConferenceEntity> builder)
    {
        builder.HasKey(uc => new { uc.UserId, uc.ConferenceId });

        builder.HasOne(uc => uc.User)
            .WithMany(u => u.UserConferences)
            .HasForeignKey(uc => uc.UserId);

        builder.HasOne(uc => uc.Conference)
            .WithMany(c => c.UserConferences)
            .HasForeignKey(uc => uc.ConferenceId);

        builder.UsePropertyAccessMode(PropertyAccessMode.Property);
    }
}