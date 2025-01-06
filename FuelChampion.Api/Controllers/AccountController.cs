using FuelChampion.Api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FuelChampion.Api.Controllers;

public class AccountController : ControllerBase
{
    private readonly UserManager<User> _userManager;
    //private readonly ITokenService _tokenService;
    private readonly SignInManager<User> _signInManager;

    public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
    {
        _userManager = userManager;
        //_tokenService = tokenService;
        _signInManager = signInManager;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] User registerUser)
    {
        try
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var appUser = new User
            {
                UserName = registerUser.UserName,
                Email = registerUser.Email,
            };

            var createdUser = await _userManager.CreateAsync(appUser, registerUser.PasswordHash);

            if (!createdUser.Succeeded)
                return BadRequest(createdUser.Errors);

            var roleResult = await _userManager.AddToRoleAsync(appUser, "User");
            if (!roleResult.Succeeded)
                return BadRequest(roleResult.Errors);

            return Ok(
                  new User
                  {
                      UserName = appUser.UserName,
                      Email = appUser.Email,
                      //Token = _tokenService.CreateToken(appUser)
                  }
              );
        }
        catch (Exception e)
        {
            return BadRequest(e);
        }
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(User login)
    {
        try
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName.ToLower() == login.UserName.ToLower());

            if (user == null)
                return Unauthorized("Invalid username!");

            var result = await _signInManager.CheckPasswordSignInAsync(user, login.PasswordHash, false);

            if (!result.Succeeded)
                return Unauthorized("User not found and/or password incorrect.");

            return Ok(
                new User
                {
                    UserName = user.UserName,
                    Email = user.Email,
                    //Token = _tokenService.CreateToken(user)
                }
            );
        }
        catch (Exception e)
        {
            return BadRequest(e);
        }
    }
}


