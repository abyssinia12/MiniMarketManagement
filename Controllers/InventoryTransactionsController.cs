using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MiniMarket.Models;

namespace MiniMarket.Controllers
{
    public class InventoryTransactionsController : Controller
    {
        private readonly DBContext _context;

        public InventoryTransactionsController(DBContext context)
        {
            _context = context;
        }

        // GET: InventoryTransactions
        public async Task<IActionResult> Index()
        {
            var dBContext = _context.InventoryTransactions.Include(i => i.Batch).Include(i => i.Location).Include(i => i.User);
            return View(await dBContext.ToListAsync());
        }

        // GET: InventoryTransactions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventoryTransaction = await _context.InventoryTransactions
                .Include(i => i.Batch)
                .Include(i => i.Location)
                .Include(i => i.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (inventoryTransaction == null)
            {
                return NotFound();
            }

            return View(inventoryTransaction);
        }

        // GET: InventoryTransactions/Create
        public IActionResult Create()
        {
            ViewData["BatchId"] = new SelectList(_context.ProductBatches, "Id", "Id");
            ViewData["LocationId"] = new SelectList(_context.StorageLocations, "Id", "Id");
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: InventoryTransactions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,BatchId,LocationId,UserId,TransactionType,QuantityIn,QuantityOut,ReferenceType,ReferenceId,TransactionDate,IsActive,IsDelete")] InventoryTransaction inventoryTransaction)
        {
            if (ModelState.IsValid)
            {
                _context.Add(inventoryTransaction);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BatchId"] = new SelectList(_context.ProductBatches, "Id", "Id", inventoryTransaction.BatchId);
            ViewData["LocationId"] = new SelectList(_context.StorageLocations, "Id", "Id", inventoryTransaction.LocationId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", inventoryTransaction.UserId);
            return View(inventoryTransaction);
        }

        // GET: InventoryTransactions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventoryTransaction = await _context.InventoryTransactions.FindAsync(id);
            if (inventoryTransaction == null)
            {
                return NotFound();
            }
            ViewData["BatchId"] = new SelectList(_context.ProductBatches, "Id", "Id", inventoryTransaction.BatchId);
            ViewData["LocationId"] = new SelectList(_context.StorageLocations, "Id", "Id", inventoryTransaction.LocationId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", inventoryTransaction.UserId);
            return View(inventoryTransaction);
        }

        // POST: InventoryTransactions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,BatchId,LocationId,UserId,TransactionType,QuantityIn,QuantityOut,ReferenceType,ReferenceId,TransactionDate,IsActive,IsDelete")] InventoryTransaction inventoryTransaction)
        {
            if (id != inventoryTransaction.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(inventoryTransaction);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InventoryTransactionExists(inventoryTransaction.Id))
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
            ViewData["BatchId"] = new SelectList(_context.ProductBatches, "Id", "Id", inventoryTransaction.BatchId);
            ViewData["LocationId"] = new SelectList(_context.StorageLocations, "Id", "Id", inventoryTransaction.LocationId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", inventoryTransaction.UserId);
            return View(inventoryTransaction);
        }

        // GET: InventoryTransactions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventoryTransaction = await _context.InventoryTransactions
                .Include(i => i.Batch)
                .Include(i => i.Location)
                .Include(i => i.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (inventoryTransaction == null)
            {
                return NotFound();
            }

            return View(inventoryTransaction);
        }

        // POST: InventoryTransactions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var inventoryTransaction = await _context.InventoryTransactions.FindAsync(id);
            if (inventoryTransaction != null)
            {
                _context.InventoryTransactions.Remove(inventoryTransaction);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InventoryTransactionExists(int id)
        {
            return _context.InventoryTransactions.Any(e => e.Id == id);
        }
    }
}
