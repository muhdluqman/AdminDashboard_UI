using AdminDashboard_UI.Migrations;
using AdminDashboard_UI.Models;
using Microsoft.AspNetCore.Mvc;

namespace AdminDashboard_UI.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductController (ApplicationDbContext context)
        {
            _context = context; 
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProductItem(string productname,string description,decimal price, string color)
        {

            var newProduct = new Products
            {

                ProductName = productname,
                Description = description,
                Price = price,
                Color = color


            };
            _context.Products.Add(newProduct);
            _context.SaveChanges();
            return RedirectToAction("Dashboard", "Home");
        }
    }
}
