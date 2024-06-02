

using CSharpFunctionalExtensions;

namespace ConferenceMicroservice.Core.Models;

public class User
{
    private User(Guid id, string email, string passwordHash, string firstName, string secondName, string thirdName, string phoneNumber)
    {
        Id = id;
        Email = email;
        PasswordHash = passwordHash;
        FirstName = firstName;
        SecondName = secondName;
        ThirdName = thirdName;
        PhoneNumber = phoneNumber;
    }
    public Guid Id { get; }
    public string FirstName { get; } = string.Empty;
    public string SecondName { get; } = string.Empty;
    public string ThirdName { get; } = string.Empty;
    public string PhoneNumber { get; } = string.Empty;
    public string Email { get; } = string.Empty;
    public string PasswordHash { get; } = string.Empty;

    // Связь с Organization
    public Organization? Organization { get; private set; }

    // Связь с Party (для связи Многие-Ко-Многим с ChatEntity)
    public ICollection<Party>? Parties { get; private set; } = [];

    // Связь с Conference (для связи Многие-Ко-Многим через UserConferenceEntity)
    public ICollection<UserConference>? UserConferences { get; private set; } = [];

    public static Result<User> Create(Guid id, string email, string passwordHash, string firstName, string secondName, string thirdName, string phoneNumber)
    {
        if(string.IsNullOrWhiteSpace(email))
        {
            return Result.Failure<User>($"{nameof(Email)} cannot be null or empty");
        }
        if (string.IsNullOrWhiteSpace(passwordHash))
        {
            return Result.Failure<User>($"{nameof(passwordHash)} cannot be null or empty");
        }
        if (string.IsNullOrWhiteSpace(firstName))
        {
            return Result.Failure<User>($"{nameof(firstName)} cannot be null or empty");
        }
        if (string.IsNullOrWhiteSpace(secondName))
        {
            return Result.Failure<User>($"{nameof(secondName)} cannot be null or empty");
        }
        if (string.IsNullOrWhiteSpace(thirdName))
        {
            return Result.Failure<User>($"{nameof(thirdName)} cannot be null or empty");
        }
        if (string.IsNullOrWhiteSpace(phoneNumber))
        {
            return Result.Failure<User>($"{nameof(phoneNumber)} cannot be null or empty");
        }

        var user = new User(id, email, passwordHash, firstName, secondName, thirdName, phoneNumber);

        return Result.Success<User>(user);
    }
}

public class Organization
{

}

public class Party
{

}

public class UserConference
{

}