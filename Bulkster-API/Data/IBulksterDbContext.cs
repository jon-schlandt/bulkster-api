using Bulkster_API.Models.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace Bulkster_API.Data;

public interface IBulksterDbContext
{
    DatabaseFacade Database { get; }
    
    IDbContextTransaction? Transaction { get; set; }

    Task<IDbContextTransaction> BeginTransactionAsync();
    
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    
    DbSet<ActivityLevelEntity> ActivityLevel { get; set; }
    DbSet<AuthUserEntity> AuthUser { get; set; }
    DbSet<ClientEntity> Client { get; set; }
    DbSet<GenderEntity> Gender { get; set; }
    DbSet<IngredientEntity> Ingredient { get; set; }
    DbSet<MealEntity> Meal { get; set; }
    DbSet<ProgressLogEntity> ProgressLog { get; set; }
}
