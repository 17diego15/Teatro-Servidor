namespace Models;
using System.ComponentModel.DataAnnotations;

public class ReservaDto
{
    public int ReservaID { get; set; }
    public int FuncionID { get; set; }
    //public int SalaID { get; set; }
    public int NumeroFila { get; set; }
    public int NumeroColumna { get; set; }
    //public SalaDto? Sala { get; set; }
}

