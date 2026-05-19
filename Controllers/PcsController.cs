using EFCoreCodeFirst.DTOs;
using EFCoreCodeFirst.Services;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreCodeFirst.Controllers;

[Route("api/[controller]")] 
[ApiController]
public class PcsController : ControllerBase
{
    private readonly IPCService _pcService;

    public PcsController(IPCService pcService)
    {
        _pcService = pcService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllPcs()
    {
        var pcs = await _pcService.GetAllPcsAsync();
        return Ok(pcs); 
    }

    [HttpGet("{id}/components")]
    public async Task<IActionResult> GetPcComponents(int id)
    {
        var pcDetails = await _pcService.GetPcDetailsByIdAsync(id);
        
        if (pcDetails == null)
        {
            return NotFound(new { message = $"Computer with ID {id} not found." }); // 404 
        }
        
        return Ok(pcDetails); // 200 
    }

    [HttpPost]
    public async Task<IActionResult> AddPc([FromBody] CreatePcDto dto)
    {
        var createdPc = await _pcService.AddPcAsync(dto);
        
        return CreatedAtAction(nameof(GetPcComponents), new { id = createdPc.Id }, createdPc);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdatePc(int id, [FromBody] UpdatePcDto dto)
    {
        try
        {
            await _pcService.UpdatePcAsync(id, dto);
            return NoContent(); // 204 
        }
        catch (KeyNotFoundException)
        {
            return NotFound(new { message = $"Computer with ID {id} not found." }); // 404 
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePc(int id)
    {
        var isDeleted = await _pcService.DeletePcAsync(id);
        
        if (!isDeleted)
        {
            return NotFound(new { message = $"Computer with ID {id} not found." }); // 404 
        }
        
        return NoContent(); // 204 
    }
}