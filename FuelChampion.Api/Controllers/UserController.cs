using FuelChampion.Api.Repositories;
using FuelChampion.Library.Models;
using Microsoft.AspNetCore.Mvc;

namespace FuelChampion.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserRepository _repository;
    public UserController(IUserRepository repository)
    {
        _repository = repository;
    }

    [HttpGet("{userId}", Name = nameof(GetUser))]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<User>> GetUser(string userId)
    {
        if (string.IsNullOrWhiteSpace(userId) || string.IsNullOrEmpty(userId))
        {
            return BadRequest();
        }

        var result = await _repository.GetAsync(x => x.Id == userId);
        if (result == null)
        {
            return NotFound($"The record with id: {userId} not found");
        }

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok(result);
    }
}
