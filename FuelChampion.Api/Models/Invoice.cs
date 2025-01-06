using FuelChampion.Api.Enums;

namespace FuelChampion.Library.Models;

public class Invoice
{
    public int Id { get; set; }
    public string? CarId { get; set; }
    public string? UserId { get; set; }
    public string? GasStationId { get; set; }
    public decimal? TotalPrice { get; set; }
    public decimal? PricePerLiter { get; set; }
    public DateTime RefuelingDate { get; set; }
    public decimal? RefueledLitersAmount { get; set; }
    public FuelType FuelType { get; set; }

}
