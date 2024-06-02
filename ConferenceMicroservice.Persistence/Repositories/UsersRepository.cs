using ConferenceMicroservice.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace ConferenceMicroservice.Persistence.Repositories;

public class UsersRepository
{
    private readonly ConferenceMicroserviceDbContext dbContext;

    public UsersRepository(ConferenceMicroserviceDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task Add(Guid id, string email, string passwordHash, string firstName, string secondName, string thirdName, string phoneNumber)
    {
        var userEntity = new UserEntity
        {
            Id = id,
            Email = email,
            PasswordHash = passwordHash,
            FirstName = firstName,
            SecondName = secondName,
            ThirdName = thirdName,
            PhoneNumber = phoneNumber,
        };

        await dbContext.AddAsync(userEntity);
        await dbContext.SaveChangesAsync();
    }

    public async Task AddToConference(Guid conferenceId, UserEntity userEntity)
    {
        var conference = await dbContext.Conferences.FindAsync(conferenceId)
            ?? throw new Exception();

        dbContext.UserConferences.Add(new UserConferenceEntity { User = userEntity, Conference = conference });
    }

    public async Task AddToOrganization(Guid organizationId, UserEntity userEntity)
    {
        var organization = await dbContext.Organizations.FindAsync(organizationId)
            ?? throw new Exception();

        userEntity.Organization = organization;
    }
}
