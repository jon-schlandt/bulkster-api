using Bulkster_API.Models.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Bulkster_API.Data;

public class BulksterDbContext : DbContext, IBulksterDbContext
{
    public IDbContextTransaction? Transaction { get; set; }

    public BulksterDbContext(DbContextOptions<BulksterDbContext> options) : base(options)
    {
    }

    public async Task<IDbContextTransaction> BeginTransactionAsync()
    {
        return await Database.BeginTransactionAsync();
    }
    
    public DbSet<ActivityLevelEntity> ActivityLevel { get; set; } = null!;
    public DbSet<ClientEntity> Client { get; set; } = null!;
    public DbSet<GenderEntity> Gender { get; set; } = null!;
    public DbSet<IngredientEntity> Ingredient { get; set; } = null!;
    public DbSet<MealEntity> Meal { get; set; } = null!;
    public DbSet<ProgressLogEntity> ProgressLog { get; set; } = null!;
    public DbSet<SessionEntity> Session { get; set; } = null!;
}
