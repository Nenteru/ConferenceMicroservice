using ConferenceMicroservice.Core.Models;

namespace ConferenceMicroservice.Core.Interfaces;

public interface IConferencesRepository
{
    Task<Guid> Add(Conference conference);
    Task<Guid> AddUser(Guid conferenceId, Guid userId);
    Task<Guid> Delete(Guid id);
    Task<List<Conference>> Get();
    Task<List<Conference>> GetByFilter(DateTime start, DateTime end);
    Task<Conference> GetById(Guid id);
    Task<List<User>> GetUsers(Guid conferenceId);
    Task<Guid> RemoveUser(Guid conferenceId, Guid userId);
    Task<Guid> Update(Guid id, string title, string description, DateTime dateTimeStart, DateTime dateTimeEnd);
}