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

    
  }
}