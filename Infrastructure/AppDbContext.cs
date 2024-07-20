using Domain;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infrastructure;

public class AppDbContext : DbContext, IAppDbContext
{
    private readonly IConfiguration _config;

    public AppDbContext(DbContextOptions<AppDbContext> options, IConfiguration config)
        : base(options)
    {
        _config = config;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        builder.UseSqlServer(_config.GetConnectionString("AppDbContext"));
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }

    public async Task<int> SaveChangesAsync()
    {
        return await base.SaveChangesAsync();
    }

    public DbSet<Candidate> Candidates { get; set; }
}
