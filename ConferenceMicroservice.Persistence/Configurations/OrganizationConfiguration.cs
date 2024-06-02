

using ConferenceMicroservice.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConferenceMicroservice.Persistence.Configurations;

public class OrganizationConfiguration : IEntityTypeConfiguration<OrganizationEntity>
{
    public void Configure(EntityTypeBuilder<OrganizationEntity> builder)
    {
        builder.HasKey(o => o.Id);

        builder.HasMany(o => o.Divisions)
            .WithOne(d => d.Organization)
            .HasForeignKey(d => d.OrganizationId);
    }
}
