using ConferenceMicroservice.Persistence.Entities;

namespace ConferenceMicroservice.Persistence.Repositories;

public class OrganizationsRepository
{
    private readonly ConferenceMicroserviceDbContext dbContext;

    public OrganizationsRepository(ConferenceMicroserviceDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    public async Task AddToUser(Guid userId, string organizationName, string organizationNumber, string organizationPlace)
    {
        var user = await dbContext.Users.FindAsync(userId) 
            ?? throw new Exception();

        var organization = new OrganizationEntity 
        { 
            Name = organizationName, 
            Number = organizationNumber, 
            Place = organizationPlace 
        };

        await dbContext.Organizations.AddAsync(organization);

        user.Organization = organization;

        await dbContext.SaveChangesAsync();
    }

    public async Task AddDivision(Guid organizaitonId, string name, string number, string place)
    {
        var organization = await dbContext.Organizations.FindAsync(organizaitonId)
            ?? throw new Exception();

        var division = new OrganizationDivisionEntity
        {
            Name = name,
            Number = number,
            Place = place,
        };

        await dbContext.Divisions.AddAsync(division);

        organization?.Divisions?.Add(division);

        await dbContext.SaveChangesAsync();
    }
}