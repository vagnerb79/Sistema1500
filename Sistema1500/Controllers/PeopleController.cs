using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sistema1500.Data;
using Sistema1500.Models;

namespace Sistema1500.Controllers
{
    [Authorize]
    public class PeopleController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PeopleController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: People
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.People
                .Include(p => p.Circle);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Filtros Mentorado = People
        public async Task<IActionResult> Student()
        {
            var applicationDbContext = _context.People
                .Where(x => x.Type == TypePerson.Mentorado)
                .Include(p => p.Circle);
            return View("Index", await applicationDbContext.ToListAsync());
        }

        // GET: Filtros Mentor = People
        public async Task<IActionResult> Teacher()
        {
            var applicationDbContext = _context.People
                .Where(x => x.Type == TypePerson.Mentor)
                .Include(p => p.Circle);
            return View("Index", await applicationDbContext.ToListAsync());
        }

        // GET: People/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = await _context.People
                .Include(p => p.Circle)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }

        // GET: People/Create
        public IActionResult Create()
        {
            ViewData["CircleId"] = new SelectList(_context.Set<Circle>(), "Id", "Name");
            return View();
        }

        // POST: People/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind
            ("Id,Name,Type,CircleId,Cpf,Email,Phone,BornDate,NivelStudy,University,GraduateDate,Enterprise,Recommendation,IsStudy")] Person person)
        {
            if (ModelState.IsValid)
            {
                person.UserName = person.Name;
                person.RegisterDate = DateTime.Now;

                _context.Add(person);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CircleId"] = new SelectList(_context.Set<Circle>(), "Id", "Name", person.CircleId);
            return View(person);
        }

        // GET: People/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = await _context.People.FindAsync(id);
            if (person == null)
            {
                return NotFound();
            }
            ViewData["CircleId"] = new SelectList(_context.Set<Circle>(), "Id", "Name", person.CircleId);
            return View(person);
        }

        // POST: People/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind
            ("Id,Name,Type,CircleId,Cpf,Email,Phone,BornDate,NivelStudy,University,GraduateDate,Enterprise,Recommendation,IsStudy")] Person person)
        {
            if (id != person.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {   //Buscando registros no banco
                    var userPerson = _context.People.FirstOrDefault(x => x.Id == id);

                    //Mapeando registros antigos no banco
                    person.RegisterDate = DateTime.Now;
                    userPerson.Type = person.Type;
                    userPerson.CircleId = person.CircleId;
                    userPerson.UserName = person.Name;
                    userPerson.Name = person.Name;
                    userPerson.BornDate = person.BornDate;
                    userPerson.Cpf = person.Cpf;
                    userPerson.Email = person.Email;
                    userPerson.Phone = person.Phone;
                    userPerson.NivelStudy = person.NivelStudy;
                    userPerson.University = person.University;
                    userPerson.GraduateDate = person.GraduateDate;
                    userPerson.Enterprise = person.Enterprise;
                    userPerson.Recommendation = person.Recommendation;
                    userPerson.IsStudy = person.IsStudy;

                    //Atualizando registros no banco
                    _context.Update(userPerson);
                    //Salvando registros no banco
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonExists(person.Id))
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
            ViewData["CircleId"] = new SelectList(_context.Set<Circle>(), "Id", "Name", person.CircleId);
            return View(person);
        }

        // GET: People/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = await _context.People
                .Include(p => p.Circle)
                .FirstOrDefaultAsync(m => m.Id == id);
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
            var person = await _context.People.FindAsync(id);
            _context.People.Remove(person);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        // POST: People/Delete/5 //Continuação Lógica do SCRIPT em index People
        [HttpPost, ActionName("MultipleDelete")]
        public async Task<IActionResult> MultipleDeleteConfirmed(List<int> ids)
        {
            try
            {
                foreach (int id in ids)
                {
                    var people = await _context.People.FindAsync(id);
                    _context.People.Remove(people);
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }

            await _context.SaveChangesAsync();
            return Ok();
        }

        private bool PersonExists(int id)
        {
            return _context.People.Any(e => e.Id == id);
        }
    }
}
