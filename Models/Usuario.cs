namespace Models;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;
public class Usuario
{
    [Key]
    public int UsuarioID { get; set; }

    [Required]
    public string? Nombre { get; set; }

    [Required]
    public string? NombreUsuario { get; set; }

    [Required]
    public string? Contraseña { get; set; }

    [Required]
    public bool IsAdmin { get; set; }

    public List<Pedido>? Pedidos { get; set; }
}

