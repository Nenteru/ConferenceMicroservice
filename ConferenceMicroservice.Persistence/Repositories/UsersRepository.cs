using ConferenceMicroservice.Core.Interfaces;
using ConferenceMicroservice.Core.Models;
using ConferenceMicroservice.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace ConferenceMicroservice.Persistence.Repositories;

public class UsersRepository : IUsersRepository
{
    private readonly ConferenceMicroserviceDbContext dbContext;

    public UsersRepository(ConferenceMicroserviceDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<List<User>> Get()
    {
        var userEntities = await dbContext.Users
            .AsNoTracking()
            .ToListAsync();

        var users = userEntities
            .Select(u => User.Create(u.Id, u.Email, u.PasswordHash, u.FirstName, u.SecondName, u.ThirdName, u.PhoneNumber).Value)
            .ToList();

        return users;
    }

    public async Task<Guid> Create(User user)
    {
        var userEntity = new UserEntity
        {
            Id = user.Id,
            Email = user.Email,
            PasswordHash = user.PasswordHash,
            FirstName = user.FirstName,
            SecondName = user.SecondName,
            ThirdName = user.ThirdName,
            PhoneNumber = user.PhoneNumber,
        };

        await dbContext.AddAsync(userEntity);
        await dbContext.SaveChangesAsync();

        return userEntity.Id;
    }

    public async Task<Guid> Update(Guid id, string email, string passwordHash, string firstName, string secondName, string thirdName, string phoneNumber)
    {
        await dbContext.Users
            .Where(u => u.Id == id)
            .ExecuteUpdateAsync(s => s
                .SetProperty(u => u.Email, email)
                .SetProperty(u => u.PasswordHash, passwordHash)
                .SetProperty(u => u.FirstName, firstName)
                .SetProperty(u => u.SecondName, secondName)
                .SetProperty(u => u.ThirdName, thirdName)
                .SetProperty(u => u.PhoneNumber, phoneNumber));

        return id;
    }

    public async Task<Guid> Delete(Guid id)
    {
        await dbContext.Users
            .Where(u => u.Id == id)
            .ExecuteDeleteAsync();

        return id;
    }

    public async Task AddToConference(User userId, Guid conferenceId)
    {
        var conferenceEntity = await dbContext.Conferences.FindAsync(conferenceId)
            ?? throw new Exception();

        var userEntity = await dbContext.Users.FindAsync(userId)
            ?? throw new Exception();

        dbContext.UserConferences.Add(new UserConferenceEntity { User = userEntity, Conference = conferenceEntity });
    }

    public async Task AddToOrganization(Guid userId, Guid organizationId)
    {
        var organizationEntity = await dbContext.Organizations.FindAsync(organizationId)
            ?? throw new Exception();

        var userEntity = await dbContext.Users.FindAsync(userId)
            ?? throw new Exception();

        userEntity.Organization = organizationEntity;
    }
}