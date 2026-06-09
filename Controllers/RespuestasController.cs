
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ScaffoldingV1.Models;
using ScaffoldingV1.Data;

public class RespuestasController : Controller
{
    private readonly ApplicationDbContext _context;

    public RespuestasController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: RESPUESTAS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.Respuestas.ToListAsync());
    }

    // GET: RESPUESTAS/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var respuesta = await _context.Respuestas
            .FirstOrDefaultAsync(m => m.Id == id);
        if (respuesta == null)
        {
            return NotFound();
        }

        return View(respuesta);
    }

    // GET: RESPUESTAS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: RESPUESTAS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,EncuestaId,Fecha,NombreRespondente,Observacion")] Respuesta respuesta)
    {
        if (ModelState.IsValid)
        {
            _context.Add(respuesta);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        return View(respuesta);
    }

    // GET: RESPUESTAS/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var respuesta = await _context.Respuestas.FindAsync(id);
        if (respuesta == null)
        {
            return NotFound();
        }
        return View(respuesta);
    }

    // POST: RESPUESTAS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("Id,EncuestaId,Fecha,NombreRespondente,Observacion")] Respuesta respuesta)
    {
        if (id != respuesta.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(respuesta);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RespuestaExists(respuesta.Id))
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

        return View(respuesta);
    }

    // GET: RESPUESTAS/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var respuesta = await _context.Respuestas
            .FirstOrDefaultAsync(m => m.Id == id);
        if (respuesta == null)
        {
            return NotFound();
        }

        return View(respuesta);
    }

    // POST: RESPUESTAS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var respuesta = await _context.Respuestas.FindAsync(id);
        if (respuesta != null)
        {
            _context.Respuestas.Remove(respuesta);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool RespuestaExists(int? id)
    {
        return _context.Respuestas.Any(e => e.Id == id);
    }
}
