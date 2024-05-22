using FitnessApp.Models;
using FitnessApp.Services;
using Microsoft.EntityFrameworkCore;

public class MasuratoriRepository : IMasuratoriRepository
{
    private readonly ApplicationContext _context;

    public MasuratoriRepository(ApplicationContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Masuratori>> GetAll()
    {
        return await _context.Masuratori.Include(m => m.Utilizator).ToListAsync();
    }

    public async Task<Masuratori> GetById(int id)
    {
        return await _context.Masuratori.Include(m => m.Utilizator).FirstOrDefaultAsync(m => m.ID_Masuratori == id);
    }

    public async Task Add(Masuratori masuratori)
    {
        _context.Masuratori.Add(masuratori);
        await _context.SaveChangesAsync();
    }

    public async Task Update(Masuratori masuratori)
    {
        _context.Masuratori.Update(masuratori);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var masuratori = await _context.Masuratori.FindAsync(id);
        if (masuratori != null)
        {
            _context.Masuratori.Remove(masuratori);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<bool> Exists(int id)
    {
        return await _context.Masuratori.AnyAsync(e => e.ID_Masuratori == id);
    }
}
