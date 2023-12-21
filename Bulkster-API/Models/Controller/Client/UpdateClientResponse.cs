namespace Bulkster_API.Models.Controller.Client;

public class UpdateClientResponse
{
    public Guid ClientId { get; set; }
    
    #region Constructors

    public UpdateClientResponse(Guid clientId)
    {
        ClientId = clientId;
    }
    
    #endregion
}
