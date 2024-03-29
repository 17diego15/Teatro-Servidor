namespace Models;
using System.ComponentModel.DataAnnotations;

public class FuncionDto
{
    public int FuncionID { get; set; }
    public int ObraID { get; set; }
    public int SalaID { get; set; }
    public DateTime? Fecha { get; set; }
    public TimeSpan? Hora { get; set; }
    public string? Disponibilidad { get; set; }
    public List<ActorDto> Actores { get; set; } = new List<ActorDto>();
    public ObraDto? Obra { get; set; }
    public SalaDto? Sala { get; set; }
}

