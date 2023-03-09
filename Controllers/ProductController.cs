using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace Northwind.Controllers
{
    public class ProductController : Controller
    {
        private NorthwindContext _northwindContext;
        public ProductController(NorthwindContext db) => _northwindContext = db;

        public IActionResult Category() => View(_northwindContext.Categories.OrderBy(c => c.CategoryName));
        public IActionResult Index(int id) => View(_northwindContext.Products.Where(p => p.Discontinued == false && p.CategoryId == id).OrderBy(p => p.ProductName));
        public IActionResult Discounts() => View(_northwindContext.Discounts.Where(d => d.StartTime <= DateTime.Now && d.EndTime > DateTime.Now));
    }
}