using Login_Signup.Models;
using Microsoft.AspNetCore.Mvc;

namespace Login_Signup.Controllers
{
    public class Login_Signup : Controller
    {
        LoginRegistrationContext _context;
        public Login_Signup(LoginRegistrationContext context)
        {
            _context = context;

        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(User tbl_user)
        {
            _context.Users.Add(tbl_user);
            _context.SaveChanges();
            return RedirectToAction("Login");
        } public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            var row = _context.Users.FirstOrDefault(users => users.Email == email);
            if (row != null && password == row.Password)
            {
                HttpContext.Session.SetString("username", row.Name);
                return RedirectToAction("Home");
            }
            else
            {
                ViewBag.error = "Incorrect Email or Password";
            }
            return View();
        }
        public IActionResult Home()
        {
            if (HttpContext.Session.GetString("username") != null)
            {
                ViewBag.name=HttpContext.Session.GetString("username");
            }
            else
            {
                return RedirectToAction("Login");
            }
            return View();
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("username");
            return RedirectToAction("Login");
        }
    }
}
