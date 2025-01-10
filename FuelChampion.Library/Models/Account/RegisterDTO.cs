using FuelChampion.Library.Enums;
using System.ComponentModel.DataAnnotations;

namespace FuelChampion.Library.Models.Account;

public class RegisterDto
{
    [Required]
    public string? UserName { get; set; }

    [Required]
    [EmailAddress]
    public string? Email { get; set; }

    [Required]
    public string? Password { get; set; }

    public Voivodeship? Voivodeship { get; set; }
    public string? City { get; set; }
}
