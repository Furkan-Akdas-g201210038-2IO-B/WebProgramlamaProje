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

    public string TamAd { get; set; } = null!;

    public string KullaniciAd { get; set; } = null!;

    public string Sifre { get; set; } = null!;

    public string Rol { get; set; } = null!;
}
