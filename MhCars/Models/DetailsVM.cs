namespace MhCars.Models;

public class DetailsVM
{
    public Carros Anterior { get; set; }
    public Carros Atual { get; set; }
    public Carros Proximo { get; set; }
    public List<Tipo> Tipos { get; set; }
}
