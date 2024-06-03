

using ConferenceMicroservice.Core.Interfaces;
using ConferenceMicroservice.Core.Models;
using ConferenceMicroservice.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace ConferenceMicroservice.Persistence.Repositories;

public class ConferencesRepository : IConferencesRepository
{
    private readonly ConferenceMicroserviceDbContext dbContext;

    public ConferencesRepository(ConferenceMicroserviceDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<List<Conference>> Get()
    {
        var conferenceEntities = await dbContext.Conferences
            .AsNoTracking()
            .OrderBy(c => c.DateTimeStart)
            .ToListAsync();

        var conferences = conferenceEntities
            .Select(c => Conference.Create(c.Id, c.Title, c.Description, c.DateTimeStart, c.DateTimeEnd).Value)
            .ToList();

        return conferences;
    }

    public async Task<List<User>> GetUsers(Guid conferenceId)
    {
        var userConferenceEntities = await dbContext.UserConferences
            .Where(uc => uc.ConferenceId == conferenceId).ToListAsync();

        var userEntities = userConferenceEntities
            .Select(uc => uc.User).ToList();

        var users = userEntities
            .Select(u => User.Create(u.Id, u.Email, u.PasswordHash, u.FirstName, u.SecondName, u.ThirdName, u.PhoneNumber).Value)
            .ToList();

        return users;
    }

    //public async Task<List<ConferenceEntity>> GetWithUsers()
    //{
    //    return await dbContext.Conferences
    //        .AsNoTracking()
    //        .OrderBy(c => c.DateTimeStart)
    //        .Include(c => c.UserConferences)
    //        .ToListAsync();
    //}

    public async Task<Conference> GetById(Guid id)
    {
        var conferenceEntity = await dbContext.Conferences
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.Id == id) ?? throw new Exception(); ;

        var conference = Conference.Create(
            conferenceEntity.Id,
            conferenceEntity.Title,
            conferenceEntity.Description,
            conferenceEntity.DateTimeStart,
            conferenceEntity.DateTimeEnd);

        return conference.Value;
    }

    public async Task<List<Conference>> GetByFilter(DateTime start, DateTime end)
    {
        var query = dbContext.Conferences.AsNoTracking();

        if (!(start == DateTime.MinValue))
        {
            query = query.Where(c => c.DateTimeStart >= start);
        }

        if (!(end == DateTime.MinValue))
        {
            query = query.Where(c => c.DateTimeEnd <= end);
        }

        var conferences = await query.Select(c => Conference.Create(c.Id, c.Title, c.Description, c.DateTimeStart, c.DateTimeEnd).Value).ToListAsync();

        return conferences;
    }

    public async Task<Guid> Add(Conference conference)
    {
        var conferenceEntity = new ConferenceEntity
        {
            Id = conference.Id,
            Title = conference.Title,
            Description = conference.Descriptoin,
            DateTimeStart = conference.DateTimeStart,
            DateTimeEnd = conference.DateTimeEnd
        };

        await dbContext.AddAsync(conferenceEntity);
        await dbContext.SaveChangesAsync();

        return conference.Id;
    }

    public async Task<Guid> Update(Guid id, string title, string description, DateTime dateTimeStart, DateTime dateTimeEnd)
    {
        await dbContext.Conferences
            .Where(c => c.Id == id)
            .ExecuteUpdateAsync(s => s
            .SetProperty(c => c.Title, title)
            .SetProperty(c => c.Description, description)
            .SetProperty(c => c.DateTimeStart, dateTimeStart)
            .SetProperty(c => c.DateTimeEnd, dateTimeEnd));

        return id;
    }

    public async Task<Guid> Delete(Guid id)
    {
        await dbContext.Conferences
            .Where(c => c.Id == id)
            .ExecuteDeleteAsync();

        return id;
    }

    public async Task<Guid> AddUser(Guid conferenceId, Guid userId)
    {
        var conferenceEntity = await dbContext.Conferences.FindAsync(conferenceId)
            ?? throw new Exception();

        var userEntity = await dbContext.Users.FindAsync(userId)
            ?? throw new Exception();

        dbContext.UserConferences.Add(new UserConferenceEntity { User = userEntity, Conference = conferenceEntity });

        await dbContext.SaveChangesAsync();

        return userId;
    }

    public async Task<Guid> RemoveUser(Guid conferenceId, Guid userId)
    {
        var userConferenceEntity = await dbContext.UserConferences
            .Where(uc => uc.UserId == userId && uc.ConferenceId == conferenceId)
            .FirstOrDefaultAsync()
            ?? throw new Exception();

        dbContext.UserConferences.Remove(userConferenceEntity);

        await dbContext.SaveChangesAsync();

        return userId;
    }
}
