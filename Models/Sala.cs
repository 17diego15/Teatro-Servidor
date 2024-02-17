namespace Models;
using System.ComponentModel.DataAnnotations;

public class Sala
{
    [Key]
    public int SalaID { get; set; }

    [Required]
    public string? Nombre { get; set; }

    [Required]
    public int? Capacidad { get; set; }
}

