using Microsoft.EntityFrameworkCore;

namespace Domain.Interfaces;

public interface IAppDbContext
{
    public DbSet<Candidate> Candidates { get; set; }
    public Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
