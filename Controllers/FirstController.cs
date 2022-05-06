using APPMVC.NET.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace APPMVC.NET.Controllers
{
    public class FirstController : Controller
    {
        private readonly ILogger<FirstController> _logger;
        private readonly ProductService _productService;
        public FirstController(ILogger<FirstController> logger, ProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }
        public IActionResult Readme()
        {
            var content = @"Xin chao cac ban
                            cac ban dang hoc ve 
                            .net mvc

                             XuanThuLab";
            return this.Content(content, "text/html ");
        }
        public IActionResult Privacy()
        {
            var url = "https://www.google.com/";
            return Redirect(url);
        }
        public IActionResult HelloView(string username)
        {
            if (string.IsNullOrEmpty(username))
                username = "Khách";
            return View("xinchao2",username);
        }
        public IActionResult xinchao3()
        {
            return View();
        }
        [AcceptVerbs("POST","GET")]
        public IActionResult ViewProduct(int? id)
        {
            var product = _productService.Where(p => p.Id == id).FirstOrDefault();
            if (product == null)
            {
                TempData["Thongbao"] = "san pham ban yeu cau khong co";
                return Redirect(Url.Action("Index", "Home"));
            }
              
            //this.ViewData["product"] = product;
            //this.ViewData["Title"] = product.Name;
            ViewBag.product = product;
            return View("ViewProduct3");
            

            //return View(product);
            //return View("ViewProduct2");
        }
        public string Index()
        {
            _logger.LogInformation("Index Action");
            return "Day la index cua FirstController";
        }
        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}
