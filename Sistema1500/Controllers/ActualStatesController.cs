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
    public class ActualStatesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ActualStatesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ActualStates
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ActualStates
                .Include(a => a.Circle)
                .Include(a => a.Person)
                .Include(a => a.Project)
                .Include(a => a.TypeConsultor);
            return View(await applicationDbContext.ToListAsync());
        }


        // GET: ActualStates/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var actualState = await _context.ActualStates
                .Include(a => a.Circle)
                .Include(a => a.Person)
                .Include(a => a.Project)
                .Include(a => a.TypeConsultor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (actualState == null)
            {
                return NotFound();
            }

            return View(actualState);
        }

        // GET: ActualStates/Create
        public IActionResult Create()
        {
            ViewData["CircleId"] = new SelectList(_context.Circles, "Id", "Name");
            ViewData["PersonId"] = new SelectList(_context.People, "Id", "Name");
            ViewData["ProjectId"] = new SelectList(_context.Projects, "Id", "Name");
            ViewData["TypeConsultorId"] = new SelectList(_context.TypeConsultors, "Id", "Name");
            return View();
        }

        // POST: ActualStates/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind
            ("Id,ProjectId,CircleId,TypeConsultorId,TypeObject,Description,TimePlanned,PersonId,RealTime,Delivered,RealValue,Sprint")] ActualState actualState)
        {
            if (ModelState.IsValid)
            {
                // Adiconando apenas as classses onde necessários cálculos
                var projeto = await _context.Projects
                    .Where(x => x.Id == actualState.ProjectId)
                    .FirstOrDefaultAsync();

                var consultor = await _context.TypeConsultors
                    .Where(x => x.Id == actualState.TypeConsultorId)
                    .FirstOrDefaultAsync();

                actualState.Project = projeto;
                actualState.TypeConsultor = consultor;

                actualState.AttCalculos();

                _context.Add(actualState);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CircleId"] = new SelectList(_context.Circles, "Id", "Name", actualState.CircleId);
            ViewData["PersonId"] = new SelectList(_context.People, "Id", "Name", actualState.PersonId);
            ViewData["ProjectId"] = new SelectList(_context.Projects, "Id", "Name", actualState.ProjectId);
            ViewData["TypeConsultorId"] = new SelectList(_context.TypeConsultors, "Id", "Name", actualState.TypeConsultorId);
            return View(actualState);
        }

        // GET: ActualStates/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var actualState = await _context.ActualStates.FindAsync(id);
            if (actualState == null)
            {
                return NotFound();
            }
            ViewData["CircleId"] = new SelectList(_context.Circles, "Id", "Name", actualState.CircleId);
            ViewData["PersonId"] = new SelectList(_context.People, "Id", "Name", actualState.PersonId);
            ViewData["ProjectId"] = new SelectList(_context.Projects, "Id", "Name", actualState.ProjectId);
            ViewData["TypeConsultorId"] = new SelectList(_context.TypeConsultors, "Id", "Name", actualState.TypeConsultorId);
            return View(actualState);
        }

        // POST: ActualStates/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind
            ("Id,ProjectId,CircleId,TypeConsultorId,TypeObject,Description,TimePlanned,PersonId,RealTime,Delivered,RealValue,Sprint")] ActualState actualState)
        {
            if (id != actualState.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Adiconando apenas as classses onde necessários cálculos
                    var projeto = await _context.Projects
                        .Where(x => x.Id == actualState.ProjectId)
                        .FirstOrDefaultAsync();

                    var consultor = await _context.TypeConsultors
                        .Where(x => x.Id == actualState.TypeConsultorId)
                        .FirstOrDefaultAsync();

                    actualState.Project = projeto;
                    actualState.TypeConsultor = consultor;

                    actualState.AttCalculos();

                    _context.Update(actualState);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ActualStateExists(actualState.Id))
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
            ViewData["CircleId"] = new SelectList(_context.Circles, "Id", "Name", actualState.CircleId);
            ViewData["PersonId"] = new SelectList(_context.People, "Id", "Name", actualState.PersonId);
            ViewData["ProjectId"] = new SelectList(_context.Projects, "Id", "Name", actualState.ProjectId);
            ViewData["TypeConsultorId"] = new SelectList(_context.TypeConsultors, "Id", "Name", actualState.TypeConsultorId);
            return View(actualState);
        }

        // GET: ActualStates/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var actualState = await _context.ActualStates
                .Include(a => a.Circle)
                .Include(a => a.Person)
                .Include(a => a.Project)
                .Include(a => a.TypeConsultor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (actualState == null)
            {
                return NotFound();
            }

            return View(actualState);
        }

        // POST: ActualStates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var actualState = await _context.ActualStates.FindAsync(id);
            _context.ActualStates.Remove(actualState);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // POST: ActualStates/Delete/5 //Continuação Lógica do SCRIPT em index ActualStates
        [HttpPost, ActionName("MultipleDelete")]
        public async Task<IActionResult> MultipleDeleteConfirmed(List<int> ids)
        {
            try
            {
                foreach (int id in ids)
                {
                    var actualstates = await _context.ActualStates.FindAsync(id);
                    _context.ActualStates.Remove(actualstates);
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }

            await _context.SaveChangesAsync();
            return Ok();
        }

        private bool ActualStateExists(int id)
        {
            return _context.ActualStates.Any(e => e.Id == id);
        }
    }
}
