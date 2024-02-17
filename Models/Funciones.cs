namespace Models;
using System.ComponentModel.DataAnnotations;

public class Funciones
{
    [Key]
    public int FunciónID { get; set; }

    public int? SalaID { get; set; }

    [Required]
    public DateTime Fecha { get; set; }

    [Required]
    public string? Hora { get; set; }
}

