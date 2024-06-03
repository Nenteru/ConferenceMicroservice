

using ConferenceMicroservice.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace ConferenceMicroservice.Persistence.Repositories;

public class ConferencesRepository
{
    private readonly ConferenceMicroserviceDbContext dbContext;

    public ConferencesRepository(ConferenceMicroserviceDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<List<ConferenceEntity>> Get()
    {
        return await dbContext.Conferences
            .AsNoTracking()
            .OrderBy(c => c.DateTimeStart)
            .ToListAsync();
    }
    
    public async Task<List<ConferenceEntity>> GetWithUsers()
    {
        return await dbContext.Conferences
            .AsNoTracking()
            .OrderBy(c => c.DateTimeStart)
            .Include(c => c.UserConferences)
            .ToListAsync();
    }

    public async Task<ConferenceEntity?> GetById(Guid id)
    {
        return await dbContext.Conferences
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<List<ConferenceEntity>> GetByFilter(DateTime start, DateTime end)
    {
        var query = dbContext.Conferences.AsNoTracking();

        if(!(start == DateTime.MinValue))
        {
            query = query.Where(c => c.DateTimeStart >= start);
        }

        if (!(end == DateTime.MinValue))
        {
            query = query.Where(c => c.DateTimeEnd <= end);
        }

        return await query.ToListAsync();
    }

    public async Task Add(Guid id, string title, string description, DateTime dateTimeStart, DateTime dateTimeEnd)
    {
        var conferenceEntity = new ConferenceEntity 
        { 
            Id = id,
            Title = title, 
            Description = description, 
            DateTimeStart = dateTimeStart, 
            DateTimeEnd = dateTimeEnd
        };

        await dbContext.AddAsync(conferenceEntity);
        await dbContext.SaveChangesAsync();
    }

    public async Task Update(Guid id, string title, string description, DateTime dateTimeStart, DateTime dateTimeEnd)
    {
        await dbContext.Conferences
            .Where(c => c.Id == id)
            .ExecuteUpdateAsync(s =>s
            .SetProperty(c => c.Title, title)
            .SetProperty(c => c.Description, description)
            .SetProperty(c => c.DateTimeStart, dateTimeStart)
            .SetProperty(c => c.DateTimeEnd, dateTimeEnd));

    }
    
    public async Task Delete(Guid id)
    {
        await dbContext.Conferences
            .Where(c => c.Id == id)
            .ExecuteDeleteAsync();

    }
}
