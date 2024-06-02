namespace ConferenceMicroservice.API.Contracts;

public record UsersRequest(
    string Email,
    string PasswordHash,
    string FirstName,
    string SecondName,
    string ThirdName,
    string? PhoneNumber);
