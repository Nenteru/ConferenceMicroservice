

using Microsoft.EntityFrameworkCore;

namespace ConferenceMicroservice.Persistence.Entities;

public class UserConferenceEntity
{
    public FileInfo? File { get; set; }

    // Связь с UserEntity
    public Guid UserId { get; set; }
    public UserEntity? User { get; set; }

    // Связь с ConferenceEntity
    public Guid ConferenceId { get; set; }
    public ConferenceEntity? Conference { get; set; }
}
