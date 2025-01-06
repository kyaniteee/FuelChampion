namespace FuelChampion.Library.Models;

public class User
{
    public string? Id { get; set; }
    public string? Login { get; set; }
    public string? Password { get; set; }
    public string? FirstName { get; set; }
    public string? SecondName { get; set; }
    public string? Email { get; set; }
    public string? City { get; set; }
    public DateTime? RegistrationDate { get; set; }
}
