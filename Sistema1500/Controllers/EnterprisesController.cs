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
    public class EnterprisesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EnterprisesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Enterprises
        public async Task<IActionResult> Index()
        {
            return View(await _context.Enterprise.ToListAsync());
        }

        // GET: Enterprises/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enterprise = await _context.Enterprise
                .FirstOrDefaultAsync(m => m.Id == id);
            if (enterprise == null)
            {
                return NotFound();
            }

            return View(enterprise);
        }

        // GET: Enterprises/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Enterprises/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,CNPJ,Phone,Email")] Enterprise enterprise)
        {
            if (ModelState.IsValid)
            {
                _context.Add(enterprise);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(enterprise);
        }

        // GET: Enterprises/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enterprise = await _context.Enterprise.FindAsync(id);
            if (enterprise == null)
            {
                return NotFound();
            }
            return View(enterprise);
        }

        // POST: Enterprises/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,CNPJ,Phone,Email")] Enterprise enterprise)
        {
            if (id != enterprise.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(enterprise);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EnterpriseExists(enterprise.Id))
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
            return View(enterprise);
        }

        // GET: Enterprises/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enterprise = await _context.Enterprise
                .FirstOrDefaultAsync(m => m.Id == id);
            if (enterprise == null)
            {
                return NotFound();
            }

            return View(enterprise);
        }

        // POST: Enterprises/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var enterprise = await _context.Enterprise.FindAsync(id);
            _context.Enterprise.Remove(enterprise);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // POST: Enterprises/Delete/5 //Continuação Lógica do SCRIPT em index Enterprises
        [HttpPost, ActionName("MultipleDelete")]
        public async Task<IActionResult> MultipleDeleteConfirmed(List<int> ids)
        {
            try
            {
                foreach (int id in ids)
                {
                    var enterprises = await _context.Enterprise.FindAsync(id);
                    _context.Enterprise.Remove(enterprises);
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }

            await _context.SaveChangesAsync();
            return Ok();
        }

        private bool EnterpriseExists(int id)
        {
            return _context.Enterprise.Any(e => e.Id == id);
        }
    }
}
