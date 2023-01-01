using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebProgramlamaProje.Data;
using WebProgramlamaProje.Models;

namespace WebProgramlamaProje.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KitapApiController : ControllerBase
    {
        private DataContext db;

        public KitapApiController(DataContext dataContext) { 
         db= dataContext;
        }

        [HttpGet]
        public IEnumerable<Kitap> Get()
        {
           return  db.Kitaps.ToList();
        }

        [HttpPost]
        public IActionResult Post([FromBody] Kitap kitap)
        {
           
            db.Kitaps.Add(kitap);
            db.SaveChanges();
            
            return Ok();
        }

        [HttpPut]
        public Kitap Put([FromBody] Kitap kitap)
        {

            var guncellenecekKitap = db.Kitaps.FirstOrDefault(x => x.Id == kitap.Id);

            guncellenecekKitap.Tur = kitap.Tur;
            guncellenecekKitap.Ad = kitap.Ad;
            guncellenecekKitap.YazarAdi = kitap.YazarAdi;

            db.SaveChanges();

            return new Kitap();

         }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            var silinecekKitap = db.Kitaps.FirstOrDefault(x => x.Id == id);
            db.Kitaps.Remove(silinecekKitap);
            db.SaveChanges();

            return Ok();
        }

    }
}
