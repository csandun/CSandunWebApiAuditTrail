﻿namespace CSandunWebApiAuditTrail.Models;

public class TodoItem: IAuditableEntity
{
    public long Id { get; set; }
    public string? Name { get; set; }
    public bool IsComplete { get; set; }
    
    // Soft delete capability
    public bool IsDelete { get; set; }
    
    //audit capability
    public Guid CreatedBy { get; set; }
    public DateTime CreatedOnUtc { get; set; }
    public Guid? ModifiedBy { get; set; }
    public DateTime? ModifiedOnUtc { get; set; }
    public Guid? DeletedBy { get; set; }
    public DateTime? DeletedOnUtc { get; set; }
}