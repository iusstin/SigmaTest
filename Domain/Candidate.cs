using System.ComponentModel.DataAnnotations;

namespace Domain;

public class Candidate
{
    [Key]
    public long Id { get; set; }

    [Required]
    public string FirstName { get; set; }

    [Required]
    public string LastName { get; set; }

    public string PhoneNumber { get; set; }

    [Required]
    public string Email { get; set; }

    public string LinkedInProfile { get; set; }

    public string GitHubProfile { get; set; }

    public string Comment { get; set; }
}
