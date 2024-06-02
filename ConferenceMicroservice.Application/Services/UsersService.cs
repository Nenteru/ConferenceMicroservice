using ConferenceMicroservice.Core.Interfaces;
using ConferenceMicroservice.Core.Models;
using CSharpFunctionalExtensions;
using System.Reflection.Metadata.Ecma335;

namespace ConferenceMicroservice.Application.Services;

public class UserService
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



    public async Task<Result<User>> CreateUserAsync(string email, string passwordHash, string firstName, string secondName, string thirdName, string phoneNumber)
    {
        var user = User.Create(Guid.NewGuid(), email, passwordHash, firstName, secondName, thirdName, phoneNumber);

        // Проверьте результат вызова Create.
        if (user.IsFailure)
        {
            return Result.Failure<User>(user.Error);
        }

        await usersRepository.Create(user.Value);

        return Result.Success(user.Value);
    }

    
}

