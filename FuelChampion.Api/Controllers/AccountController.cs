using FuelChampion.Api.Services;
using FuelChampion.Library.Models;
using FuelChampion.Library.Models.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FuelChampion.Api.Controllers;

[ApiController]
[Microsoft.AspNetCore.Components.Route("[controller]")]
public class AccountController : ControllerBase
{
    private readonly UserManager<User> _userManager;
    private readonly ITokenService _tokenService;
    private readonly SignInManager<User> _signInManager;
    //private readonly CustomAuthenticationStateProvider _authenticationStateProvider;

    public AccountController(UserManager<User> userManager, ITokenService tokenService, SignInManager<User> signInManager)//, CustomAuthenticationStateProvider authenticationStateProvider)
    {
        _userManager = userManager;
        _tokenService = tokenService;
        _signInManager = signInManager;
        //_authenticationStateProvider = authenticationStateProvider;
    }

    [HttpPost(nameof(UserRegister), Name = nameof(UserRegister))]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> UserRegister([FromBody] RegisterDto registerDTO)
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
                FirstName = registerDTO.FirstName,
                SecondName = registerDTO.SecondName,
                City = registerDTO.City,
            };

            var createdUser = await _userManager.CreateAsync(appUser, registerDTO.Password);

            if (!createdUser.Succeeded)
                return BadRequest(createdUser.Errors);

            var roleResult = await _userManager.AddToRoleAsync(appUser, "User");
            if (!roleResult.Succeeded)
                return BadRequest(roleResult.Errors);

            var token = _tokenService.CreateToken(appUser);
                  
            return Ok(
                  new NewUserDTO
                  {
                      UserName = appUser.UserName,
                      Email = appUser.Email,
                      Token = token,
                  }
            );
        }
        catch (Exception e)
        {
            return BadRequest(e);
        }
    }

    [HttpPost(nameof(UserLogin), Name = nameof(UserLogin))]
    public async Task<IActionResult> UserLogin([FromBody] LoginDto loginDTO)
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

            var token = _tokenService.CreateToken(user);
            return Ok(
                new NewUserDTO
                {
                    UserName = user.UserName,
                    Email = user.Email,
                    Token = token
                }
            );
        }
        catch (Exception e)
        {
            return BadRequest(e);
        }
    }

    //[HttpGet("/AuthState")]
    //public async Task<AuthenticationState> GetAuthenticationStateAsync()
    //{
    //    try
    //    {
    //        return await _authenticationStateProvider.GetAuthenticationStateAsync();
    //    }
    //    catch (Exception e)
    //    {
    //        throw;
    //    }
    //}
}


