using BLL.Services.Interfaces;
using Contracts.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Controllers
{
    public class OrdersController1 : Controller
    {
        private readonly IOrderService _order;

        public OrdersController1(IOrderService order)
        {
            _order = order;
        }

        // GET: Orders
        public async Task<IActionResult> Index()
        {
            var order = await _order.GetAll();
            return View(order);
        }

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _order == null)
            {
                return NotFound();
            }

            var order = await _order.GetById(id.Value);
            return View(order);
        }

        // GET: Orders/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Orders/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,СourierId,ProductId,OrderTime,IsDelivered,IsReceived")] Order order)
        {
            if (ModelState.IsValid)
            {
                _order.Add(order);
                return RedirectToAction(nameof(Index));
            }
            return View(order);
        }

        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _order == null)
            {
                return NotFound();
            }

            var order = await _order.GetById(id.Value);

            return View(order);
        }

        // POST: Orders/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,СourierId,ProductId,OrderTime,IsDelivered,IsReceived")] Order order)
        {
            if (id != order.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _order.Update(order);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderExists(order.Id))
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
            return View(order);
        }
        public bool OrderExists(int id)
        {
            return _order.GetById(id) != null;
        }

        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _order == null)
            {
                return NotFound();
            }

            var order = await _order.GetById(id.Value);
            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_order == null)
            {
                return Problem("Entity set 'AppDbContext.Orders'  is null.");
            }
            var order = await _order.GetById(id);
            if (order != null)
            {
                _order.Delete(id);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
