namespace Models;
using System.ComponentModel.DataAnnotations;

public class Obras
{
    [Key]
    public int ObraID { get; set; }

    [Required]
    public string? Titulo { get; set; }

    [Required]
    public string? Director { get; set; }

    [Required]
    public string? Sinopsis { get; set; }

    [Required]
    public string? Duración { get; set; }

    [Required]
    public decimal? Precio { get; set; }

    [Required]
    public string? Imagen { get; set; }
}

