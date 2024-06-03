using ConferenceMicroservice.Core.Models;

namespace ConferenceMicroservice.Core.Interfaces;

public interface IUsersService
{
    Task<List<Conference>> GetUserConferences(Guid userId);
    Task<Guid> AddUserToOrganization(Guid userId, Guid organizationId);
    Task<Guid> AddUserToConference(Guid userId, Guid conferenceId);
    Task<Guid> RemoveConferenceFromUser(Guid userId, Guid conferenceId);
    Task<Guid> CreateUser(User user);
    Task<Guid> DeleteUser(Guid userId);
    Task<List<User>> GetAllUsers();
    Task<Guid> UpdateUser(Guid id, string email, string passwordHash, string firstName, string secondName, string thirdName, string phoneNumber);
}