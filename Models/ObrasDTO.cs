namespace Models;
using System.ComponentModel.DataAnnotations;

public class ObrasDTO
{
    public int ObraID { get; set; } 
    public string? Titulo { get; set; }
    public string? Director { get; set; }
    public string? Sinopsis { get; set; }
    public string? Duración { get; set; }
    public decimal? Precio { get; set; }
    public string? Imagen { get; set; }
    public List<ActorDTO> Actores { get; set; } = new List<ActorDTO>();
}

