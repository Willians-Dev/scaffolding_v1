
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ScaffoldingV1.Models;
using ScaffoldingV1.Data;

public class RespuestaDetallesController : Controller
{
    private readonly ApplicationDbContext _context;

    public RespuestaDetallesController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: RESPUESTADETALLES
    public async Task<IActionResult> Index()    
    {
        return View(await _context.RespuestaDetalles.ToListAsync());
    }

    // GET: RESPUESTADETALLES/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var respuestadetalle = await _context.RespuestaDetalles
            .FirstOrDefaultAsync(m => m.Id == id);
        if (respuestadetalle == null)
        {
            return NotFound();
        }

        return View(respuestadetalle);
    }

    // GET: RESPUESTADETALLES/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: RESPUESTADETALLES/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,RespuestaId,PreguntaId,OpcionRespuestaId,TextoRespuesta")] RespuestaDetalle respuestadetalle)
    {
        if (ModelState.IsValid)
        {
            _context.Add(respuestadetalle);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        return View(respuestadetalle);
    }

    // GET: RESPUESTADETALLES/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var respuestadetalle = await _context.RespuestaDetalles.FindAsync(id);
        if (respuestadetalle == null)
        {
            return NotFound();
        }
        return View(respuestadetalle);
    }

    // POST: RESPUESTADETALLES/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("Id,RespuestaId,PreguntaId,OpcionRespuestaId,TextoRespuesta")] RespuestaDetalle respuestadetalle)
    {
        if (id != respuestadetalle.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(respuestadetalle);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RespuestaDetalleExists(respuestadetalle.Id))
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

        return View(respuestadetalle);
    }

    // GET: RESPUESTADETALLES/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var respuestadetalle = await _context.RespuestaDetalles
            .FirstOrDefaultAsync(m => m.Id == id);
        if (respuestadetalle == null)
        {
            return NotFound();
        }

        return View(respuestadetalle);
    }

    // POST: RESPUESTADETALLES/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var respuestadetalle = await _context.RespuestaDetalles.FindAsync(id);
        if (respuestadetalle != null)
        {
            _context.RespuestaDetalles.Remove(respuestadetalle);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool RespuestaDetalleExists(int? id)
    {
        return _context.RespuestaDetalles.Any(e => e.Id == id);
    }
}
