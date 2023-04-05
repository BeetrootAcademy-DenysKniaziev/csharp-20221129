using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Contracts.Models;
using BLL.Services.Interfaces;
using System.Linq.Expressions;

namespace WebApp.Controllers
{
    public class StoregesController : Controller
    {
        private readonly IStoregeService _service;

        public StoregesController(IStoregeService service)
        {
            _service = service;
        }

        // GET: Storeges
        public async Task<IActionResult> Index()
        {
            var storege = await _service.GetAll();
            return View(storege);
        }

        // GET: Storeges/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _service == null)
            {
                return NotFound();
            }
            Expression<Func<Storege, bool>> predicate = product => product.Id == id;
            var storege = await _service.Find(predicate);
            if (storege == null)
            {
                return NotFound();
            }

            return View(storege);
        }

        // GET: Storeges/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Storeges/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Address")] Storege storege)
        {
            if (ModelState.IsValid)
            {
                _service.Add(storege);
                return RedirectToAction(nameof(Index));
            }
            return View(storege);
        }

        // GET: Storeges/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _service == null)
            {
                return NotFound();
            }
            Expression<Func<Storege, bool>> predicate = product => product.Id == id;
            var storege = await _service.Find(predicate);
            if (storege == null)
            {
                return NotFound();
            }
            return View(storege);
        }

        // POST: Storeges/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Address")] Storege storege)
        {
            if (id != storege.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _service.Update(storege);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StoregeExists(storege.Id))
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
            return View(storege);
        }

        // GET: Storeges/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _service == null)
            {
                return NotFound();
            }
            Expression<Func<Storege, bool>> predicate = product => product.Id == id;
            var storege = await _service.Find(predicate);
            if (storege == null)
            {
                return NotFound();
            }

            return View(storege);
        }

        // POST: Storeges/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_service == null)
            {
                return Problem("Entity set 'AppDbContext.Storege'  is null.");
            }
            var storege = await _service.GetById(id);
            if (storege != null)
            {
                _service.Delete(id);
            }
            return RedirectToAction(nameof(Index));
        }

        private bool StoregeExists(int id)
        {
            return _service.GetById(id) != null;
        }
    }
}
