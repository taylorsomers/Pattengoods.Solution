using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pattengoods.Models;
using Pattengoods.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Pattengoods.Controllers
{
  [Authorize]
  public class AccountController : Controller
  {
    private readonly PattengoodsContext _db;

    private readonly SignInManager<User> _signInManager;

    private readonly UserManager<User> _userManager;

    public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, PattengoodsContext db)
    {
      _db = db;

      _signInManager = signInManager;

      _userManager = userManager;
    }

    [AllowAnonymous]
    public ActionResult Register()
    {
      return View();
    }

    

    public async Task<ActionResult> Index()
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

      var currentUser = await _userManager.FindByIdAsync(userId);

      return View(currentUser);
    }
  }
}