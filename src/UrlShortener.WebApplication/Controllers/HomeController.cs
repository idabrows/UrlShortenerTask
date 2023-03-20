using Microsoft.AspNetCore.Mvc;
using UrlShortener.Domain.Services;
using UrlShortener.WebApplication.Models;

namespace UrlShortener.WebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IShortUrlService _urlService;

        public HomeController(
            ILogger<HomeController> logger,
            IShortUrlService urlService
        )
        {
            _logger = logger;
            _urlService = urlService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult TechTaskDetails()
        {
            return View("TechTaskDetails");
        }

        [HttpGet]
        public IActionResult UrlList()
        {
            var urls = _urlService.GetShortUrls();
            return View(urls);
        }

        [HttpPost]
        public IActionResult Create(UrlViewModel urlVm)
        {
            var path = _urlService.CreateUrl(urlVm.Destination);
            if (path == null)
            {
                return BadRequest("Incorrect URL format.");
            }
            urlVm.Path = path;
            ModelState.Clear();
            return View("Index", urlVm);
        }

        [HttpGet("/{path:required}")]
        public IActionResult RedirectTo(string path)
        {
            if (path == null)
            {
                return NotFound();
            }

            var destination = _urlService.GetDestination(path);
            if (destination == null)
            {
                return NotFound();
            }

            return Redirect(destination);
        }
    }
}