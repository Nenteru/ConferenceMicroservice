

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
            .OrderBy(c => c.TimeStart)
            .ToListAsync();
    }
    
    public async Task<List<ConferenceEntity>> GetWithUsers()
    {
        return await dbContext.Conferences
            .AsNoTracking()
            .OrderBy(c => c.TimeStart)
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
            query = query.Where(c => c.TimeStart >= start);
        }

        if (!(end == DateTime.MinValue))
        {
            query = query.Where(c => c.TimeEnd <= end);
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
            TimeStart = dateTimeStart, 
            TimeEnd = dateTimeEnd
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
            .SetProperty(c => c.TimeStart, dateTimeStart)
            .SetProperty(c => c.TimeEnd, dateTimeEnd));

    }
    
    public async Task Delete(Guid id)
    {
        await dbContext.Conferences
            .Where(c => c.Id == id)
            .ExecuteDeleteAsync();

    }
}
