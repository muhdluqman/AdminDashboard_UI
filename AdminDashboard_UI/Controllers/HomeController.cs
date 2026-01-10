using System.Diagnostics;
using AdminDashboard_UI.Models;
using Microsoft.AspNetCore.Mvc;

namespace AdminDashboard_UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Dashboard()
        {var data=_context.Products.ToList();

            return View(data);
        }

        public IActionResult Registration()
        {
            return View();
        }
        public IActionResult PasswordIncorrect()
        {
            return View();
        }
        [HttpPost]
        public IActionResult RegisterUser(string username,string email,string password, string confirmPassword)
        {
           if(password != confirmPassword)
           {
                return View("PasswordIncorrect");
           }


            var existingUser = _context.Users.FirstOrDefault(u => u.Email == email || u.Username == username);

            if (existingUser != null) {
             return View("ExistingUserFound");
            }

            _context.Users.Add(new Users
            {
                Username = username,
                Email = email,
                Password = password,
                Role = "User"
            });
            _context.SaveChanges();

            return View("Index");
        }

        public IActionResult UserNotFound()
        {
            return View();
        }

        public IActionResult Login(string username,string password) { 

            var user=_context.Users.FirstOrDefault(u=>u.Username==username);

            if (user == null)
            {
                return RedirectToAction("UserNotFound");
            }

            if (user.Password != password)
            {
                return RedirectToAction("PasswordIncorrect");
            }
            return View("Dashboard");


        }

    }
}
