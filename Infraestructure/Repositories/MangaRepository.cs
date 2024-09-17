using System.Text.Json;
using Manga;
namespace MangaRepository;

public class MangaRepositoryClass
{
    private List<Mangas> _mangas;
    private string _filePath;
    public MangaRepositoryClass(IConfiguration configuration)
    {
        _filePath = configuration.GetValue<string>("dataBank") ?? string.Empty;
        _mangas = LoadData();
    }

    private string GetCurrentFilePath()
    {
        var currentDirectory = Directory.GetCurrentDirectory();
        var currentFilePath = Path.Combine(currentDirectory, _filePath);
        return currentFilePath;
    }

    private List<Mangas> LoadData()
    {
        var currentFilePath = GetCurrentFilePath();
        if(File.Exists(currentFilePath))
        {
            var jsonData = File.ReadAllText(currentFilePath);
            return JsonSerializer.Deserialize<List<Mangas>>(jsonData)!;
        }

        return new List<Mangas>();
    }

    public IEnumerable<Mangas> GetAll()
    {
        return _mangas;
    }

    public Mangas GetById(int id)
    {
        return _mangas.FirstOrDefault(manga => manga.id == id)
            ?? new Mangas
            {
                Title = string.Empty,
                Author = string.Empty
            };
    }

    public void Add(Mangas manga)
    {
        var currentFilePath = GetCurrentFilePath();
        if (!File.Exists(currentFilePath))
        {
            return;
        }
        _mangas.Add(manga);
        File.WriteAllText(_filePath, JsonSerializer.Serialize(_mangas));
    }

    public void Update(Mangas mangatoUpdate)
    {
        var currentFilePath = GetCurrentFilePath();
        if(!File.Exists(currentFilePath))
        {
            return;
        }

        var index = _mangas.FindIndex(m => m.id == mangatoUpdate.id);
        if(index != -1)
        {
            _mangas[index] = mangatoUpdate;
            File.WriteAllText(_filePath, JsonSerializer.Serialize(_mangas)); 
        }
    }

    public void Delete(int id)
    {
        var currentFilePath = GetCurrentFilePath();
        if(!File.Exists(currentFilePath))
            return;
        
        _mangas.RemoveAll(m => m.id == id);
        File.WriteAllText(_filePath, JsonSerializer.Serialize(_mangas));
    }

}
