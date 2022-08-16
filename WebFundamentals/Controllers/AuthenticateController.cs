using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace WebFundamentals.Controllers
{
    public class AuthenticateController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login( string username)
        {
            username = "uche";

            var appClaims = new List<Claim>()

                    {
                          new Claim(ClaimTypes.Name,username),
                          
                          //new Claim(ClaimTypes.Email,user.Email),
                          //new Claim("app.Says","A cool app"),
                    };

            var appIdentity = new ClaimsIdentity(appClaims, "App Identity");

            var userPrincipal = new ClaimsPrincipal(new[] { appIdentity });

            HttpContext.SignInAsync(userPrincipal);



            return RedirectToAction("Index", "Home");
        }

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync();



            return RedirectToAction("Index", "Home");
        }
    }
}
