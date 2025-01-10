namespace FuelChampion.Library.Models;

public class EnumModel<T> where T : Enum
{
    public T? Value { get; set; }
    public string? Description { get; set; }

    public EnumModel(T? value, string? description)
    {
        Value = value;
        Description = description;
    }
}
