using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebProgramlamaProje.Models;

[Table("Hayvan")]
public partial class Hayvan
{
    [Key]
    public int Id { get; set; }

    public string Tur { get; set; } = null!;
}
