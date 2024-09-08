using Manga;

namespace MangaServiceNS;
public class MangaService
{
    private readonly List<Mangas> _mangas = new();

    public IEnumerable<Mangas> getAll()
    {
        return _mangas;
    }

    public Mangas getByID(int id)
    {
        return _mangas.FirstOrDefault(manga => manga.id == id);
    }

    public void add(Mangas manga)
    {
        _mangas.Add(manga);
    }

    public void update(Mangas mangaUpdate)
    {
        var manga = getByID(mangaUpdate.id);
        if(manga != null){
            _mangas.Remove(manga);
            _mangas.Add(mangaUpdate);
        }
    }

    public void delete(int id){
        var manga = getByID(id);
        if(manga != null){
            _mangas.Remove(manga);
        }
    }
}