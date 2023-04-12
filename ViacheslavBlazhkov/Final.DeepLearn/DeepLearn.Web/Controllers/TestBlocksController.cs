using DeepLearn.Contracts.LessonsStructs;
using DeepLearn.DAL.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DeepLearn.Web.Controllers
{
    [Authorize]
    public class TestBlocksController : Controller
    {
        private readonly AppDbContext _context;

        public TestBlocksController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(int theoryBlockId)
        {
            var theoryBlock = _context.TheoryBlocks.FirstOrDefault(tb => tb.Id == theoryBlockId);
            if (theoryBlock == null)
            {
                return NotFound();
            }

            var testBlock = _context.TestBlocks.FirstOrDefault(tb => tb.TheoryBlockId == theoryBlockId);
            //if (testBlock == null)
            //{
            //    return NotFound();
            //}

            return View(testBlock);
        }

        public IActionResult Create(int theoryBlockId)
        {
            TestBlock testBlock = new TestBlock
            {
                TheoryBlockId = theoryBlockId
            };
            return View(testBlock);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TestBlock testBlock)
        {
            if (ModelState.IsValid)
            {
                _context.Add(testBlock);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "TestBlocks", new { theoryBlockId = testBlock.TheoryBlockId });
            }
            return View(testBlock);
        }
    }
}
