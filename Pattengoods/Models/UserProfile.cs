using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Pattengoods.Models
{
  public class UserProfile
  {
    public UserProfile()
    {
      this.PurchaseHistories = new HashSet<PurchaseHistory>();
    }

    public int Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public decimal PortfolioAmount { get; set; }

    public virtual ICollection<PurchaseHistory> PurchaseHistories { get; set; }
  }
}