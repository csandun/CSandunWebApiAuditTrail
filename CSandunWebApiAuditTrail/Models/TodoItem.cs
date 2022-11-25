using Audit.EntityFramework;

namespace CSandunWebApiAuditTrail.Models;

public class TodoItem: IAuditableEntity
{
    public long Id { get; set; }
    public string? Name { get; set; }
    public bool IsComplete { get; set; }
    
    // Soft delete capability
    public bool IsDelete { get; set; }
    
    [AuditIgnore]
    //audit capability
    public Guid CreatedBy { get; set; }
    [AuditIgnore]
    public DateTime CreatedOnUtc { get; set; }
    [AuditIgnore]
    public Guid? ModifiedBy { get; set; }
    [AuditIgnore]
    public DateTime? ModifiedOnUtc { get; set; }
    [AuditIgnore]
    public Guid? DeletedBy { get; set; }
    [AuditIgnore]
    public DateTime? DeletedOnUtc { get; set; }
}