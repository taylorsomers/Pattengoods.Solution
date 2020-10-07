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

    public ActionResult Create()
    {
      ViewBag.CategoryId = _db.Categories.ToList();
      return View();
    }

    [HttpPost]
    public ActionResult Create(Product product, int[] CategoryId)
    {
      _db.Products.Add(product);
      foreach(int id in CategoryId)
      {
        _db.CategoryProduct.Add(new CategoryProduct() {CategoryId = id, ProductId = product.ProductId });
      }
      _db.SaveChanges();
      return View();
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

    public ActionResult AddPhoto(int id)
    {
      Product thisProduct = _db.Products.FirstOrDefault(product => product.ProductId == id);

      return View(thisProduct);
    }
  }
}