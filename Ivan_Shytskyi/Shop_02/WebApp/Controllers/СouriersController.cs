using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Contracts.Models;
using DAL;
using Microsoft.AspNetCore.Authorization;

namespace WebApp.Controllers
{
    [Authorize]
    public class СouriersController : Controller
    {
        private readonly AppDbContext _context;

        public СouriersController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Сouriers
        public async Task<IActionResult> Index()
        {
              return _context.Сourier != null ? 
                          View(await _context.Сourier.ToListAsync()) :
                          Problem("Entity set 'AppDbContext.Сourier'  is null.");
        }

        // GET: Сouriers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Сourier == null)
            {
                return NotFound();
            }

            var сourier = await _context.Сourier
                .FirstOrDefaultAsync(m => m.Id == id);
            if (сourier == null)
            {
                return NotFound();
            }

            return View(сourier);
        }

        // GET: Сouriers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Сouriers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Address,Email,PhoneNumber")] Сourier сourier)
        {
            if (ModelState.IsValid)
            {
                _context.Add(сourier);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(сourier);
        }

        // GET: Сouriers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Сourier == null)
            {
                return NotFound();
            }

            var сourier = await _context.Сourier.FindAsync(id);
            if (сourier == null)
            {
                return NotFound();
            }
            return View(сourier);
        }

        // POST: Сouriers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Address,Email,PhoneNumber")] Сourier сourier)
        {
            if (id != сourier.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(сourier);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!СourierExists(сourier.Id))
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
            return View(сourier);
        }

        // GET: Сouriers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Сourier == null)
            {
                return NotFound();
            }

            var сourier = await _context.Сourier
                .FirstOrDefaultAsync(m => m.Id == id);
            if (сourier == null)
            {
                return NotFound();
            }

            return View(сourier);
        }

        // POST: Сouriers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Сourier == null)
            {
                return Problem("Entity set 'AppDbContext.Сourier'  is null.");
            }
            var сourier = await _context.Сourier.FindAsync(id);
            if (сourier != null)
            {
                _context.Сourier.Remove(сourier);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool СourierExists(int id)
        {
          return (_context.Сourier?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
