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

    
  }
}