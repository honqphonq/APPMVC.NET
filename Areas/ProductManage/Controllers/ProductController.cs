using APPMVC.NET.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace APPMVC.NET.Controllers
{
    [Area("ProductManage")]
    public class ProductController : Controller
    {
        private readonly ProductService _productService;
        private readonly ILogger<ProductService> _logger;
        public ProductController(ProductService productService, ILogger<ProductService> logger)
        {
            _productService = productService;
            _logger = logger;
        }
        public IActionResult Index()
        {
            var products = _productService.OrderBy(p => p.Name).ToList();
            return View(products);
        }
    }
}
