using ConferenceMicroservice.Core.Models;

namespace ConferenceMicroservice.Core.Interfaces
{
    public interface IUserService
    {
        Task AddToOrganizaiotn(Guid userId, Guid organizationId);
        Task AddUserToConference(Guid userId, Guid conferenceId);
        Task<Guid> CreateUser(string email, string passwordHash, string firstName, string secondName, string thirdName, string phoneNumber);
        Task<Guid> DeleteUser(Guid id);
        Task<List<User>> GetAllUsers();
        Task<Guid> UpdateUser(Guid id, string email, string passwordHash, string firstName, string secondName, string thirdName, string phoneNumber);
    }
}