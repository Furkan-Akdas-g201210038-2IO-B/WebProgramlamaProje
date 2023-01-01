using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebProgramlamaProje.Data;
using WebProgramlamaProje.Models;

namespace WebProgramlamaProje.Controllers
{
    public class KullaniciController : Controller
    {
        public DataContext db;

        public KullaniciController(DataContext dataContext)
        {
            db = dataContext;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GirisYap()
        {
            ClaimsPrincipal claimUser = HttpContext.User;
            //var x = claimUser.Claims.FirstOrDefault(x => x.Value == "Admin");

            if (claimUser.Identity.IsAuthenticated)
                return View("Index");

            return View();
        }

        public IActionResult CikisYap()
        {
            foreach (var cookie in Request.Cookies.Keys)
            {
                Response.Cookies.Delete(cookie);
            }

            return RedirectToAction("GirisYap");
        }


        [HttpPost]
        public async Task<IActionResult> GirisYap(KullaniciGiris kullanici)
        {

            if (ModelState.IsValid)
            {
                var user = db.Kullanicis.FirstOrDefault(
                    x => x.KullaniciAd == kullanici.KullaniciAd && x.Sifre == kullanici.Sifre);

                if (user != null)
                {


                    var claim = new List<Claim>
                {

                   new Claim(ClaimTypes.Role, user.Rol),
                   new Claim(ClaimTypes.Role,"User"),
                   new Claim(ClaimTypes.Name,user.KullaniciAd),
                   

                };
                    var claimIdentty = new ClaimsIdentity(claim, CookieAuthenticationDefaults.AuthenticationScheme);
                    var authProperties = new AuthenticationProperties();
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimIdentty), authProperties);
                    
                    if (user.Rol == "Admin")
                        return RedirectToAction("Index", "Home");
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ViewData["GirisYapKullaniciSifreHatasi"] = "Bilgiler Uyuşmamaktadır";
                }
                

            }

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
            

            if (ModelState.IsValid)
            {
               var digerKullanici =  db.Kullanicis.FirstOrDefault(x => x.KullaniciAd == kullanici.KullaniciAd);
               
                if(digerKullanici == null)
                {
                    db.Kullanicis.Add(kullanici);
                    db.SaveChanges();
                }
                else
                {
                    ViewData["Hata"] = "Boyle bir kullanici mevcut";
                }
            }
            

            return View();
        }

    }
}
