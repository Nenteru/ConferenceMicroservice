using ConferenceMicroservice.Core.Interfaces;
using ConferenceMicroservice.Core.Models;

namespace ConferenceMicroservice.Application.Services;

public class UserService : IUsersService
{
    private readonly IUsersRepository usersRepository;

    public UserService(IUsersRepository usersRepository)
    {
        this.usersRepository = usersRepository;
    }

    public async Task<List<User>> GetAllUsers()
    {
        return await usersRepository.Get();
    }

    public async Task<Guid> CreateUser(User user)
    {
        return await usersRepository.Add(user);
    }

    public async Task<Guid> UpdateUser(Guid id, string email, string passwordHash, string firstName, string secondName, string thirdName, string phoneNumber)
    {
        return await usersRepository.Update(id, email, passwordHash, firstName, secondName, thirdName, phoneNumber);
    }

    public async Task<Guid> DeleteUser(Guid userId)
    {
        return await usersRepository.Delete(userId);
    }

    public async Task<Guid> AddUserToConference(Guid userId, Guid conferenceId)
    {
        return await usersRepository.AddConference(userId, conferenceId);
    }

    public async Task<List<Conference>> GetUserConferences(Guid userId)
    {
        return await usersRepository.GetConferences(userId);
    }

    public async Task<Guid> RemoveConferenceFromUser(Guid userId, Guid conferenceId)
    {
        return await usersRepository.RemoveConference(userId, conferenceId);
    }

    public async Task<Guid> AddUserToOrganization(Guid userId, Guid organizationId)
    {
        return await usersRepository.AddOrganization(userId, organizationId);
    }
}

