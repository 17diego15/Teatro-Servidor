namespace Models;
using System.ComponentModel.DataAnnotations;

public class ObraActor
{
    public int ObraID { get; set; }
    public Obras? Obra { get; set; }
    public int ActorId { get; set; }
    public Actores? Actor { get; set; }
}

