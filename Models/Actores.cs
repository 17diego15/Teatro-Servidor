namespace Models;
using System.ComponentModel.DataAnnotations;

public class Actores
{
    [Key]
    public int ActorId { get; set; }

    [Required]
    public string? Nombre { get; set; }

    public List<ObraActor> ObraActores { get; set; } = new List<ObraActor>();
}

