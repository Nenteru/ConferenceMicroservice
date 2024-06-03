using ConferenceMicroservice.Core.Models;

namespace ConferenceMicroservice.Core.Interfaces;

public interface IUsersRepository
{
    Task<Guid> Add(User user);
    Task<Guid> AddConference(Guid userId, Guid conferenceId);
    Task<Guid> AddOrganization(Guid userId, Guid organizationId);
    Task<Guid> Delete(Guid id);
    Task<List<User>> Get();
    Task<User> GetByEmail(string email);
    Task<List<Conference>> GetConferences(Guid userId);
    Task<Guid> RemoveConference(Guid userId, Guid conferenceId);
    Task<Guid> Update(Guid id, string email, string passwordHash, string firstName, string secondName, string thirdName, string phoneNumber);
}