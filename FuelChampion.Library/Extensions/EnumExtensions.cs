using FuelChampion.Library.Models;
using System.ComponentModel;
using System.Reflection;

namespace FuelChampion.Library.Extensions;

public static class EnumExtensions
{
    public static string ToDescription(this Enum value)
    {
        FieldInfo field = value.GetType().GetField(value.ToString());
        DescriptionAttribute attribute = field.GetCustomAttribute<DescriptionAttribute>();
        return attribute?.Description ?? value.ToString();
    }

    public static IList<EnumModel<T>> ToList<T>() where T : Enum
    {
        var values = Enum.GetValues(typeof(T)) as IList<T>;
        var result = values.Select(x => new EnumModel<T>(x, x.ToDescription())).ToList();
        return result;
    }
}
