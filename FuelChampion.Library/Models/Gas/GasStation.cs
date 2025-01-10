using FuelChampion.Library.Enums;

namespace FuelChampion.Library.Models.Gas;

public class GasStation
{
    public int Id { get; set; }
    public Voivodeship? Voivodeship { get; set; }
    public string? Name { get; set; }
    public string? City { get; set; }
    public string? Address { get; set; }
}
