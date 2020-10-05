using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pattengoods.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pattengoods.Controllers
{
  public class CategoriesController : Controller
  {
    private readonly PattengoodsContext _db;

    public CategoriesController(PattengoodsContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Category> model = _db.Categories.ToList();
      return View(model);
    }

    public ActionResult Details(int id)
    {
      var thisCategory = _db.Categories
        .Include(category => category.Products)
        .ThenInclude(join => join.Product)
        .ThenInclude(product => product.Images)
        .FirstOrDefault(category => category.CategoryId == id);
      
      List<string> productNames = new List<string>();

      Dictionary<string, string> productImages = new Dictionary<string, string>();

      foreach(var join in thisCategory.Products)
      {
        if (join.Product.Images.Any())
        {
          string ImageData = Image.RetrieveImage(join.Product.Images[0]);

          productNames.Add(join.Product.ProductName);

          productImages.Add(join.Product.ProductName, ImageData);
        }
      }

      ViewBag.ProductNames = productNames;

      ViewBag.ImageDictionary = productImages;

      return View(thisCategory);
    }

    
  }
}