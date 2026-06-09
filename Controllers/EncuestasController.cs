
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ScaffoldingV1.Models;
using ScaffoldingV1.Data;

public class EncuestasController : Controller
{
    private readonly ApplicationDbContext _context;

    public EncuestasController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: ENCUESTAS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.Encuestas.ToListAsync());
    }

    // GET: ENCUESTAS/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var encuesta = await _context.Encuestas
            .FirstOrDefaultAsync(m => m.Id == id);
        if (encuesta == null)
        {
            return NotFound();
        }

        return View(encuesta);
    }

    // GET: ENCUESTAS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: ENCUESTAS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Titulo,Descripcion,FechaCreacion,Activa")] Encuesta encuesta)
    {
        if (ModelState.IsValid)
        {
            _context.Add(encuesta);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(encuesta);
    }

    // GET: ENCUESTAS/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var encuesta = await _context.Encuestas.FindAsync(id);
        if (encuesta == null)
        {
            return NotFound();
        }
        return View(encuesta);
    }

    // POST: ENCUESTAS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("Id,Titulo,Descripcion,FechaCreacion,Activa")] Encuesta encuesta)
    {
        if (id != encuesta.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(encuesta);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EncuestaExists(encuesta.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        return View(encuesta);
    }

    // GET: ENCUESTAS/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var encuesta = await _context.Encuestas
            .FirstOrDefaultAsync(m => m.Id == id);
        if (encuesta == null)
        {
            return NotFound();
        }

        return View(encuesta);
    }

    // POST: ENCUESTAS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var encuesta = await _context.Encuestas.FindAsync(id);
        if (encuesta != null)
        {
            _context.Encuestas.Remove(encuesta);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool EncuestaExists(int? id)
    {
        return _context.Encuestas.Any(e => e.Id == id);
    }
}
