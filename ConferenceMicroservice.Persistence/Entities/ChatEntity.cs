namespace ConferenceMicroservice.Persistence.Entities;

public class ChatEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTime DateTimeCreate { get; set; }

    // User part
    public ICollection<UserEntity> Users { get; set; } = [];
}
