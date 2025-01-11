using FuelChampion.Api.Services;
using FuelChampion.Library.Models;
using FuelChampion.Library.Models.Account;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FuelChampion.Api.Controllers;

public class AccountController : ControllerBase
{
    private readonly UserManager<User> _userManager;
    private readonly ITokenService _tokenService;
    private readonly SignInManager<User> _signInManager;

    public AccountController(UserManager<User> userManager, ITokenService tokenService, SignInManager<User> signInManager)
    {
        _userManager = userManager;
        _tokenService = tokenService;
        _signInManager = signInManager;
    }

    [HttpPost("Register", Name = nameof(Register))]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Register([FromBody] RegisterDto registerDTO)
    {
        try
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var appUser = new User
            {
                UserName = registerDTO.UserName,
                Email = registerDTO.Email,
                Voivodeship = registerDTO.Voivodeship,
                City = registerDTO.City,
            };

            var createdUser = await _userManager.CreateAsync(appUser, registerDTO.Password);

            if (!createdUser.Succeeded)
                return BadRequest(createdUser.Errors);

            var roleResult = await _userManager.AddToRoleAsync(appUser, "User");
            if (!roleResult.Succeeded)
                return BadRequest(roleResult.Errors);

            return Ok(
                  new NewUserDTO
                  {
                      UserName = appUser.UserName,
                      Email = appUser.Email,
                      Token = _tokenService.CreateToken(appUser)
                  }
            );
        }
        catch (Exception e)
        {
            return BadRequest(e);
        }
    }

    [HttpPost(nameof(Login))]
    public async Task<IActionResult> Login(LoginDto loginDTO)
    {
        try
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName.ToLower() == loginDTO.UserName.ToLower());

            if (user == null)
                return Unauthorized("Invalid username!");

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDTO.Password, false);

            if (!result.Succeeded)
                return Unauthorized("User not found and/or password incorrect.");

            return Ok(
                new NewUserDTO
                {
                    UserName = user.UserName,
                    Email = user.Email,
                    Token = _tokenService.CreateToken(user)
                }
            );
        }
        catch (Exception e)
        {
            return BadRequest(e);
        }
    }
}


