namespace Models;
using System.ComponentModel.DataAnnotations;

public class PedidoDto
{
    public int PedidoID { get; set; }

    public int? UsuarioID { get; set; }

    public int? FuncionID { get; set; }

    public decimal? Precio { get; set; }

    public decimal? PrecioTotal { get; set; }

    public DateTime? Fecha { get; set; }
    public int NumeroDeReservas { get; set; }
    public List<ReservaDto> Reservas { get; set; } = new List<ReservaDto>();

}

