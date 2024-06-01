namespace ConferenceMicroservice.Persistence.Entities;

public class UserEntity
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string SecondName { get; set; } = string.Empty;
    public string ThirdName { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;

    // Organization part
    public Guid OrganizationId { get; set; }
    public OrganizationEntity? Organization { get; set; }

    // Conference part
    public ICollection<ConferenceEntity> Conferences { get; set; } = [];

    // Chat part
    public ICollection<ChatEntity> Chats { get; set; } = [];
    
}