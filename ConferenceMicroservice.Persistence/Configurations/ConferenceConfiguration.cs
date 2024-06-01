

using ConferenceMicroservice.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConferenceMicroservice.Persistence.Configurations;

public class ConferenceConfiguration : IEntityTypeConfiguration<ConferenceEntity>
{
    public void Configure(EntityTypeBuilder<ConferenceEntity> builder)
    {
        builder.HasKey(c => c.Id);

        // Связь с UserConferenceEntity (для связи Многие-Ко-Многие с UserEntity)
        builder.HasMany(c => c.UserConferences)
            .WithOne(uc => uc.Conference)
            .HasForeignKey(uc => uc.ConferenceId);
    }
}