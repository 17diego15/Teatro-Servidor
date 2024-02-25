namespace Models;
using System.ComponentModel.DataAnnotations;

public class FuncionDto
{
    public int FuncionID { get; set; }
    public int ObraID { get; set; }
    public int SalaID { get; set; }
    public DateTime? Fecha { get; set; }
    public string? Hora { get; set; }
    public string? Desponibilidad { get; set; }
    public List<ActorDto> Actores { get; set; } = new List<ActorDto>();
    public ObraDto Obra { get; set; }
}

