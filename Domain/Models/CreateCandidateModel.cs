namespace Domain.Models;

public record CreateCandidateModel(
    string FirstName,
    string LastName,
    string Email,
    string Comment,
    string? PhoneNumber = null,
    DateTime? StartCallTimeInterval = null,
    DateTime? EndCallTimeInterval = null,
    string? LinkedInProfile = null,
    string? GitHubProfile = null);
