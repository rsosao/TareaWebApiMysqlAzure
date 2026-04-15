using ApiAzureTarea2;
using ApiAzureTarea2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiAzureTarea2.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LibrosController(AppDbContext db) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Libro>>> GetLibros()
    {
        return await db.Libros.OrderBy(l => l.LibroId).ToListAsync();
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Libro>> GetLibro(int id)
    {
        var libro = await db.Libros.FirstOrDefaultAsync(l => l.LibroId == id);
        if (libro == null)
            return NotFound();
        return libro;
    }

    [HttpPost]
    public async Task<ActionResult<Libro>> PostLibro([FromBody] Libro libro)
    {
        libro.LibroId = 0;
        db.Libros.Add(libro);
        await db.SaveChangesAsync();
        return CreatedAtAction(nameof(GetLibro), new { id = libro.LibroId }, libro);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> PutLibro(int id, [FromBody] Libro libro)
    {
        if (id != libro.LibroId)
            return BadRequest();

        if (!await db.Libros.AnyAsync(l => l.LibroId == id))
            return NotFound();

        db.Libros.Update(libro);
        await db.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteLibro(int id)
    {
        var libro = await db.Libros.FindAsync(id);
        if (libro == null)
            return NotFound();

        db.Libros.Remove(libro);
        await db.SaveChangesAsync();
        return NoContent();
    }
}
