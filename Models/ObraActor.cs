namespace Models;
using System.ComponentModel.DataAnnotations;

public class ObraActor
{
    public int ObraID { get; set; }
    public Obra? Obra { get; set; }
    public int ActorId { get; set; }
    public Actor? Actor { get; set; }
}

