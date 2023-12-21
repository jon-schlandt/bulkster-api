namespace Bulkster_API.Models.Controller.Client;

public class InitializeClientResponse
{
    public Guid ClientId { get; set; }
    
    #region Constructors

    public InitializeClientResponse(Guid clientId)
    {
        ClientId = clientId;
    }
    
    #endregion
}
