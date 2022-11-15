using CSandunWebApiAuditTrail.Models;
using CSandunWebApiAuditTrail.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace CSandunWebApiAuditTrail.DbContextInterceptors;

public sealed class UpdateAuditableEntitiesInterceptor : SaveChangesInterceptor
{
    private readonly IUserMockService _userMockService;

    public UpdateAuditableEntitiesInterceptor(IUserMockService userMockService)
    {
        _userMockService = userMockService;
    }


    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData,
        InterceptionResult<int> result,
        CancellationToken cancellationToken = new CancellationToken())
    {
        var applicationUser = _userMockService.GetLoggedUser();

        var dbContext = eventData.Context;

        if (dbContext is null)
        {
            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }

        // track auditable changes Added / Modified states 
        var entries = dbContext.ChangeTracker.Entries<IAuditableEntity>();

        foreach (var entityEntry in entries)
        {
            switch (entityEntry.State)
            {
                case EntityState.Modified when entityEntry.Property(o => o.IsDelete).CurrentValue &&
                                               !entityEntry.Property(o => o.IsDelete).OriginalValue:
                    entityEntry.Property(o => o.DeletedOnUtc).CurrentValue = DateTime.UtcNow;
                    entityEntry.Property(o => o.DeletedBy).CurrentValue = applicationUser.Value;
                    continue;
                
                case EntityState.Modified:
                    entityEntry.Property(o => o.ModifiedOnUtc).CurrentValue = DateTime.UtcNow;
                    entityEntry.Property(o => o.ModifiedBy).CurrentValue = applicationUser.Value;
                    break;
                
                case EntityState.Added:
                    entityEntry.Property(o => o.CreatedOnUtc).CurrentValue = DateTime.UtcNow;
                    entityEntry.Property(o => o.CreatedBy).CurrentValue = applicationUser.Value;
                    break;
                
                case EntityState.Deleted:
                    entityEntry.Property(o => o.DeletedOnUtc).CurrentValue = DateTime.UtcNow;
                    entityEntry.Property(o => o.DeletedBy).CurrentValue = applicationUser.Value;
                    entityEntry.Property(o => o.IsDelete).CurrentValue = true;
                    entityEntry.State = EntityState.Modified;
                    break;

                default:
                    continue;
            }
        }

        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }
}