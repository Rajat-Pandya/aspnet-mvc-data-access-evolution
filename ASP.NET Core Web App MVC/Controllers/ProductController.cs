using ASP.NET_Core_Web_App_MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_Core_Web_App_MVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        // Inject IProductService via constructor
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        // Show all products
        public IActionResult Index()
        {
            var products = _productService.GetAllProducts();
            return View(products);
        }
        // Show details of a product by id
        public IActionResult Details(int id)
        {
            var product = _productService.GetProductById(id);
            if (product == null)
                return NotFound();
            return View(product);
        }
    }
}
