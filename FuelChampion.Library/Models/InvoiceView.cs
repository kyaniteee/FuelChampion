using FuelChampion.Library.Enums;
using System.ComponentModel.DataAnnotations;

namespace FuelChampion.Library.Models;

public class InvoiceView 
{
    public int Invoice_id { get; set; }
    public int? CarId { get; set; }
    public Guid UserId { get; set; }
    public int GasStationId { get; set; }
    public decimal? TotalPrice { get; set; }
    public decimal? PricePerLiter { get; set; }
    public DateTime RefuelingDate { get; set; }
    public decimal? RefueledLitersAmount { get; set; }
    public FuelType FuelType { get; set; }

    public string? GasStationName { get; set; }
    public string? GasStationCity { get; set; }
    public string? GasStationAddress { get; set; }
    public Voivodeship? GasStationVoivodeship { get; set; }
    public string? CarModel { get; set; }
    public string? CarProducent { get; set; }
    public int? CarProductionYear { get; set; }
    public string? CarRegistrationNumber { get; set; }
}
