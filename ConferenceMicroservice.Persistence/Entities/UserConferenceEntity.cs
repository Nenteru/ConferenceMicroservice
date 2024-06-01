

using Microsoft.EntityFrameworkCore;

namespace ConferenceMicroservice.Persistence.Entities;

public class UserConferenceEntity
{
    public Guid UserId { get; set; }
    public Guid ConferenceId { get; set; }
    public FileInfo? File { get; set; }
}
