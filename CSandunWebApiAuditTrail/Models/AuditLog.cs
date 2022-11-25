using Audit.EntityFramework;

namespace CSandunWebApiAuditTrail.Models;

[AuditIgnore]
public class AuditLog
{
    public int Id { get; set; }
    public string AuditData { get; set; }
    public string EntityType { get; set; }
    public DateTime AuditDateTimeUtc { get; set; }
    public Guid? UserId { get; set; }
    public string? UserName { get; set; }
    public string TablePk { get; set; }

    public string Action { get; set; }
    
    
}