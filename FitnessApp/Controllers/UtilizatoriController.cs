using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using FitnessApp.Models; // Asigură-te că ai importat namespace-ul corespunzător pentru modelele tale

[Route("api/[controller]")]
[ApiController]
public class UtilizatoriController : ControllerBase
{
    private readonly ApplicationContext _context;

    public UtilizatoriController(ApplicationContext context)
    {
        _context = context;
    }

    // GET: api/Utilizatori
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Utilizator>>> GetUtilizatori()
    {
        return await _context.Utilizatori.ToListAsync();
    }

    // GET: api/Utilizatori/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Utilizator>> GetUtilizator(int id)
    {
        var utilizator = await _context.Utilizatori.FindAsync(id);

        if (utilizator == null)
        {
            return NotFound();
        }

        return utilizator;
    }

    // POST: api/Utilizatori
    [HttpPost]
    public async Task<ActionResult<Utilizator>> PostUtilizator(Utilizator utilizator)
    {
        _context.Utilizatori.Add(utilizator);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetUtilizator), new { id = utilizator.ID_Utilizator }, utilizator);
    }

    // PUT: api/Utilizatori/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutUtilizator(int id, Utilizator utilizator)
    {
        if (id != utilizator.ID_Utilizator)
        {
            return BadRequest();
        }

        _context.Entry(utilizator).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!UtilizatorExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    // DELETE: api/Utilizatori/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUtilizator(int id)
    {
        var utilizator = await _context.Utilizatori.FindAsync(id);
        if (utilizator == null)
        {
            return NotFound();
        }

        _context.Utilizatori.Remove(utilizator);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool UtilizatorExists(int id)
    {
        return _context.Utilizatori.Any(e => e.ID_Utilizator == id);
    }
}
