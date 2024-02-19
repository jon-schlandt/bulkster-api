namespace Bulkster_API.Models.Controller.AuthUser;

public class PostAuthUserResponse
{
    #region Constructors

    public PostAuthUserResponse(string authUserId)
    {
        AuthUserId = authUserId;
    }

    #endregion
    
    public string AuthUserId { get; set; }
}
