using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pattengoods.Models;
using Pattengoods.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Pattengoods.Controllers
{
  public class UserProfileController : Controller
  {
    private readonly PattengoodsContext _db;

    private readonly SignInManager<User> _signInManager;

    private readonly UserManager<User> _userManager;

    public UserProfileController(PattengoodsContext db)
    {
      _db = db;
    }

    public async Task<ActionResult> Index()
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

      var currentUser = await _userManager.FindByIdAsync(userId);

      return View(currentUser);
    }
  }
}