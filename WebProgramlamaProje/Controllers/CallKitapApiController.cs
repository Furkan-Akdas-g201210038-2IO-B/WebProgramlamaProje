using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using WebProgramlamaProje.Models;

namespace WebProgramlamaProje.Controllers
{
    public class CallKitapApiController : Controller
    {
        HttpClientHandler clientHandler = new HttpClientHandler();
        Kitap kitap = new Kitap();
        List<Kitap> kitaplar = new List<Kitap>();



        public CallKitapApiController()
        {
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

        }

        [HttpGet]
        public async Task<List<Kitap>> KitaplariGetir()
        {
            kitaplar = new List<Kitap>();
            using (var httpclient = new HttpClient(clientHandler))
            {
                using (var response = await httpclient.GetAsync("https://localhost:7018/api/KitapApi/"))
                {
                    string apiresponse = await response.Content.ReadAsStringAsync();
                    kitaplar = JsonConvert.DeserializeObject<List<Kitap>>(apiresponse);
                }
            }
            return kitaplar;
        }

        [HttpDelete]
        public async Task<IActionResult> KitapSil(int kitapId)
        {
            
            using (var httpclient = new HttpClient(clientHandler))
            {
                using (var response = await httpclient.DeleteAsync("https://localhost:7018/api/KitapApi/" + kitapId))
                {
                     await response.Content.ReadAsStringAsync();

                }
            }
            return null;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPut]
        public async Task<Kitap> KitapGuncelle(Kitap kitap2)
        {
            kitap = new Kitap();
            using (var httpclient = new HttpClient(clientHandler))
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(kitap2), Encoding.UTF8, "application/json");

                using (var response = await httpclient.PutAsync("https://localhost:7018/api/KitapApi/", content))
                {
                    string apiresponse = await response.Content.ReadAsStringAsync();
                    kitap = JsonConvert.DeserializeObject<Kitap>(apiresponse);
                }
            }
            return kitap;

        }



        [HttpPost]
        public async Task<Kitap> Post(Kitap kitap2)
        {
           

          var httpclient = new HttpClient(clientHandler);
          
          StringContent content = new StringContent(JsonConvert.SerializeObject(kitap2), Encoding.UTF8, "application/json");

          await httpclient.PostAsync("https://localhost:7018/api/KitapApi/", content);
                

           
            return new Kitap();

        }

        

    }
}
