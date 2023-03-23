using AutoMapper;
using Lesson36.Bll.Services;
using Lesson36.WebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Lesson36.WebApp.Controllers
{
    [Authorize]
    public class PersonsController : Controller
    {
        private readonly IPersonService _personService;
        private readonly IMapper _mapper;

        public PersonsController(IPersonService personService, IMapper mapper)
        {
            _personService = personService;
            _mapper = mapper;
        }

        // GET: Persons
        public async Task<IActionResult> Index()
        {
            var persons = await _personService.GetAll();
            return View(_mapper.Map<IEnumerable<Person>>(persons));
        }

        // GET: Persons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = await _personService.GetById(id.Value);

            if (person == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<Person>(person));
        }

        // GET: Persons/Create
        public IActionResult Create()
        {
            return View();
        }

        //// POST: Persons/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Age,Gender,Address")] Person person)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(person);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(person);
        //}

        //// GET: Persons/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null || _context.Persons == null)
        //    {
        //        return NotFound();
        //    }

        //    var person = await _context.Persons.FindAsync(id);
        //    if (person == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(person);
        //}

        //// POST: Persons/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Age,Gender,Address")] Person person)
        //{
        //    if (id != person.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (!ModelState.IsValid)
        //        return View(person);

        //    try
        //    {
        //        _context.Update(person);
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!PersonExists(person.Id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }
        //    return RedirectToAction(nameof(Index));
        //}

        //// GET: Persons/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null || _context.Persons == null)
        //    {
        //        return NotFound();
        //    }

        //    var person = await _context.Persons
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (person == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(person);
        //}

        //// POST: Persons/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    if (_context.Persons == null)
        //    {
        //        return Problem("Entity set 'ApplicationDbContext.Persons'  is null.");
        //    }
        //    var person = await _context.Persons.FindAsync(id);
        //    if (person != null)
        //    {
        //        _context.Persons.Remove(person);
        //    }

        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool PersonExists(int id)
        //{
        //    return _context.Persons.Any(e => e.Id == id);
        //}
    }
}