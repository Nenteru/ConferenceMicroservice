namespace ConferenceMicroservice.Persistence.Entities;

//public class UserEntity
//{
//    public Guid Id { get; set; }
//    public string FirstName { get; set; } = string.Empty;
//    public string SecondName { get; set; } = string.Empty;
//    public string ThirdName { get; set; } = string.Empty;
//    public string PhoneNumber { get; set; } = string.Empty;

//    // Organization part
//    public Guid OrganizationId { get; set; }
//    public OrganizationEntity? Organization { get; set; }

//    // Conference part
//    public ICollection<ConferenceEntity> Conferences { get; set; } = [];

//    // Chat part
//    public ICollection<ChatEntity> Chats { get; set; } = [];
//}

public class UserEntity
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string SecondName { get; set; } = string.Empty;
    public string ThirdName { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;

    // Связь с OrganizationEntity
    public Guid OrganizationId { get; set; }
    public OrganizationEntity Organization { get; set; } = null!;

    // Связь с PartyEntity (для связи Многие-Ко-Многим с ChatEntity)
    public ICollection<PartyEntity> Parties { get; set; } = [];

    // Связь с ConferenceEntity (для связи Многие-Ко-Многим через UserConferenceEntity)
    public ICollection<UserConferenceEntity> UserConferences { get; set; } = [];
}
