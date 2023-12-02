using Bulkster_API.Models.Repository;
using Microsoft.EntityFrameworkCore;

namespace Bulkster_API.Data;

public interface IBulksterDbContext
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    
    public DbSet<ActivityLevelEntity> ActivityLevel { get; set; }
    public DbSet<ClientEntity> Client { get; set; }
    public DbSet<GenderEntity> Gender { get; set; }
    public DbSet<ProgressLogEntity> ProgressLog { get; set; }
    public DbSet<SessionEntity> Session { get; set; }
}
