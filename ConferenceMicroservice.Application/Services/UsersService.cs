using ConferenceMicroservice.Core.Interfaces;
using ConferenceMicroservice.Core.Models;
using CSharpFunctionalExtensions;
using System.Reflection.Metadata.Ecma335;

namespace ConferenceMicroservice.Application.Services;

public class UserService : IUserService
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

    public async Task<Guid> CreateUser(string email, string passwordHash, string firstName, string secondName, string thirdName, string phoneNumber)
    {
        var user = User.Create(Guid.NewGuid(), email, passwordHash, firstName, secondName, thirdName, phoneNumber);

        // Проверка результат вызова Create.
        if (user.IsFailure)
        {
            //return Result.Failure<User>(user.Error);
            throw new Exception();
        }

        await usersRepository.Create(user.Value);

        //return Result.Success(user.Value);
        return user.Value.Id;
    }

    public async Task<Guid> UpdateUser(Guid id, string email, string passwordHash, string firstName, string secondName, string thirdName, string phoneNumber)
    {
        return await usersRepository.Update(id, email, passwordHash, firstName, secondName, thirdName, phoneNumber);
    }

    public async Task<Guid> DeleteUser(Guid id)
    {
        return await usersRepository.Delete(id);
    }

    public async Task AddUserToConference(Guid userId, Guid conferenceId)
    {
        await usersRepository.AddToConference(userId, conferenceId);
    }

    public async Task AddToOrganizaiotn(Guid userId, Guid organizationId)
    {
        await usersRepository.AddToOrganization(userId, organizationId);
    }
}

