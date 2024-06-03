namespace ConferenceMicroservice.API.Contracts;

public record ConferencesResponse(
    Guid id,
    string Title,
    string Description,
    DateTime DateTimeStart,
    DateTime DateTimeEnd);