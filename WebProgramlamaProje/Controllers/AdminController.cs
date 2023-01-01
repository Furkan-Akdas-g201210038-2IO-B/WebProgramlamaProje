using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebProgramlamaProje.Data;
using WebProgramlamaProje.Models;

namespace WebProgramlamaProje.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private DataContext db;
        public AdminController(DataContext dataContext) {
            db = dataContext;
        
        }
        public IActionResult Index()
        {

            return View();

        }

        private List<Kitap> kitaps= new List<Kitap>();

        public IActionResult KitapEkleSilDuzenle()
        {
            kitaps = KitapGetir();
            ViewData["Kitaplar"] = kitaps;

            return View();

        }

        


        CallKitapApiController callApi = new CallKitapApiController();

        [HttpPost]
        public IActionResult KitapEkle(Kitap kitap)
        {
            

            if (ModelState.IsValid)
            {
                  callApi.Post(kitap);

            }

            return RedirectToAction("KitapEkleSilDuzenle");

        }

        
        public IActionResult KitapSil(int id)
        {
           

            callApi.KitapSil(id);

            return RedirectToAction("KitapEkleSilDuzenle");

        }

        public IActionResult KitapGuncelle()
        {
            kitaps = KitapGetir();
            ViewData["Kitaplar"] = kitaps;


            return View();

        }
        [HttpPost]
        public IActionResult KitapGuncelle(Kitap kitap)
        {
            kitaps = KitapGetir();
            ViewData["Kitaplar"] = kitaps;

            callApi.KitapGuncelle(kitap);

            return View("KitapEkleSilDuzenle");

        }


        public  List<Kitap> KitapGetir()
        {
            

            List<Kitap> kitaplar = db.Kitaps.ToList();

            ViewData["Kitaplar"] = kitaplar;

            return kitaplar;


        }

        /*public async Task<List<Kitap>>  KitapGetir()
        {
            CallKitapApiController callApi = new CallKitapApiController();

            List<Kitap> kitaplar = await callApi.KitaplariGetir();

            ViewData["Kitaplar"] = kitaplar;

            return  null ;
                 
        }*/


    }
}
