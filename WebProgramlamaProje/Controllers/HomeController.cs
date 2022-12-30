using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System.Diagnostics;
using WebProgramlamaProje.Data;
using WebProgramlamaProje.Models;

namespace WebProgramlamaProje.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DataContext dataContext;

        public HomeController(ILogger<HomeController> logger,DataContext dataContext)
        {
            _logger = logger;
            this.dataContext = dataContext;
        }

        public IActionResult Index()
        {
            dataContext.Hayvans.Add(new Hayvan()
            {
                Tur = "sa"
            });
            dataContext.SaveChanges();
            return View();
        }

        public IActionResult LogIn()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}