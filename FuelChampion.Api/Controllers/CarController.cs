using FuelChampion.Library.Models;
using FuelChampion.Library.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FuelChampion.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class CarController : ControllerBase
{
    private readonly ICarRepository _repository;

    public CarController(ICarRepository repository)
    {
        _repository = repository;
    }

    [HttpGet()]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<IEnumerable<Car>>> GetCars()
    {
        var car = await _repository.GetAllAsync();

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok(car);
    }
}

