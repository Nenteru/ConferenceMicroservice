

using ConferenceMicroservice.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConferenceMicroservice.Persistence.Configurations;

//public class ChatConfiguration : IEntityTypeConfiguration<ChatEntity>
//{
//    public void Configure(EntityTypeBuilder<ChatEntity> builder)
//    {
//        builder.HasKey(c => c.Id);

//        // User part M to M with PartyEntity
//        builder.HasMany(c => c.Users)
//            .WithMany(u => u.Chats)
//            .UsingEntity<PartyEntity>(
//            l => l.HasOne<UserEntity>().WithMany().HasForeignKey(c => c.ChatId),
//            r => r.HasOne<ChatEntity>().WithMany().HasForeignKey(u => u.UserId));
//    }
//}

public class ChatConfiguration : IEntityTypeConfiguration<ChatEntity>
{
    public void Configure(EntityTypeBuilder<ChatEntity> builder)
    {
        builder.HasKey(c => c.Id);

        // Связь с PartyEntity (для связи Многие-Ко-Многие с UserEntity)
        builder.HasMany(c => c.Parties)
            .WithOne(p => p.Chat)
            .HasForeignKey(p => p.ChatId);
    }
}
