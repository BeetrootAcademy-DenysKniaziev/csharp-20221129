using Contracts.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using BLL.Services.Interfaces;
using WebApp.Controllers;

public class AccountController : Controller
{
    private readonly IMyAuthenticationService _authenticationService;

    public AccountController(IMyAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(Login model)
    {
        if (ModelState.IsValid)
        {
            var result = await _authenticationService.MyAuthenticateAsync(model.Email, model.Password);

            if (result != null)
            {
                var claims = new List<Claim>
                {
                    //new Claim(ClaimTypes.Name, result.Email),
                    new Claim(ClaimTypes.Email, result.Email)
                };

                var identity = new ClaimsIdentity(claims, "Login");
                var principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync(principal, new AuthenticationProperties
                {
                    ExpiresUtc = DateTime.UtcNow.AddMinutes(30),
                    IsPersistent = false,
                    AllowRefresh = true
                });

                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError(string.Empty, "Invalid username or password");
        }
        return View(model);
    }

    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(Register model)
    {
        if (ModelState.IsValid)
        {
            var user = new User
            {
                Email = model.Email,
                UserName = model.UserName
            };
            //var user = new IdentityUser
            //{
            //    Email = model.Email,
            //    UserName = model.UserName
            //};
            var result = await _authenticationService.RegisterAsync(user, model.Password);

            if (result.Succeeded)
            {
                await _authenticationService.MyAuthenticateAsync(model.Email, model.Password);
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
            ModelState.AddModelError(string.Empty, "Unable to register user.");
        }
        return View(model);
    }


    [HttpPost]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

        return RedirectToAction("Login", "Account");
    }



    //[HttpPost]
    //public async Task<IActionResult> Register(Register model)
    //{
    //    if (!ModelState.IsValid)
    //    {
    //        return View(model);
    //    }

    //    var user = new User
    //    {
    //        Email = model.Email,
    //        UserName = model.UserName
    //    };
    //    var result = await _authenticationService.RegisterAsync(user, model.Password);

    //    if (result == null)
    //    {
    //        return RedirectToAction("Register");
    //    }

    //    ModelState.AddModelError(string.Empty, "Unable to register user.");

    //    return View(model);
    //}
}

