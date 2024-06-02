namespace ConferenceMicroservice.API.Contracts;


//Guid id, string email, string passwordHash, string firstName, string secondName, string thirdName, string phoneNumber
public record UsersResponse(
    Guid Id,
    string Email,
    string FirstName,
    string SecondName,
    string ThirdName,
    string? PhoneNumber);