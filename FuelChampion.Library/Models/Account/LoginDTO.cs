using FuelChampion.Library.Models.Account.Validation;
using System.ComponentModel.DataAnnotations;

namespace FuelChampion.Library.Models.Account;

public class LoginDto
{
    [Required(ErrorMessage ="Nazwa użytkownika nie może być pusta")]
    [StringLength(256, MinimumLength = 5, ErrorMessage = "Nazwa użytkownika musi mieć przynajmniej 5 znaków")]
    public string UserName { get; set; }

    [Required(ErrorMessage = "Hasło nie może być puste")]
    [PasswordValidation]
    public string Password { get; set; }
}
