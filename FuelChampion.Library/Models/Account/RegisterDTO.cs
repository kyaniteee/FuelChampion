using FuelChampion.Library.Enums;
using FuelChampion.Library.Models.Account.Validation;
using System.ComponentModel.DataAnnotations;

namespace FuelChampion.Library.Models.Account;

public class RegisterDto
{
    [Required(ErrorMessage = "Nazwa użytkownika nie może być pusta")]
    [StringLength(256, MinimumLength = 5, ErrorMessage = "Nazwa użytkownika musi mieć przynajmniej 5 znaków")]
    public string? UserName { get; set; }

    [EmailAddress]
    [Required(ErrorMessage = "Email jest wymagany")]
    public string? Email { get; set; }

    [PasswordValidation]
    [Required(ErrorMessage = "Hasło nie może być puste")]
    public string? Password { get; set; }

    [Required]
    public string? FirstName { get; set; }
    [Required]
    public string? SecondName { get; set; }

    public Voivodeship? Voivodeship { get; set; }
    public string? City { get; set; }
}
