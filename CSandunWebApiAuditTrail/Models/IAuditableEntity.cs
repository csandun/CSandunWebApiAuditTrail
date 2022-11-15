namespace CSandunWebApiAuditTrail.Models;

public interface IAuditableEntity
{
    public bool IsDelete { get; set; }
    public Guid CreatedBy { get; set; }
    public DateTime CreatedOnUtc { get; set; }
    
    public Guid? ModifiedBy { get; set; }
    public DateTime? ModifiedOnUtc { get; set; }
    
    public Guid? DeletedBy { get; set; }
    public DateTime? DeletedOnUtc { get; set; }
    
}