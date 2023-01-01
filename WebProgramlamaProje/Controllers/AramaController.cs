using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.Design.Serialization;
using System.Runtime.Intrinsics.Arm;
using System.Security.Claims;
using WebProgramlamaProje.Data;
using WebProgramlamaProje.Models;
using WebProgramlamaProje.ViewModels;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace WebProgramlamaProje.Controllers
{
    public class AramaController : Controller
    {
        DataContext db;
        public AramaController(DataContext dataContext) {
            db= dataContext;
        }
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Arama()
        {
            ViewData["Kitaplar"] = db.Kitaps.ToList();


            return View();
        }

        [HttpPost]
        public IActionResult Arama(string TurAdi,int Filtre)
        {
            if(TurAdi == null)
            {
                ViewData["Kitaplar"] = db.Kitaps.ToList();


                return View();
            }
            else if (TurAdi != null && Filtre == 0)
            {
                var query = from item2 in db.Kitaps
                            where item2.Tur.StartsWith(TurAdi)
                            select item2;

                 
                ViewData["Kitaplar"] = query.ToList();

                return View();
            }
            else
            {

                  var query = from item2 in db.Kitaps
                              where item2.Tur.StartsWith(TurAdi)
                              select item2;

                  ViewData["Kitaplar"] = query.OrderByDescending(x => x.Puan).ToList();

                  return View();

               

            }
            

            
        }

        [Authorize(Roles ="User")]
        public IActionResult Inceleme(int id)
        {

            ClaimsPrincipal claimUser = HttpContext.User;
            var x = claimUser.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name);


            string y = x.Value;
            ViewData["UserKullaniciAd"] = x.Value;

            var sorgu =  db.Kullanicis.FirstOrDefault(m => m.KullaniciAd == y);

            ViewData["UserKullaniciId"] = sorgu.Id;
            ViewData["KitapId"] = id;
            


            var query = from d1 in db.Kitaps
                        join d2 in db.Yorums
                        on d1.Id equals d2.Kitap
                        join d3 in db.Kullanicis
                        on d2.Kullanici equals d3.Id
                        select new KitapYorumKullanici()
                        {
                            Icerik = d2.Icerik,
                            KullaniciAd = d3.KullaniciAd,
                            Puan = d1.Puan,
                            KitapAd = d1.Ad,
                            YazarAdi = d1.YazarAdi,
                            Tur = d1.Tur
                            
                        };

            ViewData["KitapYorumKullanici"] = query.ToList();



            return View();
        }

        
        [HttpPost]
        public IActionResult Inceleme(string Icerik,int Kullanici,int Kitap)
        {
            Yorum yorum = new Yorum()
            {
                Icerik = Icerik,
                Kullanici = Kullanici,
                Kitap = Kitap
            };

            db.Yorums.Add(yorum);
            db.SaveChanges();

            var query = from d1 in db.Kitaps
                        join d2 in db.Yorums
                        on d1.Id equals d2.Kitap
                        join d3 in db.Kullanicis
                        on d2.Kullanici equals d3.Id
                        select new KitapYorumKullanici()
                        {
                            Icerik = d2.Icerik,
                            KullaniciAd = d3.KullaniciAd,
                            Puan = d1.Puan,
                            KitapAd = d1.Ad,
                            YazarAdi = d1.YazarAdi,
                            Tur = d1.Tur

                        };

            ViewData["KitapYorumKullanici"] = query.ToList();

            return View();
        }


    }
}
