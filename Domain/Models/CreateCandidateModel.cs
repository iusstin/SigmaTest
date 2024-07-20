namespace Domain.Models;

public record CreateCandidateModel(
    string? FirstName = null,
    string? LastName = null,
    string? Email = null,
    string? Comment = null,
    string? PhoneNumber = null,
    DateTime? StartCallTimeInterval = null,
    DateTime? EndCallTimeInterval = null,
    string? LinkedInProfile = null,
    string? GitHubProfile = null);
