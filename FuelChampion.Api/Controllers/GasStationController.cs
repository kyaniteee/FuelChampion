using FuelChampion.Api.Models;
using FuelChampion.Api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FuelChampion.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class GasStationController : ControllerBase
{
    private readonly IGasStationRepository _repository;

    public GasStationController(IGasStationRepository repository)
    {
        _repository = repository;
    }

    [HttpGet()]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<IEnumerable<GasStation>>> GetAll()
    {
        var result = await _repository.GetAllAsync();

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok(result);
    }

    [HttpGet("{id:int}", Name = nameof(Get))]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<GasStation>> Get(int id)
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

    [HttpPost("Create", Name = nameof(Create))]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<GasStation>> Create([FromBody] GasStation gasStation)
    {
        if (gasStation == null)
            return BadRequest();

        var result = await _repository.CreateAsync(gasStation);

        gasStation.Id = result.Id;
        return CreatedAtRoute(nameof(Get), new { id = gasStation.Id }, gasStation);
    }

    [HttpPut("Update", Name = nameof(Update))]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> Update([FromBody] GasStation gasStation)
    {
        if (gasStation == null || gasStation.Id <= 0)
            BadRequest();

        var result = await _repository.GetAsync(x => x.Id == gasStation.Id, true);
        if (result == null)
            return NotFound();

        _repository.UpdateAsync(result);

        return NoContent();
    }

    [HttpDelete("{id}", Name = nameof(Delete))]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<bool>> Delete(int id)
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
