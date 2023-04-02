using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Contracts.Models;
using Microsoft.AspNetCore.Authorization;
using BLL.Services.Interfaces;
using System.Linq.Expressions;

namespace WebApp.Controllers
{
    [Authorize]
    public class ProductsController1 : Controller
    {
        private readonly IProductService _service;

        public ProductsController1(IProductService service)
        {
            _service = service;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            return View(_service);
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _service == null)
            {
                return NotFound();
            }
            Expression<Func<Product, bool>> predicate = product => product.Id == id;
            var product = await _service.Find(predicate);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Price,InStock")] Product product)
        {
            if (ModelState.IsValid)
            {
                _service.Add(product);
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _service == null)
            {
                return NotFound();
            }
            Expression<Func<Product, bool>> predicate = product => product.Id == id;
            var product = await _service.Find(predicate);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Price,InStock")] Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _service.Update(product);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.Id))
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
            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _service == null)
            {
                return NotFound();
            }
            Expression<Func<Product, bool>> predicate = product => product.Id == id;
            var product = await _service.Find(predicate);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_service == null)
            {
                return Problem("Entity set 'AppDbContext.Products'  is null.");
            }
            var product = await _service.GetById(id);
            if (product != null)
            {
                _service.Delete(id);
            }
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _service.GetById(id) != null;
        }
    }
}
