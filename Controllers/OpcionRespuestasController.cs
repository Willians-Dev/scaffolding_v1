
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ScaffoldingV1.Models;
using ScaffoldingV1.Data;

public class OpcionRespuestasController : Controller
{
    private readonly ApplicationDbContext _context;

    public OpcionRespuestasController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: OPCIONRESPUESTAS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.OpcionesRespuesta.ToListAsync());
    }

    // GET: OPCIONRESPUESTAS/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var opcionrespuesta = await _context.OpcionesRespuesta
            .FirstOrDefaultAsync(m => m.Id == id);
        if (opcionrespuesta == null)
        {
            return NotFound();
        }

        return View(opcionrespuesta);
    }

    // GET: OPCIONRESPUESTAS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: OPCIONRESPUESTAS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,PreguntaId,Texto,Valor,Orden")] OpcionRespuesta opcionrespuesta)
    {
        if (ModelState.IsValid)
        {
            _context.Add(opcionrespuesta);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        return View(opcionrespuesta);
    }

    // GET: OPCIONRESPUESTAS/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var opcionrespuesta = await _context.OpcionesRespuesta.FindAsync(id);
        if (opcionrespuesta == null)
        {
            return NotFound();
        }
        return View(opcionrespuesta);
    }

    // POST: OPCIONRESPUESTAS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("Id,PreguntaId,Texto,Valor,Orden")] OpcionRespuesta opcionrespuesta)
    {
        if (id != opcionrespuesta.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(opcionrespuesta);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OpcionRespuestaExists(opcionrespuesta.Id))
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

        return View(opcionrespuesta);
    }

    // GET: OPCIONRESPUESTAS/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var opcionrespuesta = await _context.OpcionesRespuesta
            .FirstOrDefaultAsync(m => m.Id == id);
        if (opcionrespuesta == null)
        {
            return NotFound();
        }

        return View(opcionrespuesta);
    }

    // POST: OPCIONRESPUESTAS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var opcionrespuesta = await _context.OpcionesRespuesta.FindAsync(id);
        if (opcionrespuesta != null)
        {
            _context.OpcionesRespuesta.Remove(opcionrespuesta);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool OpcionRespuestaExists(int? id)
    {
        return _context.OpcionesRespuesta.Any(e => e.Id == id);
    }
}
