namespace Domain.Interfaces;

public interface ICandidateRepository
{
    Task<IEnumerable<Candidate>> GetAll(CancellationToken cancellationToken);
    Task<Candidate?> Get(long id);
    Task<long?> AddCandidate(Candidate candidate, CancellationToken cancellationToken);
    Task<Candidate> UpdateCandidate(Candidate candidate, CancellationToken cancellationToken);
}
