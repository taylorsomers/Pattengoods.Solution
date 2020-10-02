using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pattengoods.Models
{
  public class Category
  {
    public Category()
    {
      this.Products = new HashSet<CategoryProduct>();
    }

    public int CategoryId { get; set; }

    [Required(ErrorMessage = "Title is Required")]
    [StringLength(255)]
    public string Title { get; set; }

    public virtual ICollection<CategoryProduct> Products { get; set; }
  }
}