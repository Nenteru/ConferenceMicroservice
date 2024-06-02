

namespace ConferenceMicroservice.Persistence.Entities;

public class UserConferenceEntity
{
    public string File { get; set; } = string.Empty;

    // Связь с UserEntity
    public Guid UserId { get; set; }
    public UserEntity? User { get; set; }

    // Связь с ConferenceEntity
    public Guid ConferenceId { get; set; }
    public ConferenceEntity? Conference { get; set; }
}
