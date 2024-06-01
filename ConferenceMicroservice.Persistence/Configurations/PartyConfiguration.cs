using ConferenceMicroservice.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConferenceMicroservice.Persistence.Configurations;

//public class PartyConfiguration : IEntityTypeConfiguration<PartyEntity>
//{
//    public void Configure(EntityTypeBuilder<PartyEntity> builder)
//    {
//        builder.HasKey(p => p.Id);

//        // Связь с UserEntity
//        builder.HasOne(p => p.User)
//            .WithMany(u => u.Parties)
//            .HasForeignKey(p => p.UserId);

//        // Связь с ChatEntity
//        builder.HasOne(p => p.Chat)
//            .WithMany(c => c.Parties)
//            .HasForeignKey(p => p.ChatId);

//        // Коллекция сообщений
//        builder.HasMany(p => p.Messages)
//            .WithOne(m => m.Party)
//            .HasForeignKey(m => m.PartyId);
//    }
//}

public class PartyConfiguration : IEntityTypeConfiguration<PartyEntity>
{
    public void Configure(EntityTypeBuilder<PartyEntity> builder)
    {
        builder.HasKey(p => p.Id);

        // Связь с UserEntity
        builder.HasOne(p => p.User)
            .WithMany(u => u.Parties)
            .HasForeignKey(p => p.UserId);

        // Связь с ChatEntity
        builder.HasOne(p => p.Chat)
            .WithMany(c => c.Parties)
            .HasForeignKey(p => p.ChatId);

        // Коллекция сообщений
        builder.HasMany(p => p.Messages)
            .WithOne(m => m.Party)
            .HasForeignKey(m => m.PartyId);
    }
}
