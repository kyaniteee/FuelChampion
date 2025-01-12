using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace FuelChampion.Library.Models.Account.Validation
{
    public class PasswordValidation : ValidationAttribute
    {
        private readonly int _minimumLength;

        public PasswordValidation(int minimumLength = 7)
        {
            _minimumLength = minimumLength;
            ErrorMessage = $"Hasło musi mieć co najmniej {_minimumLength} znaków, zawierać jedną dużą literę, jedną małą literę, cyfrę oraz znak specjalny.";
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string password = value as string;

            if (string.IsNullOrWhiteSpace(password))
            {
                return new ValidationResult("Hasło jest wymagane.");
            }

            if (password.Length < _minimumLength)
            {
                return new ValidationResult($"Hasło musi mieć co najmniej {_minimumLength} znaków.");
            }

            if (!Regex.IsMatch(password, @"[A-Z]"))
            {
                return new ValidationResult("Hasło musi zawierać co najmniej jedną dużą literę.");
            }

            if (!Regex.IsMatch(password, @"[a-z]"))
            {
                return new ValidationResult("Hasło musi zawierać co najmniej jedną małą literę.");
            }

            if (!Regex.IsMatch(password, @"\d"))
            {
                return new ValidationResult("Hasło musi zawierać co najmniej jedną cyfrę.");
            }

            if (!Regex.IsMatch(password, @"[\W_]"))
            {
                return new ValidationResult("Hasło musi zawierać co najmniej jeden znak specjalny.");
            }

            return ValidationResult.Success;
        }
    }
}

