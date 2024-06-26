﻿using ConferenceMicroservice.Core.Models;

namespace ConferenceMicroservice.Core.Interfaces;

public interface IConferencesService
{
    Task<List<User>> GetConferenceUsers(Guid conferenceId);
    Task<Guid> AddConferenceToUser(Guid conferenceId, Guid userId);
    Task<Guid> CreateConference(Conference conference);
    Task<Guid> DeleteConference(Guid conferenceId);
    Task<List<Conference>> GetAllConferences();
    Task<Guid> RemoveUserFromConference(Guid conferenceId, Guid userId);
    Task<Guid> UpdateConference(Guid id, string title, string description, DateTime dateTimeStart, DateTime dateTimeEnd);
}