using FitnessApp.Models;

public interface IMasuratoriRepository
{
    Task<IEnumerable<Masuratori>> GetAll();
    Task<Masuratori> GetById(int id);
    Task Add(Masuratori masuratori);
    Task Update(Masuratori masuratori);
    Task Delete(int id);
    Task<bool> Exists(int id);
}
