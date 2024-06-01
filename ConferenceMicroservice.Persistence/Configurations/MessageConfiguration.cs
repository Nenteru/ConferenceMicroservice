

using ConferenceMicroservice.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConferenceMicroservice.Persistence.Configurations;

public class MessageConfiguration : IEntityTypeConfiguration<MessageEntity>
{
    public void Configure(EntityTypeBuilder<MessageEntity> builder)
    {
        builder.HasKey(m => m.Id);

        // Определите ссылку на сущность PartyEntity
        builder.HasOne(m => m.Party)
            .WithMany(p => p.Messages) // Название навигационного свойства в PartyEntity
            .HasForeignKey(m => m.PartyId); // Внешний ключ PartyId
    }
}
