﻿using ConferenceMicroservice.Core.Interfaces;
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

    public async Task AddUserToConference(Guid userId, Guid conferenceId)
    {
        await usersRepository.AddConference(userId, conferenceId);
    }

    public async Task<List<Conference>> GetUserConferences(Guid userId)
    {
        return await usersRepository.GetConferences(userId);
    }

    public async Task RemoveConferenceFromUser(Guid userId, Guid conferenceId)
    {
        await usersRepository.RemoveConference(userId, conferenceId);
    }

    public async Task AddUserToOrganization(Guid userId, Guid organizationId)
    {
        await usersRepository.AddOrganization(userId, organizationId);
    }
}

