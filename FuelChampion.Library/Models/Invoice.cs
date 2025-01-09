using FuelChampion.Library.Enums;

namespace FuelChampion.Library.Models;

public class Invoice
{
    public int Id { get; set; }
    public int? CarId { get; set; }
    public Guid UserId { get; set; }
    public int GasStationId { get; set; }
    public decimal? TotalPrice { get; set; }
    public decimal? PricePerLiter { get; set; }
    public DateTime RefuelingDate { get; set; }
    public decimal? RefueledLitersAmount { get; set; }
    public FuelType FuelType { get; set; }

}
