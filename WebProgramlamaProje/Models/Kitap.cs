using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebProgramlamaProje.Models;

[Table("Kitap")]
public partial class Kitap
{
    [Key]
    public long Id { get; set; }

    public string Tur { get; set; } = null!;

    public string YazarAdi { get; set; } = null!;

    [Column(TypeName = "Double")]
    public double? Puan { get; set; }

    public long? PuanlanmaSayisi { get; set; }

    public string Ad { get; set; } = null!;

    [InverseProperty("KitapNavigation")]
    public virtual ICollection<Yorum> Yorums { get; } = new List<Yorum>();
}
