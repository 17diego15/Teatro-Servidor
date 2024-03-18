namespace Models;
using System.ComponentModel.DataAnnotations;

public class FuncionDto
{
    public int FuncionID { get; set; }
    public int ObraID { get; set; }
    public int SalaID { get; set; }
    public DateTime? Fecha { get; set; }
    public string? Hora { get; set; }
    public string? Disponibilidad { get; set; }
    public decimal AsientosDisponibles {get; set;}
    public decimal AsientosRestantes {get; set;}
    public ObraDto? Obra { get; set; }
    public SalaDto? Sala { get; set; }
}

