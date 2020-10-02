using Microsoft.AspNetCore.Identity;

namespace Pattengoods.Models
{
  public class User : IdentityUser
  {
    public string FirstName { get; set; }

    public string LastName { get; set; }
  }
}