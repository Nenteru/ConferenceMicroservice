﻿

namespace ConferenceMicroservice.Persistence.Entities;

public class ConferenceEntity
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime DateTimeStart { get; set; }
    public DateTime DateTimeEnd { get; set; }

    // Связь с UserEntity (для связи Многие-Ко-Многим через UserConferenceEntity)
    public ICollection<UserConferenceEntity>? UserConferences { get; set; } = [];
}