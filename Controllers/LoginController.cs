using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using ServerConnections.Models;
using System.Security.Claims;

namespace ServerConnections.Controllers
{
    public class LoginController : Controller
    {
        private CollegeContext _context;
        public LoginController(CollegeContext context)
        {
            _context = context;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(Login login)
        {
            TblStudent student = _context.TblStudents.Where(x => x.Email == login.email && x.VcPassword == login.password).SingleOrDefault();
            if (student != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, student.StudentName),
                    new Claim(ClaimTypes.Email, student.Email),
                };

                var userIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);

                HttpContext.SignInAsync(principal);

                return RedirectToAction("Index", "student");
            }
            else
            {
                TempData["message"] = "Invalid Email/Password";
                return View();
            }
        }
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync();
            return RedirectToAction("Login", "Login");
        }
    }
}


