using ConferenceMicroservice.Core.Models;

namespace ConferenceMicroservice.Core.Interfaces
{
    public interface IUsersRepository
    {
        Task<List<Conference>> GetConferences(Guid userId);
        Task AddToConference(Guid userId, Guid conferenceId);
        Task RemoveFromConference(Guid userId, Guid conferenceId);
        Task AddToOrganization(Guid userId, Guid organizationId);
        Task<Guid> Add(User user);
        Task<Guid> Delete(Guid id);
        Task<List<User>> Get();
        Task<User> GetByEmail(string email);
        Task<Guid> Update(Guid id, string email, string passwordHash, string firstName, string secondName, string thirdName, string phoneNumber);
    }
}