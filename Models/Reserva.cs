namespace Models;
using System.ComponentModel.DataAnnotations;
public class Reserva
{
    [Key]
    public int ReservaID { get; set; }

    public int? FunciónID { get; set; }

    [Required]
    public decimal? CantidadAsientos { get; set; }
}

