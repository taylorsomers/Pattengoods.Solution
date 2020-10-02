using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pattengoods.Models
{
  public class Product
  {
    public Product()
    {
      this.Categories = new HashSet<CategoryProduct>();
      this.Images = new List<Image>();
    }

    public int ProductId { get; set; }

    public string ProductDescription { get; set; }

    public string ProductManufacturer { get; set; }

    public string ProductName { get; set; }

    public decimal ProductPrice { get; set; }

    public List<Image> Images { get; set; }

    public virtual ICollection<CategoryProduct> Categories { get; set; }
  }
}