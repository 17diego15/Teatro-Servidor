namespace Models;
using System.ComponentModel.DataAnnotations;

public class Funcion
{
    [Key]
    public int FuncionID { get; set; }
    public int ObraID { get; set; }

    public int SalaID { get; set; }

    [Required]
    public DateTime Fecha { get; set; }

    [Required]
    public string? Hora { get; set; }

    [Required]
    public string? Disponibilidad { get; set; }

    public virtual Obra? Obra { get; set; }
    public virtual Sala? Sala { get; set; }
}

