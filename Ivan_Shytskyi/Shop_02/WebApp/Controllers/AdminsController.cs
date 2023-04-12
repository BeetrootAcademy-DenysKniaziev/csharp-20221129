using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Contracts.Models;
using BLL.Services.Interfaces;
using System.Linq.Expressions;

namespace WebApp.Controllers
{

    public class AdminsController : Controller
    {
        private readonly IAdminService _service;

        public AdminsController(IAdminService service)
        {
            _service = service;
        }

        //GET: Admins
        public async Task<IActionResult> Index()
        {
            var admin = await _service.GetAll();
            return View(admin);
        }

        //GET: Admins/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _service == null)
            {
                return NotFound();
            }
            Expression<Func<Admin, bool>> predicate = admin => admin.Id == id;
            var admin = await _service.Find(predicate);
            if (admin == null)
            {
                return NotFound();
            }

            return View(admin);
        }

        //GET: Admins/Create
        public IActionResult Create()
        {
            return View();
        }

        //POST: Admins/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Address,Email,PhoneNumber")] Admin admin)
        {
            if (ModelState.IsValid)
            {
                _service.Add(admin);
                return RedirectToAction(nameof(Index));
            }
            return View(admin);
        }

        //GET: Admins/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _service == null)
            {
                return NotFound();
            }
            Expression<Func<Admin, bool>> predicate = admin => admin.Id == id;
            var admin = await _service.Find(predicate);
            if (admin == null)
            {
                return NotFound();
            }
            return View(admin);
        }

        //POST: Admins/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Address,Email,PhoneNumber")] Admin admin)
        {
            if (id != admin.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _service.Update(admin);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdminExists(admin.Id))
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
            return View(admin);
        }

        //GET: Admins/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _service == null)
            {
                return NotFound();
            }
            Expression<Func<Admin, bool>> predicate = admin => admin.Id == id;
            var admin = await _service.Find(predicate);
            if (admin == null)
            {
                return NotFound();
            }

            return View(admin);
        }

        //POST: Admins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_service == null)
            {
                return Problem("Entity set 'AppDbContext.Admin'  is null.");
            }
            var admin = await _service.GetById(id);
            if (admin != null)
            {
                _service.Delete(id);
            }
            return RedirectToAction(nameof(Index));
        }

        private bool AdminExists(int id)
        {
            return _service.GetById(id) != null;
        }
    }
}
