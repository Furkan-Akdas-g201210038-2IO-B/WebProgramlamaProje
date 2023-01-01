using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebProgramlamaProje.Models;

[Table("Turler")]
public partial class Turler
{
    [Key]
    public long Id { get; set; }

    public string? Ad { get; set; }
}
