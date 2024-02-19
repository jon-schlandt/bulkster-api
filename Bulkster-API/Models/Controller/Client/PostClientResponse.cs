namespace Bulkster_API.Models.Controller.Client;

public class PostClientResponse
{
    public Guid ClientId { get; set; }
    
    #region Constructors

    public PostClientResponse(Guid clientId)
    {
        ClientId = clientId;
    }
    
    #endregion
}
