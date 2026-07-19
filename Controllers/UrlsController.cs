using Microsoft.AspNetCore.Mvc;
using Shortly.Application.DTOs;
using Shortly.Application.Interfaces;

namespace Shortly.Controllers;

[ApiController]
[Route("api")]
public sealed class UrlsController : ControllerBase
{
    private const long DefaultUserId = 1;

    private readonly ILinkService _linkService;

    public UrlsController(ILinkService linkService)
    {
        _linkService = linkService;
    }

    [HttpPost("urls")]
    public async Task<ActionResult<LinkResponse>> CreateUrl([FromBody] UrlCreateRequest request)
    {
        var link = await _linkService.CreateLink(request.Url, DefaultUserId);
        return CreatedAtAction(nameof(GetUrlById), new { id = link.Id }, link);
    }

    [HttpGet("urls")]
    public async Task<ActionResult<List<LinkResponse>>> GetUrls()
        => Ok(await _linkService.GetAllLinks());

    [HttpGet("urls/{id:long}")]
    public async Task<ActionResult<LinkResponse>> GetUrlById(long id)
    {
        try
        {
            return Ok(await _linkService.GetLinkById(id));
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }

    [HttpDelete("urls/{id:long}")]
    public async Task<IActionResult> DeleteUrl(long id)
    {
        try
        {
            await _linkService.DeleteLink(id);
            return NoContent();
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }

    [HttpGet("stats")]
    public async Task<ActionResult<UsageStatisticsResponse>> GetStats()
        => Ok(await _linkService.GetStatistics());
}