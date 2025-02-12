﻿using FuelChampion.Api.Repositories;
using FuelChampion.Library.Models;
using Microsoft.AspNetCore.Mvc;

namespace FuelChampion.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class InvoiceController : ControllerBase
{
    private readonly IInvoiceRepository _repository;

    public InvoiceController(IInvoiceRepository repository)
    {
        _repository = repository;
    }

    [HttpGet()]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<IEnumerable<Invoice>>> GetInvoices()
    {
        var invoice = await _repository.GetAllAsync();

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok(invoice);
    }

    [HttpGet("InvoicesView/{userId}", Name = nameof(GetInvoicesViewByUserId))]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<IList<InvoiceView>>> GetInvoicesViewByUserId(string userId)
    {
        var invoice = await _repository.GetInvoiceViewByUserId(userId);

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok(invoice);
    }

    [HttpGet("{userId}", Name= nameof(GetInvoicesByUserId))]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<IList<Invoice>>> GetInvoicesByUserId(string userId)
    {
        var invoice = await _repository.GetAllByUserIdAsync(userId);

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok(invoice);
    }

    [HttpGet("{id:int}", Name = nameof(GetInvoiceById))]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<Invoice>> GetInvoiceById(int id)
    {
        if (id <= 0)
        {
            return BadRequest();
        }

        var invoice = await _repository.GetAsync(invoice => invoice.Id == id);
        if (invoice == null)
        {
            return NotFound($"The invoice with id: {id} not found");
        }

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok(invoice);
    }

    [HttpPost("Create", Name = nameof(CreateInvoice))]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<Invoice>> CreateInvoice([FromBody] Invoice invoice)
    {
        if (invoice == null)
            return BadRequest();

        var createdInvoice = await _repository.CreateAsync(invoice);

        invoice.Id = createdInvoice.Id;
        return CreatedAtRoute("GetAuthorById", new { id = invoice.Id }, invoice);
    }

    [HttpPut("Update/{id}", Name = nameof(UpdateInvoiceId))]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> UpdateInvoiceId(int id, [FromBody] Invoice invoice)
    {
        if (invoice == null || id <= 0)
            BadRequest();

        var existingInvoice = await _repository.GetAsync(i => i.Id == id, true);
        if (existingInvoice == null)
            return NotFound();

        _repository.UpdateAsync(invoice);

        return NoContent();
    }

    [HttpPut("Update", Name = nameof(UpdateInvoice))]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> UpdateInvoice([FromBody] Invoice invoice)
    {
        if (invoice == null || invoice.Id <= 0)
            BadRequest();

        var existingInvoice = await _repository.GetAsync(i => i.Id == invoice.Id, true);
        if (existingInvoice == null)
            return NotFound();

        _repository.UpdateAsync(invoice);

        return NoContent();
    }

    [HttpDelete("{id}", Name = nameof(DeleteInvoice))]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<bool>> DeleteInvoice(int id)
    {
        if (id <= 0)
            return BadRequest();

        var invoice = await _repository.GetAsync(invoice => invoice.Id == id);

        if (invoice == null)
            return NotFound($"The invoice with id {id} not found");

        await _repository.DeleteAsync(invoice);

        return Ok(true);
    }
}
