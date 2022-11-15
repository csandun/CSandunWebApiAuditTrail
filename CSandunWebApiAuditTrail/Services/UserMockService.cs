namespace CSandunWebApiAuditTrail.Services;

public class UserMockService: IUserMockService
{
    private Guid ApplicationUserGuid = new Guid("a01e905c-06d3-4150-bdbf-dc49abeab4b2");
    
    public Guid? GetLoggedUser()
    {
        return ApplicationUserGuid;
    }
}