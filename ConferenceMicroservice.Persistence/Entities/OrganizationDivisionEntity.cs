namespace ConferenceMicroservice.Persistence.Entities;

public class OrganizationDivisionEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Number { get; set; } = string.Empty;
    public string Place { get; set; } = string.Empty;

    // Organization part
    public Guid OrganizationId { get; set; }
    public OrganizationEntity? Organization { get; set; }

}