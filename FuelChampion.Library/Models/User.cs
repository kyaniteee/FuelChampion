using FuelChampion.Library.Enums;
using Microsoft.AspNetCore.Identity;

namespace FuelChampion.Library.Models;

public class User : IdentityUser
{
    public string? FirstName { get; set; }
    public string? SecondName { get; set; }
    public Voivodeship? Voivodeship { get; set; }
    public string? City { get; set; }
}
