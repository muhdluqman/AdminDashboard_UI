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

        public IActionResult UpdateProduct(int productid) { 
     
            var data=_context.Products.FirstOrDefault(p=> p.ProductId==productid);
            return View(data);
        }

        [HttpPost]
        public IActionResult UpdateProductItem(int productid,string productname, string description, decimal price, string color)
        {
            var existingProduct = _context.Products.FirstOrDefault(p => p.ProductId == productid);
            if (existingProduct != null)
            {
                existingProduct.ProductName = productname;
                existingProduct.Description = description;
                existingProduct.Price = price;
                existingProduct.Color = color;
                _context.SaveChanges();
            }
            return RedirectToAction("Dashboard", "Home");
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

        public IActionResult DeleteProduct(int productid)
        {
            var product= _context.Products.FirstOrDefault(p => p.ProductId == productid);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
            return RedirectToAction("Dashboard", "Home");

        }
    }
}
