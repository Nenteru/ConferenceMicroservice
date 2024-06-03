namespace ConferenceMicroservice.API.Contracts;

public record UsersResponse(
    Guid Id,
    string Email,
    string FirstName,
    string SecondName,
    string ThirdName,
    string PhoneNumber);
