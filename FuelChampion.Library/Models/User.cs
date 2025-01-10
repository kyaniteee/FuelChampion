using Microsoft.AspNetCore.Identity;

namespace FuelChampion.Library.Models;

public class User : IdentityUser
{
    public string? Voivodeship { get; set; }
    public string? City { get; set; }
}
