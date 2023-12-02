namespace Bulkster_API.Models.Controller;

public class GetProgressResponse
{
    public Guid ClientId { get; set; }
    
    public short CaloriesLogged { get; set; }
    
    public DateOnly LogDate { get; set; }
}
