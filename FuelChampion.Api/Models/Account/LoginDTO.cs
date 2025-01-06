using System.ComponentModel.DataAnnotations;

namespace FuelChampion.Api.Models.Account
{
    public class LoginDTO
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
