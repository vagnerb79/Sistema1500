﻿using System;
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
    public class BankAccountsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BankAccountsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: BankAccounts
        public async Task<IActionResult> Index()
        {

            var applicationDbContext = await _context.BankAccount
                .Include(b => b.Enterprise)
                .Include(b => b.Expenses)
                .ToListAsync();

            applicationDbContext.ForEach(c => c.calculoBanco());

            return View(applicationDbContext);
        }


        // GET: BankAccounts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bankAccount = await _context.BankAccount
                .Include(b => b.Enterprise)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bankAccount == null)
            {
                return NotFound();
            }

            return View(bankAccount);
        }

        // GET: BankAccounts/Create
        public IActionResult Create()
        {
            ViewData["EnterpriseId"] = new SelectList(_context.Enterprise, "Id", "Name");
            return View();
        }

        // POST: BankAccounts/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind
            ("Id,Name,EnterpriseId,Balance,InitialBalance")] BankAccount bankAccount)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bankAccount);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EnterpriseId"] = new SelectList(_context.Enterprise, "Id", "Name", bankAccount.EnterpriseId);
            return View(bankAccount);
        }

        // GET: BankAccounts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bankAccount = await _context.BankAccount.FindAsync(id);
            if (bankAccount == null)
            {
                return NotFound();
            }
            ViewData["EnterpriseId"] = new SelectList(_context.Enterprise, "Id", "Name", bankAccount.EnterpriseId);
            return View(bankAccount);
        }

        // POST: BankAccounts/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind
            ("Id,Name,EnterpriseId,Balance,InitialBalance")] BankAccount bankAccount)
        {
            if (id != bankAccount.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bankAccount);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BankAccountExists(bankAccount.Id))
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
            ViewData["EnterpriseId"] = new SelectList(_context.Enterprise, "Id", "Name", bankAccount.EnterpriseId);
            return View(bankAccount);
        }

        // GET: BankAccounts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bankAccount = await _context.BankAccount
                .Include(b => b.Enterprise)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bankAccount == null)
            {
                return NotFound();
            }

            return View(bankAccount);
        }

        // POST: BankAccounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bankAccount = await _context.BankAccount.FindAsync(id);
            _context.BankAccount.Remove(bankAccount);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        // POST: BankAccounts/Delete/5 //Continuação Lógica do SCRIPT em index BanckAccounts
        [HttpPost, ActionName("MultipleDelete")]
        public async Task<IActionResult> MultipleDeleteConfirmed(List<int> ids)
        {
            try
            {
                foreach (int id in ids)
                {
                    var banckAccount = await _context.BankAccount.FindAsync(id);
                    _context.BankAccount.Remove(banckAccount);
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }

            await _context.SaveChangesAsync();
            return Ok();
        }

        private bool BankAccountExists(int id)
        {
            return _context.BankAccount.Any(e => e.Id == id);
        }
    }
}
