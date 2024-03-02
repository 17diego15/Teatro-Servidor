namespace Models;
using System.ComponentModel.DataAnnotations;

public class SalaDto
{
    public int SalaID { get; set; }
    public string? Nombre { get; set; }
    public int NumeroFilas { get; set; }
    public int NumeroColumnas { get; set; }
}

