

using ConferenceMicroservice.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConferenceMicroservice.Persistence.Configurations;

public class OrganizationDivisionConfiguration : IEntityTypeConfiguration<OrganizationDivisionEntity>
{
    public void Configure(EntityTypeBuilder<OrganizationDivisionEntity> builder)
    {
        builder.HasKey(d => d.Id);

        builder.HasOne(d => d.Organization)
            .WithMany(o => o.Divisions)
            .HasForeignKey(o => o.Id);
    }
}
