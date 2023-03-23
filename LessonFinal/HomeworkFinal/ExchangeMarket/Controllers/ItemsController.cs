using BAL.Services;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http.ModelBinding;
using Contracts;
using BAL.Interfaces;
using System.Data.Entity.Infrastructure;
//using ExchangeMarket.Models;

public class ItemsController : Controller
{
    private readonly IItemService _itemService;

    public ItemsController(IItemService itemService)
    {
        _itemService = itemService;
    }

    // GET: Items
    public async Task<IActionResult> Index()
    {
        var items = await _itemService.GetItemsAsync();
        return View(items);
    }

    // GET: Items/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var item = await _itemService.GetItemByIdAsync(id.Value);
        if (item == null)
        {
            return NotFound();
        }

        return View(item);
    }

    [HttpGet]
    public async Task<IActionResult> GetTagName(int id)
    {
        //var tag = await _itemService.GetTagByIdAsync(id);
        var tags = await _itemService.GetAllTagsAsync();
        var tag = tags.FirstOrDefault<Contracts.Tag>(t => t.TagID == id);
        if (tag == null)
        {
            return NotFound();
        }
        return Ok(tag.TagName);
    }

    //GET: Items/Create
    public async Task<IActionResult> Create()
    {
        var tags = await _itemService.GetAllTagsAsync();
        ViewData["TagID"] = new SelectList(tags, "TagID", "TagName");
        return View();
    }
    //public async Task<IActionResult> Create()
    //{
    //    var tags = await _itemService.GetAllTagsAsync();
    //    ViewData["TagID"] = new SelectList(tags, "TagID", "TagName");

    //    // Create a new Item object and assign the selected Tag to it
    //    var item = new Item();
    //    if (tags.Count() > 0)
    //    {
    //        item.Tag = tags.First(); // Assign the first tag by default
    //        //item.Tag.Description = "Empty";
    //        //item.Tag.Image = "Empty";
    //        item.TagID = tags.First().TagID; // Set the TagID property
    //        //item.Description = "Some Description";
    //        //item.Amount = 0;
    //        //item.Image = "Some Link";

    //    }
    //    return View(item);
    //}

    // POST: Items/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("ItemID,TagID,Amount,Description,Image")] Item item)
    {
        var tags = await _itemService.GetAllTagsAsync();
        var tag = tags.FirstOrDefault<Tag>(t => t.TagID == item.TagID);//await _itemService.GetTagByIdAsync(item.TagID);
        if (tag == null)
        {
            ModelState.AddModelError(nameof(item.TagID), "Tag not found.");
        }
        else
        {
            item.Tag = tag;
        }

        if (item.Image == "" || item.Image == null) item.Image = item.Tag.Image;
        if (item.Description == "" || item.Description == null ) item.Description = item.Tag.Description;
        if (!ModelState.IsValid)
        {
            var errors = ModelState.Where(x => x.Value.Errors.Any())
                                    .Select(x => new { x.Key, x.Value.Errors })
                                    .ToArray();
            // debug or log the errors here
           // return View(item);
        }
        ModelState.Remove("Tag");

        if (ModelState.IsValid)
        {
            await _itemService.CreateItemAsync(item);
            return RedirectToAction(nameof(Index));
        }


        ViewData["TagID"] = new SelectList(tags, "TagID", "TagID");
        return View(item);
    }
    //item.Tag = tags.FirstOrDefault<Tag>(t => t.TagID == item.TagID);

    // GET: Items/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var item = await _itemService.GetItemByIdAsync(id.Value);
        if (item == null)
        {
            return NotFound();
        }
        var tags = await _itemService.GetAllTagsAsync();
        ViewData["TagID"] = new SelectList(tags, "TagID", "TagID");
        //ViewData["TagID"] = new SelectList((System.Collections.IEnumerable)_itemService.GetAllTagsAsync(), "TagID", "TagID", item.TagID);
        return View(item);
    }

    // POST: Items/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("ItemID,TagID,Amount,Description,Image")] Item item)
    {
        if (id != item.ItemID)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                await _itemService.UpdateItemAsync(id, item);
            }
            catch (DbUpdateConcurrencyException)
            {
                //if (!_itemService.ItemExists(item.ItemID))
                if(_itemService.GetItemByIdAsync(id) == null)
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
        var tags = await _itemService.GetAllTagsAsync();
        ViewData["TagID"] = new SelectList(tags, "TagID", "TagID");
        //ViewData["TagID"] = new SelectList((System.Collections.IEnumerable)_itemService.GetAllTagsAsync(), "TagID", "TagID", item.TagID);
        return View(item);
    }

    // GET: Items/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var item = await _itemService.GetItemByIdAsync(id.Value);
        if (item == null)
        {
            return NotFound();
        }

        return View(item);
    }

    // POST: Items/Delete/5
    [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var item = await _itemService.GetItemByIdAsync(id);
            if (item != null)
            {
                await _itemService.DeleteItemAsync(id);
            }

            return RedirectToAction(nameof(Index));
        }

        //private bool ItemExists(int id)


    //private bool ItemExists(int id)
    //{
    //    return _context.Item.Any(e => e.ItemID == id);
    //}
}




//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using Microsoft.EntityFrameworkCore;
//using ExchangeMarket.DAL;
////using ExchangeMarket.Models;
//using Contracts;

//namespace ExchangeMarket.Controllers
//{
//    public class ItemsController : Controller
//    {
//        private readonly MarketContext _context;// ZXAMIST` Pryamogo vykorystannya treba cherez Dependenci Injection

//        public ItemsController(MarketContext context)
//        {
//            _context = context;
//        }

//        // GET: Items
//        public async Task<IActionResult> Index()
//        {
//            var marketContext = _context.Item.Include(i => i.Tag);
//            return View(await marketContext.ToListAsync());
//        }

//        // GET: Items/Details/5
//        public async Task<IActionResult> Details(int? id)
//        {
//            if (id == null || _context.Item == null)
//            {
//                return NotFound();
//            }

//            var item = await _context.Item
//                .Include(i => i.Tag)
//                .FirstOrDefaultAsync(m => m.ItemID == id);
//            if (item == null)
//            {
//                return NotFound();
//            }

//            return View(item);
//        }

// GET: Items/Create
//    public IActionResult Create()
//{
//    ViewData["TagID"] = new SelectList(_context.Tag, "TagID", "TagID");
//    return View();
//}

//        // POST: Items/Create
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create([Bind("ItemID,TagID,Amount,Description,Image")] Item item)
//        {
//            if (ModelState.IsValid)
//            {
//                _context.Add(item);
//                await _context.SaveChangesAsync();
//                return RedirectToAction(nameof(Index));
//            }
//            ViewData["TagID"] = new SelectList(_context.Tag, "TagID", "TagID", item.TagID);
//            return View(item);
//        }

//        // GET: Items/Edit/5
//        public async Task<IActionResult> Edit(int? id)
//        {
//            if (id == null || _context.Item == null)
//            {
//                return NotFound();
//            }

//            var item = await _context.Item.FindAsync(id);
//            if (item == null)
//            {
//                return NotFound();
//            }
//            ViewData["TagID"] = new SelectList(_context.Tag, "TagID", "TagID", item.TagID);
//            return View(item);
//        }

//        // POST: Items/Edit/5
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Edit(int id, [Bind("ItemID,TagID,Amount,Description,Image")] Item item)
//        {
//            if (id != item.ItemID)
//            {
//                return NotFound();
//            }

//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    _context.Update(item);
//                    await _context.SaveChangesAsync();
//                }
//                catch (DbUpdateConcurrencyException)
//                {
//                    if (!ItemExists(item.ItemID))
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
//            ViewData["TagID"] = new SelectList(_context.Tag, "TagID", "TagID", item.TagID);
//            return View(item);
//        }

//        // GET: Items/Delete/5
//        public async Task<IActionResult> Delete(int? id)
//        {
//            if (id == null || _context.Item == null)
//            {
//                return NotFound();
//            }

//            var item = await _context.Item
//                .Include(i => i.Tag)
//                .FirstOrDefaultAsync(m => m.ItemID == id);
//            if (item == null)
//            {
//                return NotFound();
//            }

//            return View(item);
//        }

//        // POST: Items/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteConfirmed(int id)
//        {
//            if (_context.Item == null)
//            {
//                return Problem("Entity set 'MarketContext.Item'  is null.");
//            }
//            var item = await _context.Item.FindAsync(id);
//            if (item != null)
//            {
//                _context.Item.Remove(item);
//            }

//            await _context.SaveChangesAsync();
//            return RedirectToAction(nameof(Index));
//        }

//        private bool ItemExists(int id)
//        {
//          return _context.Item.Any(e => e.ItemID == id);
//        }
//    }
//}
