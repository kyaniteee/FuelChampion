using FuelChampion.Library.Enums;
using FuelChampion.Library.Extensions;

namespace FuelChampion.Library.Models.Gas;


public class GasStationAvgVoivodeshipPrice
{
    public Voivodeship? Voivodeship { get; set; }
    public string? VoivodeshipDescription => Voivodeship.ToDescription();
    public decimal? PricePerLiterAvgLpg { get; set; }
    public decimal? PricePerLiterAvgPb95 { get; set; }
    public decimal? PricePerLiterAvgPb98 { get; set; }
    public decimal? PricePerLiterAvgDiesel { get; set; }
}
