using Microsoft.AspNetCore.Mvc;
using WebProgramlamaProje.Models;

namespace WebProgramlamaProje.Controllers
{
    public class KullaniciController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult UyeOl()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UyeOl(Kullanici kullanici)
        {
            kullanici.Rol = "User";


            return View();
        }

    }
}
