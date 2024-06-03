
using CSharpFunctionalExtensions;

namespace ConferenceMicroservice.Core.Models;

public class Conference
{
    public const int MAX_TITLE_LENGTH = 200;
    private Conference(Guid id, string title, string description, DateTime dateTimeStart, DateTime dateTimeEnd)
    {
        Id = id;
        Title = title;
        Descriptoin = description;
        DateTimeStart = dateTimeStart;
        DateTimeEnd = dateTimeEnd;
    }

    public Guid Id { get; }
    public string Title { get; private set; }
    public string Descriptoin { get; private set; }
    public DateTime DateTimeStart { get; private set; }
    public DateTime DateTimeEnd { get; private set; }

    // Связь с User (для связи Многие-Ко-Многим через UserConferenceEntity)
    public ICollection<UserConference>? UserConferences { get; private set; }

    public static Result<Conference> Create(Guid id, string title, string description, DateTime dateTimeStart, DateTime dateTimeEnd)
    {
        if(string.IsNullOrEmpty(title) || title.Length > MAX_TITLE_LENGTH)
        {
            return Result.Failure<Conference>($"{nameof(title)} cannot be null or empty");
        }

        if(string.IsNullOrEmpty(description))
        {
            return Result.Failure<Conference>($"{nameof(description)} cannot be null or empty");
        }

        var conference = new Conference(id, title, description, dateTimeStart, dateTimeEnd);

        return Result.Success(conference);
    }
}
