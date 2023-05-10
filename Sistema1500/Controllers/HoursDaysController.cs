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
    public class HoursDaysController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HoursDaysController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: HoursDays
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.HoursDays
                .Include(h => h.ActualStates);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: HoursDays/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hoursDay = await _context.HoursDays
                .Include(h => h.ActualStates)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hoursDay == null)
            {
                return NotFound();
            }

            return View(hoursDay);
        }

        // GET: HoursDays/Create
        public IActionResult Create()
        {
            ViewData["ActualStateId"] = new SelectList(_context.ActualStates, "Id", "Description");
            return View();
        }

        // POST: HoursDays/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ActualStateId,Date,RealTime,Delivered")] HoursDay hoursDay)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hoursDay);
                await _context.SaveChangesAsync();

                var actualState = await _context.ActualStates
                    .Where(x => x.Id == hoursDay.ActualStateId)
                    .Include(x => x.Project)
                    .Include(x => x.TypeConsultor)
                    .Include(x => x.HoursDay)
                    .FirstOrDefaultAsync();

                actualState.AttCalculos();

                _context.Update(actualState);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ActualStateId"] = new SelectList(_context.ActualStates, "Id", "Description", hoursDay.ActualStateId);
            return View(hoursDay);
        }

        // GET: HoursDays/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hoursDay = await _context.HoursDays.FindAsync(id);
            if (hoursDay == null)
            {
                return NotFound();
            }
            ViewData["ActualStateId"] = new SelectList(_context.ActualStates, "Id", "Description", hoursDay.ActualStateId);
            return View(hoursDay);
        }

        // POST: HoursDays/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ActualStateId,Date,RealTime,Delivered")] HoursDay hoursDay)
        {
            if (id != hoursDay.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var oldHourDay = await _context.HoursDays //Pega registros antigos
                        .AsNoTracking() //Converte em variável hoursDay fixa
                        .Where(x => x.Id == id)
                        .FirstOrDefaultAsync();

                    _context.Update(hoursDay); // Salva na banco de dados
                    await _context.SaveChangesAsync();

                    var actualState = await _context.ActualStates
                        .Where(x => x.Id == hoursDay.ActualStateId)
                        .Include(x => x.Project)
                        .Include(x => x.TypeConsultor)
                        .Include(x => x.HoursDay)
                        .FirstOrDefaultAsync();

                    actualState.AttCalculos();

                    _context.Update(actualState);
                    await _context.SaveChangesAsync();

                    actualState = await _context.ActualStates // A partir daqui verifica o novo projeto 
                        .Where(x => x.Id == hoursDay.ActualStateId)
                        .Include(x => x.Project)
                        .Include(x => x.TypeConsultor)
                        .Include(x => x.HoursDay)
                        .FirstOrDefaultAsync();

                    actualState.AttCalculos();

                    _context.Update(actualState);
                    await _context.SaveChangesAsync();

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HoursDayExists(hoursDay.Id))
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
            ViewData["ActualStateId"] = new SelectList(_context.ActualStates, "Id", "Description", hoursDay.ActualStateId);
            return View(hoursDay);
        }

        // GET: HoursDays/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hoursDay = await _context.HoursDays
                .Include(h => h.ActualStates)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hoursDay == null)
            {
                return NotFound();
            }

            return View(hoursDay);
        }

        // POST: HoursDays/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hoursDay = await _context.HoursDays.FindAsync(id);
            _context.HoursDays.Remove(hoursDay);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // POST: HoursDays/Delete/5 //Continuação Lógica do SCRIPT em index HoursDays
        [HttpPost, ActionName("MultipleDelete")]
        public async Task<IActionResult> MultipleDeleteConfirmed(List<int> ids)
        {
            try
            {
                foreach (int id in ids)
                {
                    var hoursDays = await _context.HoursDays.FindAsync(id);
                    _context.HoursDays.Remove(hoursDays);
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }

            await _context.SaveChangesAsync();
            return Ok();
        }

        private bool HoursDayExists(int id)
        {
            return _context.HoursDays.Any(e => e.Id == id);
        }
    }
}