using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sistema1500.Data;
using Sistema1500.Models;

namespace Sistema1500.Controllers
{
    public class CostCentersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CostCentersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CostCenters
        public async Task<IActionResult> Index()
        {
            return View(await _context.CostCenter.ToListAsync());
        }

        // GET: CostCenters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var costCenter = await _context.CostCenter
                .FirstOrDefaultAsync(m => m.Id == id);
            if (costCenter == null)
            {
                return NotFound();
            }

            return View(costCenter);
        }

        // GET: CostCenters/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CostCenters/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] CostCenter costCenter)
        {
            if (ModelState.IsValid)
            {
                _context.Add(costCenter);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(costCenter);
        }

        // GET: CostCenters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var costCenter = await _context.CostCenter.FindAsync(id);
            if (costCenter == null)
            {
                return NotFound();
            }
            return View(costCenter);
        }

        // POST: CostCenters/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] CostCenter costCenter)
        {
            if (id != costCenter.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(costCenter);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CostCenterExists(costCenter.Id))
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
            return View(costCenter);
        }

        // GET: CostCenters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var costCenter = await _context.CostCenter
                .FirstOrDefaultAsync(m => m.Id == id);
            if (costCenter == null)
            {
                return NotFound();
            }

            return View(costCenter);
        }

        // POST: CostCenters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var costCenter = await _context.CostCenter.FindAsync(id);
            _context.CostCenter.Remove(costCenter);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // POST: CostCenters/Delete/5 //Continuação Lógica do SCRIPT em index CostCenters
        [HttpPost, ActionName("MultipleDelete")]
        public async Task<IActionResult> MultipleDeleteConfirmed(List<int> ids)
        {
            try
            {
                foreach (int id in ids)
                {
                    var costCenters = await _context.CostCenter.FindAsync(id);
                    _context.CostCenter.Remove(costCenters);
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }

            await _context.SaveChangesAsync();
            return Ok();
        }

        private bool CostCenterExists(int id)
        {
            return _context.CostCenter.Any(e => e.Id == id);
        }
    }
}
