using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using BAL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using BAL.Services;
using Contracts;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;

namespace ExchangeMarket.Controllers
{
    public class LoginController : Controller
    {
        private readonly MyIAuthenticationService _authenticationService;
        private readonly IPasswordHasher<Person> _passwordHasher;

        public LoginController(MyIAuthenticationService authenticationService, IPasswordHasher<Person> passwordHasher)
        {
            _authenticationService = authenticationService;
            _passwordHasher = passwordHasher;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Index(string email, string password)
        {
            var user = await _authenticationService.MyAuthenticateAsync(email, password);


            if (user == null)
            {
                ModelState.AddModelError("", "Invalid username or password");
                return View();
            }

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.Email),
                new Claim(ClaimTypes.Email, user.Email)
                // Add any additional claims 
            };

            var claimsIdentity = new ClaimsIdentity(claims, "login");

            var authProperties = new Microsoft.AspNetCore.Authentication.AuthenticationProperties
            {
                IsPersistent = true
            };

            await HttpContext.SignInAsync(
                Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);

            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
    }
}


////using IdentityServer3.Core.ViewModels;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc;
//using System.Threading.Tasks;
//using BAL.Interfaces;
//using Microsoft.AspNetCore.Authorization;
//using BAL.Services;
//using Contracts;
////using ExchangeMarket.Models;

//namespace ExchangeMarket.Controllers
//{
//    [AllowAnonymous]
//    public class LoginController : Controller
//    {
//        private readonly IAuthenticationService _authenticationService;
//        private readonly IPasswordHasher<Person> _passwordHasher;

//        public LoginController(IAuthenticationService authenticationService)
//        {
//            _authenticationService = authenticationService;
//        }

//        [HttpGet]
//        public IActionResult Index()
//        {
//            return View();
//        }

//        [HttpPost]
//        public async Task<IActionResult> Index(string email, string password)
//        {

//            var user = await _authenticationService.AuthenticateAsync(email, password);

//            if (user == null)
//            {
//                ModelState.AddModelError("", "Invalid username or password");
//                return View();
//            }

//            // var token = _authenticationService.GenerateJwtToken(user);
//            // Store token in session or cookie
//            Console.WriteLine("Entering Profile");
//            // Redirect to home page or protected resource

//            return RedirectToAction("Index", "Home");
//        }
//    }





    //[Route("api/[controller]")]
    //[ApiController]
    //public class LoginController : ControllerBase
    //{
    //    [AllowAnonymous]
    //    [HttpGet("login")]
    //    public IActionResult Login(string returnUrl = null)
    //    {
    //        ViewData["ReturnUrl"] = returnUrl;
    //        return View();
    //    }

    //    [HttpPost("login")]
    //    [AllowAnonymous]
    //    [ValidateAntiForgeryToken]
    //    public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = null)
    //    {
    //        ViewData["ReturnUrl"] = returnUrl;
    //        if (ModelState.IsValid)
    //        {
    //            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);
    //            if (result.Succeeded)
    //            {
    //                _logger.LogInformation("User logged in.");
    //                return RedirectToLocal(returnUrl);
    //            }
    //            if (result.RequiresTwoFactor)
    //            {
    //                return RedirectToAction(nameof(LoginWith2fa), new { returnUrl, model.RememberMe });
    //            }
    //            if (result.IsLockedOut)
    //            {
    //                _logger.LogWarning("User account locked out.");
    //                return RedirectToAction(nameof(Lockout));
    //            }
    //            else
    //            {
    //                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
    //                return View(model);
    //            }
    //        }

    //        // If we got this far, something failed, redisplay form
    //        return View(model);
    //    }

    //    [HttpPost("logout")]
    //    [ValidateAntiForgeryToken]
    //    public async Task<IActionResult> Logout()
    //    {
    //        await _signInManager.SignOutAsync();
    //        _logger.LogInformation("User logged out.");
    //        return RedirectToAction(nameof(HomeController.Index), "Home");
    //    }

    // }
//}
