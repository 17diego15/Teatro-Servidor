namespace Models;
using System.ComponentModel.DataAnnotations;

public class ObraDto
{
    public int ObraID { get; set; }
    public string? Titulo { get; set; }
    public string? Director { get; set; }
    public string? Sinopsis { get; set; }
    public string? Duración { get; set; }
    public decimal? Precio { get; set; }
    public string? Imagen { get; set; }
    public List<ActorDto> Actores { get; set; } = new List<ActorDto>();
}

