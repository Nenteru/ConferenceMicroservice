

using ConferenceMicroservice.Core.Interfaces;
using ConferenceMicroservice.Core.Models;

namespace ConferenceMicroservice.Application.Services;

public class ConferencesService : IConferencesService
{
    private readonly IConferencesRepository conferencesRepository;

    public ConferencesService(IConferencesRepository conferencesRepository)
    {
        this.conferencesRepository = conferencesRepository;
    }

    public async Task<List<User>> GetConferenceUsers(Guid conferenceId)
    {
        return await conferencesRepository.GetUsers(conferenceId);
    }

    public async Task<Guid> AddConferenceToUser(Guid conferenceId, Guid userId)
    {
        return await conferencesRepository.AddUser(conferenceId, userId);
    }

    public async Task<Guid> RemoveUserFromConference(Guid conferenceId, Guid userId)
    {
        return await conferencesRepository.RemoveUser(conferenceId, userId);
    }

    public async Task<List<Conference>> GetAllConferences()
    {
        return await conferencesRepository.Get();
    }

    public async Task<Guid> CreateConference(Conference conference)
    {
        return await conferencesRepository.Add(conference);
    }

    public async Task<Guid> UpdateConference(Guid id, string title, string description, DateTime dateTimeStart, DateTime dateTimeEnd)
    {
        return await conferencesRepository.Update(id, title, description, dateTimeStart, dateTimeEnd);
    }

    public async Task<Guid> DeleteConference(Guid conferenceId)
    {
        return await conferencesRepository.Delete(conferenceId);
    }
}
