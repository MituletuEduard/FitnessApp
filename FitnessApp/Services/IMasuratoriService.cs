using FitnessApp.Models;

public interface IMasuratoriService
{
    Task<IEnumerable<Masuratori>> GetAllMasuratori();
    Task<Masuratori> GetMasuratoriById(int id);
    Task AddMasuratori(Masuratori masuratori);
    Task UpdateMasuratori(Masuratori masuratori);
    Task DeleteMasuratori(int id);
    Task<bool> MasuratoriExists(int id);
    IEnumerable<Utilizator> GetUtilizatori();
}
