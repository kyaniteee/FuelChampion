using FuelChampion.Api.Repositories;
using FuelChampion.Library.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FuelChampion.Api.Controllers;

//[Authorize]
[ApiController]
[Route("[controller]")]
public class CarController : ControllerBase
{
    private readonly ICarRepository _repository;
    
    public CarController(ICarRepository repository)
    {
        _repository = repository;
    }

    [HttpGet("Cars", Name = nameof(GetCars))]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<IEnumerable<Car>>> GetCars()
    {
        var result = await _repository.GetAllAsync();

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok(result);
    }

    [HttpGet("{id:int}", Name = nameof(GetCar))]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<Car>> GetCar(int id)
    {
        if (id <= 0)
        {
            return BadRequest();
        }

        var result = await _repository.GetAsync(x => x.Id == id);
        if (result == null)
        {
            return NotFound($"The record with id: {id} not found");
        }

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok(result);
    }

    [HttpPost("Create", Name = nameof(CreateCar))]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<Car>> CreateCar([FromBody] Car car)
    {
        if (car == null)
            return BadRequest();

        var result = await _repository.CreateAsync(car);

        car.Id = result.Id;
        return CreatedAtRoute(nameof(GetCar), new { id = car.Id }, car);
    }

    [HttpPut("Update", Name = nameof(UpdateCar))]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> UpdateCar([FromBody] Car car)
    {
        if (car == null || car.Id <= 0)
            BadRequest();

        var result = await _repository.GetAsync(x => x.Id == car.Id, true);
        if (result == null)
            return NotFound();

        _repository.UpdateAsync(result);

        return NoContent();
    }

    [HttpDelete("{id}", Name = nameof(DeleteCar))]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<bool>> DeleteCar(int id)
    {
        if (id <= 0)
            return BadRequest();

        var result = await _repository.GetAsync(x => x.Id == id);

        if (result == null)
            return NotFound($"The record with id {id} not found");

        await _repository.DeleteAsync(result);

        return Ok(true);
    }
}
