namespace Models;
using System.ComponentModel.DataAnnotations;

public class Sala
{
    [Key]
    public int SalaID { get; set; }

    [Required]
    public string? Nombre { get; set; }

    [Required]
    public int? NumeroColumnas { get; set; }

    [Required]
    public int? NumeroFilas { get; set; }

    public List<Funcion> Funciones { get; set; } = new List<Funcion>();
}

