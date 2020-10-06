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

    [AllowAnonymous]
    [HttpPost]
    public async Task<ActionResult> Register(RegisterViewModel model)
    {
      User thisUser = new User {
        UserName = model.Email,
        FirstName = model.FirstName,
        LastName = model.LastName
      };

      IdentityResult result = await _userManager.CreateAsync(
        thisUser,
        model.Password
      );

      if (result.Succeeded)
      {
        return RedirectToAction("Index");
      }
      else
      {
        return View();
      }
    }

    [AllowAnonymous]
    [HttpPost]
    public async Task<ActionResult> ModalRegister(string userEmail, string userPassword, string userConfirmPassword)
    {
      User thisUser = new User { UserName = userEmail };

      if (userPassword == userConfirmPassword)
      {
        await _userManager.CreateAsync(
          thisUser,
          userPassword
        );
      }

      return RedirectToAction(
        "Index",
        "Home"
      );
    }

    [AllowAnonymous]
    public ActionResult Login()
    {
      return View();
    }

    [AllowAnonymous]
    [HttpPost]
    public async Task<ActionResult> Login(LoginViewModel model)
    {
      Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(
        model.Email,
        model.Password,
        isPersistent: true,
        lockoutOnFailure: false
      );

      if (result.Succeeded)
      {
        return RedirectToAction("Index");
      }
      else
      {
        return View();
      }
    }

    [AllowAnonymous]
    [HttpPost]
    public async Task<ActionResult> LoginModal(string userEmail, string userPassword)
    {
      Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(
        userEmail,
        userPassword,
        isPersistent: true,
        lockoutOnFailure: false
      );

      return RedirectToAction(
        "Index",
        "Home"
      );
    }

    [HttpPost]
    public async Task<ActionResult> LogOff()
    {
      await _signInManager.SignOutAsync();

      return RedirectToAction("Index");
    }

    public async Task<ActionResult> Index()
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

      var currentUser = await _userManager.FindByIdAsync(userId);

      return View(currentUser);
    }

    public ActionResult MockupProfileView()
    {
      return View();
    }
  }
}