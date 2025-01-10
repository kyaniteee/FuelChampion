using System.ComponentModel;

namespace FuelChampion.Library.Enums;

public enum FuelType
{
    [Description("Benzyna 95 E10")]
    Pb95E10 = 1,
    [Description("Benzyna 98 E5")]
    Pb98E5 = 2,
    [Description("Gaz LPG")]
    LPG = 4,
    [Description("Olej napędowy B7")]
    DIESELB7 = 8,
}
