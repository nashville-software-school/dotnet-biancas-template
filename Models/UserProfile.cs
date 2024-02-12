using Microsoft.AspNetCore.Identity;

namespace BiancasBikes.Models;

public class UserProfile : IdentityUser<int>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Address { get; set; }
    public List<WorkOrder> WorkOrders { get; set; }
}