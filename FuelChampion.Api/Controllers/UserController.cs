using FuelChampion.Api.Repositories;
using FuelChampion.Api.Services.User;
using FuelChampion.Library.Models;
using Microsoft.AspNetCore.Mvc;

namespace FuelChampion.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserRepository _repository;
    private readonly IUserService _userService;
    public UserController(IUserRepository repository, IUserService userService)
    {
        _repository = repository;
        _userService = userService;
    }

    [HttpGet(nameof(GetCurrentUser), Name = nameof(GetCurrentUser))]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<User>> GetCurrentUser()
    {
        var result = await _userService.GetUserAsync();

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok(result);
    }
}
