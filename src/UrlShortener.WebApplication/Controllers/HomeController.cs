using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using UrlShortener.Domain.Repositories;
using UrlShortener.WebApplication.Models;

namespace UrlShortener.WebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUrlRepository _urlRepository;

        public HomeController(
            ILogger<HomeController> logger,
            IUrlRepository urlRepository
        )
        {
            _logger = logger;
            _urlRepository = urlRepository;
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
            var urls = _urlRepository.GetUrls();
            return View(urls);
        }

        [HttpPost]
        public IActionResult Create([FromBody] string url)
        {
            var shortUrl = _urlRepository.CreateUrl(url);
            return Ok();
        }
    }
}