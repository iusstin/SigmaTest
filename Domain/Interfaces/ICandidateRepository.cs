namespace Domain.Interfaces;

public interface ICandidateRepository
{
    Task<IEnumerable<Candidate>> GetAll(CancellationToken cancellationToken);
    Task<Candidate?> GetByEmail(string email);
    Task<Candidate?> CreateCandidate(Candidate candidate, CancellationToken cancellationToken);
    Task<Candidate> UpdateCandidate(Candidate candidate, CancellationToken cancellationToken);
}
