using AutoMapper;
using Manga;
using MangaDTO;
using MangaServiceNS;
using Microsoft.AspNetCore.Mvc;

namespace MangaControllerNS;

[ApiController]
[Route("api/[controller]")]

public class MangaController : ControllerBase
{
    private readonly MangaService _mangaService;
    private readonly IMapper _mapper;
    public MangaController(MangaService mangaService, IMapper mapper)
    {
        _mangaService = mangaService;
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult getAll()
    {
        var mangas = _mangaService.getAll();
        var mangaDtos = _mapper.Map<IEnumerable<MangaDtoClass>>(mangas);

        return Ok(mangaDtos);
    }

    [HttpGet("{id:int}")]
    public IActionResult getById([FromRoute] int id)
    {
        var manga = _mangaService.getByID(id);
        if (manga == null)
        {
            return NotFound();
        }
        
        var dto = _mapper.Map<MangaDtoClass>(manga);
        return Ok(dto);
    }

    [HttpPost]
    public IActionResult add([FromBody] Mangas manga)
    {
        // _mangaService.add(manga);
        // return CreatedAtAction(nameof(getById), new { id = manga.id }, manga);
        var entity = _mapper.Map<Mangas>(manga);
        
        var mangas = _mangaService.getAll();
        var mangaId = mangas.Count() + 1;

        entity.id = mangaId;

        _mangaService.add(entity);
        
        var dto = _mapper.Map<MangaDtoClass>(entity);

        return CreatedAtAction(nameof(getById), new {id = entity.id}, dto);


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