//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using Contracts.Models;
//using DAL;
//using Microsoft.AspNetCore.Authorization;

//namespace WebApp.Controllers
//{
//    public class StoregesController : Controller
//    {
//        private readonly AppDbContext _context;

//        public StoregesController(AppDbContext context)
//        {
//            _context = context;
//        }

//        // GET: Storeges
//        public async Task<IActionResult> Index()
//        {
//              return _context.Storege != null ? 
//                          View(await _context.Storege.ToListAsync()) :
//                          Problem("Entity set 'AppDbContext.Storege'  is null.");
//        }

//        // GET: Storeges/Details/5
//        public async Task<IActionResult> Details(int? id)
//        {
//            if (id == null || _context.Storege == null)
//            {
//                return NotFound();
//            }

//            var storege = await _context.Storege
//                .FirstOrDefaultAsync(m => m.Id == id);
//            if (storege == null)
//            {
//                return NotFound();
//            }

//            return View(storege);
//        }

//        // GET: Storeges/Create
//        public IActionResult Create()
//        {
//            return View();
//        }

//        // POST: Storeges/Create
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create([Bind("Id,Address")] Storege storege)
//        {
//            if (ModelState.IsValid)
//            {
//                _context.Add(storege);
//                await _context.SaveChangesAsync();
//                return RedirectToAction(nameof(Index));
//            }
//            return View(storege);
//        }

//        // GET: Storeges/Edit/5
//        public async Task<IActionResult> Edit(int? id)
//        {
//            if (id == null || _context.Storege == null)
//            {
//                return NotFound();
//            }

//            var storege = await _context.Storege.FindAsync(id);
//            if (storege == null)
//            {
//                return NotFound();
//            }
//            return View(storege);
//        }

//        // POST: Storeges/Edit/5
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Edit(int id, [Bind("Id,Address")] Storege storege)
//        {
//            if (id != storege.Id)
//            {
//                return NotFound();
//            }

//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    _context.Update(storege);
//                    await _context.SaveChangesAsync();
//                }
//                catch (DbUpdateConcurrencyException)
//                {
//                    if (!StoregeExists(storege.Id))
//                    {
//                        return NotFound();
//                    }
//                    else
//                    {
//                        throw;
//                    }
//                }
//                return RedirectToAction(nameof(Index));
//            }
//            return View(storege);
//        }

//        // GET: Storeges/Delete/5
//        public async Task<IActionResult> Delete(int? id)
//        {
//            if (id == null || _context.Storege == null)
//            {
//                return NotFound();
//            }

//            var storege = await _context.Storege
//                .FirstOrDefaultAsync(m => m.Id == id);
//            if (storege == null)
//            {
//                return NotFound();
//            }

//            return View(storege);
//        }

//        // POST: Storeges/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteConfirmed(int id)
//        {
//            if (_context.Storege == null)
//            {
//                return Problem("Entity set 'AppDbContext.Storege'  is null.");
//            }
//            var storege = await _context.Storege.FindAsync(id);
//            if (storege != null)
//            {
//                _context.Storege.Remove(storege);
//            }
            
//            await _context.SaveChangesAsync();
//            return RedirectToAction(nameof(Index));
//        }

//        private bool StoregeExists(int id)
//        {
//          return (_context.Storege?.Any(e => e.Id == id)).GetValueOrDefault();
//        }
//    }
//}
