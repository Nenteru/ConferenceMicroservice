

using ConferenceMicroservice.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Security.Cryptography;

namespace ConferenceMicroservice.Persistence.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
{
    public void Configure(EntityTypeBuilder<UserEntity> builder)
    {
        builder.HasKey(u => u.Id);

        // Organization part M to M
        builder.
            HasOne(u => u.Organization)
            .WithMany(o => o.Users)
            .HasForeignKey(u => u.OrganizationId);

        // Conference part M to M with UserConferenceEntity
        builder.HasMany(u => u.Conferences)
            .WithMany(c => c.Users)
            .UsingEntity<UserConferenceEntity>(
            l => l.HasOne<ConferenceEntity>().WithMany().HasForeignKey(c => c.ConferenceId),
            r => r.HasOne<UserEntity>().WithMany().HasForeignKey(u => u.UserId));

        // Chat part M to M with PartyEntity
        builder.HasMany(u => u.Chats)
            .WithMany(c => c.Users)
            .UsingEntity<PartyEntity>(
            l => l.HasOne<ChatEntity>().WithMany().HasForeignKey(c => c.ChatId),
            r => r.HasOne<UserEntity>().WithMany().HasForeignKey(u => u.UserId));
    }
}

