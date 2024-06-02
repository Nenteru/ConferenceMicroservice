namespace ConferenceMicroservice.Persistence.Entities;

public class OrganizationEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Number { get; set; } = string.Empty;
    public string Place { get; set; } = string.Empty;

    // Связь с UserEntity
    public ICollection<UserEntity>? Users { get; set; } = [];

    // Связь с OrganizationDivisionEntity
    public ICollection<OrganizationDivisionEntity>? Divisions { get; set; } = [];
}
