using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Pattengoods.Models
{
  public class UserProfile : User
  {
    public UserProfile()
    {
      this.PurchaseHistories = new HashSet<PurchaseHistory>();
    }

    public decimal PortfolioAmount { get; set; }

    public virtual ICollection<PurchaseHistory> PurchaseHistories { get; set; }
  }
}