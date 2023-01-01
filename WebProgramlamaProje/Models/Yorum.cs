using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebProgramlamaProje.Models;

[Table("Yorum")]
public partial class Yorum
{
    [Key]
    public long Id { get; set; }

    public string? Icerik { get; set; }

    public long Kitap { get; set; }

    public long Kullanici { get; set; }

    [ForeignKey("Kitap")]
    [InverseProperty("Yorums")]
    public virtual Kitap KitapNavigation { get; set; } = null!;

    [ForeignKey("Kullanici")]
    [InverseProperty("Yorums")]
    public virtual Kullanici KullaniciNavigation { get; set; } = null!;
}
