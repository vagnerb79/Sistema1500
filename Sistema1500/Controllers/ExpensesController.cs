using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using Sistema1500.Data;
using Sistema1500.Models;

namespace Sistema1500.Controllers
{
    public class ExpensesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ExpensesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Expenses
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Expense
                .Include(e => e.BankAccount)
                .Include(e => e.Captures)
                .Include(e => e.CostCenter)
                .Include(e => e.Person);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Expenses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expense = await _context.Expense
                .Include(e => e.BankAccount)
                .Include(e => e.Captures)
                .Include(e => e.CostCenter)
                .Include(e => e.Person)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (expense == null)
            {
                return NotFound();
            }

            return View(expense);
        }

        // GET: Expenses/Create
        public IActionResult Create()
        {
            ViewData["BankAccountId"] = new SelectList(_context.BankAccount, "Id", "Name");
            ViewData["CapturesId"] = new SelectList(_context.Captures, "Id", "Name");
            ViewData["CostCenterId"] = new SelectList(_context.CostCenter, "Id", "Name");
            ViewData["PersonId"] = new SelectList(_context.People, "Id", "Name");
            return View();
        }

        // POST: Expenses/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind
            ("Id,Type,RegisterDate,CashDate,MonthDate,CompeteDate,CompeteMonthDate,CostCenterId,CapturesId,PersonId,BankAccountId,TargetBill,Description,Value,Validated,Plan,BankValueMoment,EnterpriseBankValueMoment")] Expense expense)
        {
            if (ModelState.IsValid)
            {
                _context.Add(expense);
                await _context.SaveChangesAsync();

                var bankAccounts = _context.BankAccount
                    .Where(x => x.Id == expense.BankAccountId)
                    .Include(x => x.Expenses)
                    .FirstOrDefault();

                var otherAccounts = _context.BankAccount
                            .Where(x => x.EnterpriseId == bankAccounts.EnterpriseId)
                            .Include(x => x.Expenses)
                            .ToList();

                bankAccounts.calculoBanco();
                otherAccounts.ForEach(x => x.calculoBanco());

                expense.BankValueMoment = bankAccounts.Balance;
                expense.EnterpriseBankValueMoment = otherAccounts.Sum(x => x.Balance);

                _context.Update(expense);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["BankAccountId"] = new SelectList(_context.BankAccount, "Id", "Name", expense.BankAccountId);
            ViewData["CapturesId"] = new SelectList(_context.Captures, "Id", "Name", expense.CapturesId);
            ViewData["CostCenterId"] = new SelectList(_context.CostCenter, "Id", "Name", expense.CostCenterId);
            ViewData["PersonId"] = new SelectList(_context.People, "Id", "Name", expense.PersonId);
            return View(expense);
        }

        // GET: Expenses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expense = await _context.Expense.FindAsync(id);
            if (expense == null)
            {
                return NotFound();
            }
            ViewData["BankAccountId"] = new SelectList(_context.BankAccount, "Id", "Name", expense.BankAccountId);
            ViewData["CapturesId"] = new SelectList(_context.Captures, "Id", "Name", expense.CapturesId);
            ViewData["CostCenterId"] = new SelectList(_context.CostCenter, "Id", "Name", expense.CostCenterId);
            ViewData["PersonId"] = new SelectList(_context.People, "Id", "Name", expense.PersonId);
            return View(expense);
        }

        // POST: Expenses/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind
            ("Id,Type,RegisterDate,CashDate,MonthDate,CompeteDate,CompeteMonthDate,CostCenterId,CapturesId,PersonId,BankAccountId,TargetBill,Description,Value,Validated,Plan,BankValueMoment,EnterpriseBankValueMoment")] Expense expense)
        {
            if (id != expense.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(expense);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExpenseExists(expense.Id))
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
            ViewData["BankAccountId"] = new SelectList(_context.BankAccount, "Id", "Name", expense.BankAccountId);
            ViewData["CapturesId"] = new SelectList(_context.Captures, "Id", "Name", expense.CapturesId);
            ViewData["CostCenterId"] = new SelectList(_context.CostCenter, "Id", "Name", expense.CostCenterId);
            ViewData["PersonId"] = new SelectList(_context.People, "Id", "Name", expense.PersonId);
            return View(expense);
        }

        // GET: Expenses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expense = await _context.Expense
                .Include(e => e.BankAccount)
                .Include(e => e.Captures)
                .Include(e => e.CostCenter)
                .Include(e => e.Person)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (expense == null)
            {
                return NotFound();
            }

            return View(expense);
        }

        // POST: Expenses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var expense = await _context.Expense.FindAsync(id);
            _context.Expense.Remove(expense);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // POST: Expenses/Delete/5 //Continuação Lógica do SCRIPT em index Expenses
        [HttpPost, ActionName("MultipleDelete")]
        public async Task<IActionResult> MultipleDeleteConfirmed(List<int> ids)
        {
            try
            {
                foreach (int id in ids)
                {
                    var expenses = await _context.Expense.FindAsync(id);
                    _context.Expense.Remove(expenses);
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }

            await _context.SaveChangesAsync();
            return Ok();
        }

        private bool ExpenseExists(int id)
        {
            return _context.Expense.Any(e => e.Id == id);
        }
    }
}
