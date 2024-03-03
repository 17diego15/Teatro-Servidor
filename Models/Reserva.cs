namespace Models;
using System.ComponentModel.DataAnnotations;
public class Reserva
{
    [Key]
    public int ReservaID { get; set; }

    public int? FunciónID { get; set; }

    [Required]
    public int? NumeroFila { get; set; }

    [Required]
    public int? NumeroColumna { get; set; }

    public virtual Sala? Sala { get; set; }
}

