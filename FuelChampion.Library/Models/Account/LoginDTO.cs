﻿using System.ComponentModel.DataAnnotations;

namespace FuelChampion.Library.Models.Account;

public class LoginDto
{
    [Required]
    public string UserName { get; set; }

    [Required]
    public string Password { get; set; }
}
