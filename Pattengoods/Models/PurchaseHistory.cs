using System.Collections.Generic;

namespace Pattengoods.Models
{
  public class PurchaseHistory
  {
    // public PurchaseHistory()
    // {
    //   this.PurchaseDates = new List<string>();
    // }

    public int Id { get; set; }

    public int AmountPerPurchase { get; set; }

    public int ProductId { get; set; }

    public int UserProfileId { get; set; }

    public List<string> PurchaseDates = new List<string>();
  }
}