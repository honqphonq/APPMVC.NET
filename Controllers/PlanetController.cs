using APPMVC.NET.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace APPMVC.NET.Controllers
{
    public class PlanetController : Controller
    {
        private readonly PlanetService _planetServie;
        private readonly ILogger<PlanetService> _logger;
        public PlanetController(PlanetService planetservice, ILogger<PlanetService> logger)
        {
            _planetServie = planetservice;
            _logger = logger;
        }

        //[Route("danhsachcachanhtinh.html")]
        public IActionResult Index()
        {
            return View();
        }
        [BindProperty(SupportsGet = true, Name="action")]
        public string Name { get; set; } // Action ~ PlanetModel
        public IActionResult Mercury()
        {
            var planet = _planetServie.Where(p => p.Name == Name).FirstOrDefault();
            return View("Detail",planet);
        }
        public IActionResult Venus()
        {
            var planet = _planetServie.Where(p => p.Name == Name).FirstOrDefault();
            return View("Detail", planet);
        }
        public IActionResult Earth()
        {
            var planet = _planetServie.Where(p => p.Name == Name).FirstOrDefault();
            return View("Detail", planet);
        }
        public IActionResult Mars()
        {
            var planet = _planetServie.Where(p => p.Name == Name).FirstOrDefault();
            return View("Detail", planet);
        }
        public IActionResult Jupiter()
        {
            var planet = _planetServie.Where(p => p.Name == Name).FirstOrDefault();
            return View("Detail", planet);
        }
        public IActionResult Saturn()
        {
            var planet = _planetServie.Where(p => p.Name == Name).FirstOrDefault();
            return View("Detail", planet);
        }
        public IActionResult Uranus()
        {
            var planet = _planetServie.Where(p => p.Name == Name).FirstOrDefault();
            return View("Detail", planet);
        }
        public IActionResult Neptune()
        {
            var planet = _planetServie.Where(p => p.Name == Name).FirstOrDefault();
            return View("Detail", planet);
        }

        [Route("/hanhtinh/{id}")]
        public IActionResult PlanetInfo(int id)
        {
            var planet = _planetServie.Where(p => p.Id == id).FirstOrDefault();
            return View("Detail", planet);
        }
    }
}
