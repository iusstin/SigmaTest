namespace Domain;

public class Candidate
{
    public long Id { get; set; }

    public required string Email { get; set; }

    public required string FirstName { get; set; }

    public required string LastName { get; set; }

    public string? PhoneNumber { get; set; }

    public DateTime? StartCallTimeInterval { get; set; }

    public DateTime? EndCallTimeIntervall { get; set; }

    public string? LinkedInProfile { get; set; }

    public string? GitHubProfile { get; set; }

    public required string Comment { get; set; }
}
