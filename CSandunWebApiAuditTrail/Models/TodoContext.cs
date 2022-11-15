using Microsoft.EntityFrameworkCore;

namespace CSandunWebApiAuditTrail.Models;

public class TodoContext : DbContext
{
    public TodoContext(DbContextOptions<TodoContext> options)
        : base(options)
    {
    }

    public DbSet<TodoItem> TodoItems { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Query Filter
        modelBuilder.Entity<TodoItem>().HasQueryFilter(o => !o.IsDelete);


        modelBuilder.Entity<TodoItem>()
            .Property(o => o.Name)
            .IsRequired();
        modelBuilder.Entity<TodoItem>().Property(o => o.IsDelete)
            .HasDefaultValue(0)
            .IsRequired();
    }
}

//dotnet ef migrations add add-todos-isdelete-configs --project CSandunWebApiAuditTrail    
//dotnet ef database update --project CSandunWebApiAuditTrail    