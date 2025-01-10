namespace FuelChampion.Library.Extensions;

public static class DecimalExtensions
{
    public static string? ToStringPLN(this decimal? value) => value?.ToString("0.00 zł", System.Globalization.CultureInfo.InvariantCulture);
}
