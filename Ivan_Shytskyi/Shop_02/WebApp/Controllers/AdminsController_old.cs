//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using Contracts.Models;
//using DAL;
//using Microsoft.AspNetCore.Authorization;

//namespace WebApp.Controllers
//{
//    [Authorize]
//    public class AdminsController : Controller
//    {
//        private readonly AppDbContext _context;

//        public AdminsController(AppDbContext context)
//        {
//            _context = context;
//        }

//        //GET: Admins
//        public async Task<IActionResult> Index()
//        {
//            return _context.Admin != null ?
//                        View(await _context.Admin.ToListAsync()) :
//                        Problem("Entity set 'AppDbContext.Admin'  is null.");
//        }

//        //GET: Admins/Details/5
//        public async Task<IActionResult> Details(int? id)
//        {
//            if (id == null || _context.Admin == null)
//            {
//                return NotFound();
//            }

//            var admin = await _context.Admin
//                .FirstOrDefaultAsync(m => m.Id == id);
//            if (admin == null)
//            {
//                return NotFound();
//            }

//            return View(admin);
//        }

//        //GET: Admins/Create
//        public IActionResult Create()
//        {
//            return View();
//        }

//        //POST: Admins/Create
//        //To protect from overposting attacks, enable the specific properties you want to bind to.
//        //For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Address,Email,PhoneNumber")] Admin admin)
//        {
//            if (ModelState.IsValid)
//            {
//                _context.Add(admin);
//                await _context.SaveChangesAsync();
//                return RedirectToAction(nameof(Index));
//            }
//            return View(admin);
//        }

//        //GET: Admins/Edit/5
//        public async Task<IActionResult> Edit(int? id)
//        {
//            if (id == null || _context.Admin == null)
//            {
//                return NotFound();
//            }

//            var admin = await _context.Admin.FindAsync(id);
//            if (admin == null)
//            {
//                return NotFound();
//            }
//            return View(admin);
//        }

//        //POST: Admins/Edit/5
//        //To protect from overposting attacks, enable the specific properties you want to bind to.
//        //For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Address,Email,PhoneNumber")] Admin admin)
//        {
//            if (id != admin.Id)
//            {
//                return NotFound();
//            }

//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    _context.Update(admin);
//                    await _context.SaveChangesAsync();
//                }
//                catch (DbUpdateConcurrencyException)
//                {
//                    if (!AdminExists(admin.Id))
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
//            return View(admin);
//        }

//        //GET: Admins/Delete/5
//        public async Task<IActionResult> Delete(int? id)
//        {
//            if (id == null || _context.Admin == null)
//            {
//                return NotFound();
//            }

//            var admin = await _context.Admin
//                .FirstOrDefaultAsync(m => m.Id == id);
//            if (admin == null)
//            {
//                return NotFound();
//            }

//            return View(admin);
//        }

//        //POST: Admins/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteConfirmed(int id)
//        {
//            if (_context.Admin == null)
//            {
//                return Problem("Entity set 'AppDbContext.Admin'  is null.");
//            }
//            var admin = await _context.Admin.FindAsync(id);
//            if (admin != null)
//            {
//                _context.Admin.Remove(admin);
//            }

//            await _context.SaveChangesAsync();
//            return RedirectToAction(nameof(Index));
//        }

//        private bool AdminExists(int id)
//        {
//            return (_context.Admin?.Any(e => e.Id == id)).GetValueOrDefault();
//        }
//    }
//}
