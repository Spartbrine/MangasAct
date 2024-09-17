using Manga;
using MangaRepository;


namespace MangaServiceNS;
public class MangaService
{
    private readonly MangaRepositoryClass _mangaRepo;
    // private readonly List<Mangas> _mangas = new();

    public MangaService(MangaRepositoryClass mangaRepository)
    {
        this._mangaRepo = mangaRepository;
    }

    public IEnumerable<Mangas> getAll()
    {
        return _mangaRepo.GetAll();
    }

    public Mangas getByID(int id)
    {
        return _mangaRepo.GetById(id);
    }

    public void add(Mangas manga)
    {
        _mangaRepo.Add(manga);
    }

    public void update(Mangas mangaUpdate)
    {
        var manga = getByID(mangaUpdate.id);
        // if(manga != null){
        //     _mangas.Remove(manga);
        //     _mangas.Add(mangaUpdate);
        // }

        if(manga.id > 0)
        {
            _mangaRepo.Update(mangaUpdate);
        }
    }

    public void delete(int id){
        var manga = getByID(id);
        // if(manga != null){
        //     _mangas.Remove(manga);
        // }
        if (manga.id > 0)
        {
            _mangaRepo.Delete(id);
        }
    }
}