using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ExchangeMarket.DAL;
using Contracts;
using BAL.Services;
using Newtonsoft.Json;
using Serilog;
using BAL.Interfaces;
using Microsoft.AspNet.Identity;
using System.Data.Entity;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
//using ExchangeMarket.Models;

namespace ExchangeMarket.Controllers
{
    public class PeopleController : Controller
    {
        //private readonly MarketContext _personService;
        private readonly IPersonService _personService;
        private readonly IPasswordHasher<Person> _passwordHasher;

        public PeopleController(IPersonService personService, IPasswordHasher<Person> passwordHasher)
        {
            //_personService = context;
            _personService = personService;
            _passwordHasher = passwordHasher;
        }

        // GET: People
        [Microsoft.AspNetCore.Authorization.Authorize]
        public async Task<IActionResult> Index()
        {
            return View(await _personService.GetAllPeopleAsync());
        }

        // GET: People/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _personService.GetPersonByIdAsync == null)
            {
                return NotFound();
            }

            var person = await _personService.GetPersonByIdAsync((int)id);
            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }

        // GET: People/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: People/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,LastName,FirstMidName,Email,Password,Phone")] Person person)
        {
            if (ModelState.IsValid)
            {
                // Hash the password and store it in the Person object
                person.PasswordHash = _passwordHasher.HashPassword(person, person.Password);

                //// Save changes to the database
                //await _context.SaveChangesAsync();
                _personService.AddPersonAsync(person);
                //await _personService..SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(person);
        }

        // GET: People/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = await _personService.GetPersonByIdAsync(id.Value);

            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }

        // POST: People/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,LastName,FirstMidName,Email,Password,Phone")] Person person)
        {
            if (id != person.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _personService.UpdatePersonAsync(person);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (id == null || _personService.GetPersonByIdAsync == null)
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
            return View(person);
        }

        // GET: People/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = await _personService.GetPersonByIdAsync(id.Value);
            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }

        // POST: People/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var person = await _personService.GetPersonByIdAsync(id);
            if (person == null)
            {
                var pr = Problem("This member is not found");

                var prData = new
                {
                    value = pr.Value,
                    status = pr.StatusCode
                };
                var json = JsonConvert.SerializeObject(prData);
                Log.Information(json);

                return NotFound();
            }

            await _personService.DeletePersonAsync(person);
            return RedirectToAction(nameof(Index));
        }

        //private bool PersonExists(int id)
        //{
        //    return _personService.PersonExists(id);
        //}

    }
}
