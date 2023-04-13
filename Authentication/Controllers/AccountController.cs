using Authentication.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Authentication.Controllers
{
    public class AccountController : Controller
    {
        [AllowAnonymous]
        public IActionResult Register(RegistartionViewModel registrationViewModel)
        {
            return View(registrationViewModel);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (loginViewModel.Username != null) 
            {
                if (loginViewModel.Username == "1" && loginViewModel.Password == "1")
                {
                    var user = GetUserDetails(loginViewModel.Username);

                    var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
                    identity.AddClaim(new Claim(ClaimTypes.GivenName, user.FirstName));
                    identity.AddClaim(new Claim(ClaimTypes.Surname, user.LastName));

                    foreach (var role in user.Roles)
                    {
                        identity.AddClaim(new Claim(ClaimTypes.Role, role.Name));
                    }

                    var principal = new ClaimsPrincipal(identity);
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    loginViewModel.Message = "Incorrect username or password";
                }
            }

            return View(loginViewModel);
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();

            return RedirectToAction(nameof(Login));
        }

        public IActionResult AccessDenied()
        {
            return View();
        }

        private UserModel GetUserDetails(string username)
        {
            return new UserModel
            {
                FirstName = "Ivan",
                LastName = "Petrov",
                Roles = new List<RoleModel>
                {
                    new RoleModel { Name = "Admin" },
                    new RoleModel { Name = "Super user" },
                }
            };
        }
    }
}
