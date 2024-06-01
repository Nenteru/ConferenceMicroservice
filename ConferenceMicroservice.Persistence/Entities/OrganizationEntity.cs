namespace ConferenceMicroservice.Persistence.Entities;

public class OrganizationEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Number { get; set; } = string.Empty;
    public string Place { get; set; } = string.Empty;

    // User part
    public ICollection<UserEntity> Users { get; set; } = [];

    // Divisions part
    public ICollection<OrganizationDivisionEntity> Divisions { get; set; } = [];
}
