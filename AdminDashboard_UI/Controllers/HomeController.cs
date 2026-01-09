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
        {
            return View();
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

    }
}
