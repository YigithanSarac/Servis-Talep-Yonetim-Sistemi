using Microsoft.AspNetCore.Mvc;
using ServisTalep.Api.DTOs;
using ServisTalep.Api.Services;

namespace ServisTalep.Api.Controllers;

[ApiController]
[Route("api/requests")]
public class RequestsController : ControllerBase
{
    private readonly IRequestService _requestService;

    public RequestsController(IRequestService requestService)
    {
        _requestService = requestService;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateServiceRequestDto dto)
    {
        var request = await _requestService.CreateAsync(dto);

        return CreatedAtAction(nameof(GetById), new { id = request.Id }, request);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] RequestQueryDto queryDto)
    {
        var requests = await _requestService.GetAllAsync(queryDto);

        return Ok(requests);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var request = await _requestService.GetByIdAsync(id);

        if (request == null)
            return NotFound();

        return Ok(request);
    }

    [HttpPut("{id}/status")]
    public async Task<IActionResult> UpdateStatus(int id, UpdateStatusDto dto)
    {
        var request = await _requestService.UpdateStatusAsync(id, dto);

        if (request == null)
            return NotFound();

        return Ok(request);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _requestService.DeleteAsync(id);

        if (!deleted)
            return NotFound();

        return NoContent();
    }
}