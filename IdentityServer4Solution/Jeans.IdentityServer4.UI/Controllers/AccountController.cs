using Jeans.IdentityServer4.UI.Core.Entity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Jeans.IdentityServer4.UI.Controllers
{
    public class AccountController : Controller
    {
        [AllowAnonymous]
        public IActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;

            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(UserEntity entity, string returnUrl)
        {
            if (entity.UserName != "admin" || entity.Password != "admin")
            {
                ModelState.AddModelError("", "用户名或者密码错误.");

                return View(entity);
            }

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
            claimsIdentity.AddClaim(new Claim(ClaimTypes.Name, entity.UserName));

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

            return RedirectToLocal(returnUrl);
        }

        [HttpGet]
        public async Task<IActionResult> LoginOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction(nameof(Login));
        }

        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (string.IsNullOrWhiteSpace(returnUrl))
            {
                return RedirectToAction("Index", "Home");
            }

            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }

            return RedirectToAction("Index", "Home");
        }

    }
}