using Manga;
using MangaServiceNS;
using Microsoft.AspNetCore.Mvc;

namespace MangaControllerNS;

[ApiController]
[Route("api/[controller]")]

public class MangaController : ControllerBase
{
    private readonly MangaService _mangaService;
    public MangaController(MangaService mangaService)
    {
        this._mangaService = mangaService;
    }

    [HttpGet]
    public IActionResult getAll()
    {
        return Ok(_mangaService.getAll());
    }

    [HttpGet("{id:int}")]
    public IActionResult getById([FromRoute] int id)
    {
        var manga = _mangaService.getByID(id);
        if (manga == null)
        {
            return NotFound();
        }
        return Ok(manga);
    }

    [HttpPost]
    public IActionResult add([FromBody] Mangas manga)
    {
        _mangaService.add(manga);
        return CreatedAtAction(nameof(getById), new { id = manga.id }, manga);
    }

    [HttpPut("{id}")]
    public IActionResult update(int id, Mangas manga)
    {
        if (id != manga.id)
        {
            return BadRequest();
        }

        _mangaService.update(manga);
        return NoContent();

    }

    [HttpDelete("{id}")]
    public IActionResult delete(int id)
    {
        _mangaService.delete(id);
        return NoContent();
    }
}