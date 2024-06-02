namespace ConferenceMicroservice.Persistence.Entities;

public class PartyEntity
{
    public Guid Id { get; set; }

    public DateTime DateTimeUserAdd { get; set; }

    // Связь с UserEntity
    public Guid UserId { get; set; }
    public UserEntity User { get; set; } = null!;

    // Связь с ChatEntity
    public Guid ChatId { get; set; }
    public ChatEntity Chat { get; set; } = null!;

    // Коллекция сообщений
    public ICollection<MessageEntity>? Messages { get; set; } = [];
}