using Bulkster_API.Models.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace Bulkster_API.Data;

public interface IBulksterDbContext
{
    public DatabaseFacade Database { get; }
    
    public IDbContextTransaction? Transaction { get; set; }

    Task<IDbContextTransaction> BeginTransactionAsync();
    
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    
    public DbSet<ActivityLevelEntity> ActivityLevel { get; set; }
    public DbSet<ClientEntity> Client { get; set; }
    public DbSet<GenderEntity> Gender { get; set; }
    public DbSet<IngredientEntity> Ingredient { get; set; }
    public DbSet<MealEntity> Meal { get; set; }
    public DbSet<ProgressLogEntity> ProgressLog { get; set; }
    public DbSet<SessionEntity> Session { get; set; }
}
