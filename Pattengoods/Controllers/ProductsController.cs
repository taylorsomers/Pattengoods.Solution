using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pattengoods.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Pattengoods.Controllers
{
  public class ProductsController : Controller
  {
    private readonly PattengoodsContext _db;

    public ProductsController(PattengoodsContext db)
    {
      _db = db;
    }

    public ActionResult Details(int id)
    {
      var thisProduct = _db.Products
        .Include(category => category.Categories)
          .ThenInclude(join => join.Category)
        .Include(product => product.Images)
        .FirstOrDefault(product => product.ProductId == id);
      
      List<string> ImageData = new List<string>();

      foreach (var image in thisProduct.Images)
      {
        ImageData.Add(Image.RetrieveImage(image));
      }

      ViewBag.ImageDataURL = ImageData;

      return View(thisProduct);
    }
  }
}