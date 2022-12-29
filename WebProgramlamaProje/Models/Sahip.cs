using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebProgramlamaProje.Models;

[Table("Sahip")]
public partial class Sahip
{
    [Key]
    public int Id { get; set; }

    public string Isim { get; set; } = null!;
}
