using System.ComponentModel.DataAnnotations;

namespace WebProgramlamaProje.Models
{
    public class KullaniciGiris
    {
        [Required(ErrorMessage = "Bu Alan Boş Geçilemez")]
        public string KullaniciAd { get; set; } = null!;

        [StringLength(10)]
        [Required(ErrorMessage = "Bu Alan Boş Geçilemez")]
        public string Sifre { get; set; } = null!;
    }
}
