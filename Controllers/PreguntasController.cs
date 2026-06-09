
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ScaffoldingV1.Models;
using ScaffoldingV1.Data;

public class PreguntasController : Controller
{
    private readonly ApplicationDbContext _context;

    public PreguntasController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: PREGUNTAS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.Preguntas.ToListAsync());
    }

    // GET: PREGUNTAS/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var pregunta = await _context.Preguntas
            .FirstOrDefaultAsync(m => m.Id == id);
        if (pregunta == null)
        {
            return NotFound();
        }

        return View(pregunta);
    }

    // GET: PREGUNTAS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: PREGUNTAS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,EncuestaId,Texto,Tipo,Orden")] Pregunta pregunta)
    {
        if (ModelState.IsValid)
        {
            _context.Add(pregunta);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        return View(pregunta);
    }

    // GET: PREGUNTAS/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var pregunta = await _context.Preguntas.FindAsync(id);
        if (pregunta == null)
        {
            return NotFound();
        }
        return View(pregunta);
    }

    // POST: PREGUNTAS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("Id,EncuestaId,Texto,Tipo,Orden")] Pregunta pregunta)
    {
        if (id != pregunta.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(pregunta);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PreguntaExists(pregunta.Id))
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

        return View(pregunta);
    }

    // GET: PREGUNTAS/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var pregunta = await _context.Preguntas
            .FirstOrDefaultAsync(m => m.Id == id);
        if (pregunta == null)
        {
            return NotFound();
        }

        return View(pregunta);
    }

    // POST: PREGUNTAS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var pregunta = await _context.Preguntas.FindAsync(id);
        if (pregunta != null)
        {
            _context.Preguntas.Remove(pregunta);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool PreguntaExists(int? id)
    {
        return _context.Preguntas.Any(e => e.Id == id);
    }
}
