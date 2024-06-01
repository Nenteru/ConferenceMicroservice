using ConferenceMicroservice.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConferenceMicroservice.Persistence.Configurations;

public class PartyConfiguration : IEntityTypeConfiguration<PartyEntity>
{
    public void Configure(EntityTypeBuilder<PartyEntity> builder)
    {
        builder.HasKey(p => p.Id);

        builder.HasMany(p => p.Messages)
            .WithOne(m => m.Party)
            .HasForeignKey(m => m.PartyId);
    }
}
