using FuelChampion.Library.Models;
using FuelChampion.Library.Repositories;
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
    public async Task<ActionResult<IEnumerable<GasStation>>> GetGasStatins()
    {
        var result = await _repository.GetAllAsync();

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok(result);
    }

    [HttpGet("{id:int}", Name = nameof(GetGasStationById))]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<GasStation>> GetGasStationById(int id)
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

    [HttpPost("Create", Name = nameof(CreateGasStation))]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<GasStation>> CreateGasStation([FromBody] GasStation gasStation)
    {
        if (gasStation == null)
            return BadRequest();

        var result = await _repository.CreateAsync(gasStation);

        gasStation.Id = result.Id;
        return CreatedAtRoute(nameof(GetGasStationById), new { id = gasStation.Id }, gasStation);
    }

    [HttpPut("Update", Name = nameof(UpdateGasStation))]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> UpdateGasStation([FromBody] GasStation gasStation)
    {
        if (gasStation == null || gasStation.Id <= 0)
            BadRequest();

        var result = await _repository.GetAsync(x => x.Id == gasStation.Id, true);
        if (result == null)
            return NotFound();

        _repository.UpdateAsync(result);

        return NoContent();
    }

    [HttpDelete("{id}", Name = nameof(DeleteGasStation))]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<bool>> DeleteGasStation(int id)
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
