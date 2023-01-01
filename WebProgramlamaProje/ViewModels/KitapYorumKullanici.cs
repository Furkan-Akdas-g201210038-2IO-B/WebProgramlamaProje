using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WebProgramlamaProje.Models;

namespace WebProgramlamaProje.ViewModels
{
    public class KitapYorumKullanici
    {
        
        
        public string Tur { get; set; } = ""!;

        public string YazarAdi { get; set; } = ""!;

        public double? Puan { get; set; } = 0;

        public long? PuanlanmaSayisi { get; set; } = 0;

        public string KitapAd { get; set; } = ""!;


        public string? Icerik { get; set; } = "";

        public string TamAd { get; set; } = ""!;

        public string KullaniciAd { get; set; } = ""!;

        public string Sifre { get; set; } = ""!;

        public string Rol { get; set; } = ""!;



    }
}
