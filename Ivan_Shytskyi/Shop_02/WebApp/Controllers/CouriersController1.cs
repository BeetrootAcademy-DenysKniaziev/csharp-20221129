using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Contracts.Models;
using Microsoft.AspNetCore.Authorization;
using BLL.Services.Interfaces;
using System.Linq.Expressions;

namespace WebApp.Controllers
{
    [Authorize]
    public class СouriersController1 : Controller
    {
        private readonly ICourierService _service;

        public СouriersController1(ICourierService service)
        {
            _service = service;
        }

        // GET: Сouriers
        public async Task<IActionResult> Index()
        {
            return View(_service);
        }

        // GET: Сouriers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _service == null)
            {
                return NotFound();
            }
            Expression<Func<Courier, bool>> predicate = admin => admin.Id == id;
            var сourier = await _service.Find(predicate);
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Address,Email,PhoneNumber")] Courier сourier)
        {
            if (ModelState.IsValid)
            {
                _service.Add(сourier);
                return RedirectToAction(nameof(Index));
            }
            return View(сourier);
        }

        // GET: Сouriers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _service == null)
            {
                return NotFound();
            }
            Expression<Func<Courier, bool>> predicate = admin => admin.Id == id;
            var сourier = await _service.Find(predicate);
            if (сourier == null)
            {
                return NotFound();
            }
            return View(сourier);
        }

        // POST: Сouriers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Address,Email,PhoneNumber")] Courier сourier)
        {
            if (id != сourier.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _service.Update(сourier);
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
            if (id == null || _service == null)
            {
                return NotFound();
            }
            Expression<Func<Courier, bool>> predicate = admin => admin.Id == id;
            var сourier = await _service.Find(predicate);
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
            if (_service == null)
            {
                return Problem("Entity set 'AppDbContext.Сourier'  is null.");
            }
            var сourier = await _service.GetById(id);
            if (сourier != null)
            {
                _service.Delete(id);
            }
            return RedirectToAction(nameof(Index));
        }

        private bool СourierExists(int id)
        {
            return _service.GetById(id) != null;
        }
    }
}
