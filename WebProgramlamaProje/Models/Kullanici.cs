using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebProgramlamaProje.Models;

[Table("Kullanici")]
[Index("KullaniciAd", IsUnique = true)]
public partial class Kullanici
{
    [Key]
    public long Id { get; set; }

    [Required(ErrorMessage = "Bu Alan Boş Geçilemez")]
    
    public string TamAd { get; set; } = null!;

    [Required(ErrorMessage = "Bu Alan Boş Geçilemez")]
    public string KullaniciAd { get; set; } = null!;

    [StringLength(10)]
    [Required(ErrorMessage = "Bu Alan Boş Geçilemez")]
    public string Sifre { get; set; } = null!;

    public string Rol { get; set; } = null!;
}
