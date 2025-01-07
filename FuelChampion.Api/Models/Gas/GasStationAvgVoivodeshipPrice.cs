using FuelChampion.Api.Enums;

namespace FuelChampion.Api.Models.Gas;


public class GasStationAvgVoivodeshipPrice
{
    public string? Voivodeship { get; set; }
    public FuelType FuelType { get; set; }
    public decimal? PricePerLiterAvg { get; set; }
}
