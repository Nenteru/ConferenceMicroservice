namespace ConferenceMicroservice.API.Contracts;

public record ConferencesRequest(
    string Title,
    string Description,
    DateTime DateTimeStart,
    DateTime DateTimeEnd);