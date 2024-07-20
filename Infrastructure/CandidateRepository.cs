using Domain;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure;

public class CandidateRepository : ICandidateRepository
{
    private readonly IAppDbContext _dbContext;

    public CandidateRepository(IAppDbContext dbContext) 
        => _dbContext = dbContext;

    public async Task<long?> AddCandidate(Candidate candidate, CancellationToken cancellationToken)
    {
        await _dbContext.Candidates.AddAsync(candidate, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return candidate.Id;
    }

    public async Task<Candidate?> Get(long id)
    {
        var candidate = await _dbContext.Candidates.FirstOrDefaultAsync(x => x.Id == id);
        return candidate;
    }

    public async Task<IEnumerable<Candidate>> GetAll(CancellationToken cancellationToken)
    {
        var candidates = QueryCandidates();
        return await candidates.ToListAsync(cancellationToken);
    }

    public async Task<Candidate> UpdateCandidate(Candidate candidate, CancellationToken cancellationToken)
    {
        _dbContext.Candidates.Update(candidate);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return candidate;
    }

    private IQueryable<Candidate> QueryCandidates(
        Expression<Func<Candidate, bool>>? filter = null,
        Func<IQueryable<Candidate>, IOrderedQueryable<Candidate>>? orderBy = null,
        bool trackChanges = false,
        bool ignoreQueryFilters = false)
    {
        var candidates = _dbContext.Candidates.AsQueryable();
        if (!trackChanges)
        {
            candidates = candidates.AsNoTracking();
        }

        if (ignoreQueryFilters)
        {
            candidates = candidates.IgnoreQueryFilters();
        }

        if (filter is not null)
        {
            candidates = candidates.Where(filter);
        }

        if (orderBy is not null)
        {
            candidates = orderBy(candidates);
        }

        return candidates;
    }
}
