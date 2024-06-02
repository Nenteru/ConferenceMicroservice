namespace ConferenceMicroservice.Persistence.Entities;

public class MessageEntity
{
    public Guid Id { get; set; }
    public string Content { get; set; } = string.Empty;
    public DateTime DateTimeCreate { get; set; }

    // Связь с PartyEntity
    public Guid PartyId { get; set; }
    public PartyEntity Party { get; set; } = null!;
}
