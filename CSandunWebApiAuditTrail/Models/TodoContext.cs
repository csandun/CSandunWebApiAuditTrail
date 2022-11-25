using Audit.EntityFramework;
using CSandunWebApiAuditTrail.DbContextInterceptors;
using Microsoft.EntityFrameworkCore;

namespace CSandunWebApiAuditTrail.Models;

public class TodoContext: DbContext
{
    public TodoContext(DbContextOptions<TodoContext> options)
        : base(options)
    {
    }

    public DbSet<TodoItem> TodoItems { get; set; } = null!;

    public DbSet<AuditLog> AuditLogs { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
       
       // optionsBuilder.AddInterceptors(new AuditSaveChangesInterceptor());
        base.OnConfiguring(optionsBuilder);
    }

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