

namespace ConferenceMicroservice.Persistence.Entities;

public class ChatEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTime DateTimeCreate { get; set; }

    // Связь с PartyEntity (для связи Многие-Ко-Многим с UserEntity)
    public ICollection<PartyEntity> Parties { get; set; } = [];
}