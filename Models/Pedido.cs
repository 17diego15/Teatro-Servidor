namespace Models;
using System.ComponentModel.DataAnnotations;

public class Pedido
{
    [Key]
    public int PedidoID { get; set; }

    [Required]
    public int? UsuarioID { get; set; }

    [Required]
    public int? FuncionID { get; set; }

    [Required]
    public decimal? Precio { get; set; }

    [Required]
    public decimal? PrecioTotal { get; set; }

    [Required]
    public int? NumeroDeReservas { get; set; }


    [Required]
    public DateTime? Fecha { get; set; }

    public Usuario? Usuario { get; set; }
    public Funcion? Funcion { get; set; }
    public List<Reserva> Reservas { get; set; } = new List<Reserva>();
}

