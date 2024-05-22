using FitnessApp.Models;
using FitnessApp.Services;

public class MasuratoriService : IMasuratoriService
{
    private readonly IMasuratoriRepository _repository;
    private readonly ApplicationContext _context; // Adăugăm contextul pentru a obține utilizatorii

    public MasuratoriService(IMasuratoriRepository repository, ApplicationContext context)
    {
        _repository = repository;
        _context = context;
    }

    public async Task<IEnumerable<Masuratori>> GetAllMasuratori()
    {
        return await _repository.GetAll();
    }

    public async Task<Masuratori> GetMasuratoriById(int id)
    {
        return await _repository.GetById(id);
    }

    public async Task AddMasuratori(Masuratori masuratori)
    {
        await _repository.Add(masuratori);
    }

    public async Task UpdateMasuratori(Masuratori masuratori)
    {
        await _repository.Update(masuratori);
    }

    public async Task DeleteMasuratori(int id)
    {
        await _repository.Delete(id);
    }

    public async Task<bool> MasuratoriExists(int id)
    {
        return await _repository.Exists(id);
    }

    public IEnumerable<Utilizator> GetUtilizatori()
    {
        return _context.Utilizatori.ToList(); // Returnează lista de utilizatori
    }
}
