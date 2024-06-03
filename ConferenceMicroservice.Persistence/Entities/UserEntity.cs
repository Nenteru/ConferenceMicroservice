using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ConferenceMicroservice.Persistence.Entities;

public class UserEntity
{
    public Guid Id { get; set; }
    public string Email { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string SecondName { get; set; } = string.Empty;
    public string ThirdName { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;

    // Связь с OrganizationEntity
    public Guid? OrganizationId { get; set; }
    public OrganizationEntity? Organization { get; set; }

    // Связь с PartyEntity (для связи Многие-Ко-Многим с ChatEntity)
    public ICollection<PartyEntity>? Parties { get; set; } = [];

    // Связь с ConferenceEntity (для связи Многие-Ко-Многим через UserConferenceEntity)
    public ICollection<UserConferenceEntity>? UserConferences { get; set; } = [];
}