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
    public class StockTransferItemsController : Controller
    {
        private readonly DBContext _context;

        public StockTransferItemsController(DBContext context)
        {
            _context = context;
        }

        // GET: StockTransferItems
        public async Task<IActionResult> Index()
        {
            var dBContext = _context.StockTransferItems.Include(s => s.Batch).Include(s => s.Transfer);
            return View(await dBContext.ToListAsync());
        }

        // GET: StockTransferItems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stockTransferItem = await _context.StockTransferItems
                .Include(s => s.Batch)
                .Include(s => s.Transfer)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (stockTransferItem == null)
            {
                return NotFound();
            }

            return View(stockTransferItem);
        }

        // GET: StockTransferItems/Create
        public IActionResult Create()
        {
            ViewData["BatchId"] = new SelectList(_context.ProductBatches, "Id", "Id");
            ViewData["TransferId"] = new SelectList(_context.StockTransfers, "Id", "Id");
            return View();
        }

        // POST: StockTransferItems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TransferId,BatchId,Quantity,IsActive,IsDelete")] StockTransferItem stockTransferItem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(stockTransferItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BatchId"] = new SelectList(_context.ProductBatches, "Id", "Id", stockTransferItem.BatchId);
            ViewData["TransferId"] = new SelectList(_context.StockTransfers, "Id", "Id", stockTransferItem.TransferId);
            return View(stockTransferItem);
        }

        // GET: StockTransferItems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stockTransferItem = await _context.StockTransferItems.FindAsync(id);
            if (stockTransferItem == null)
            {
                return NotFound();
            }
            ViewData["BatchId"] = new SelectList(_context.ProductBatches, "Id", "Id", stockTransferItem.BatchId);
            ViewData["TransferId"] = new SelectList(_context.StockTransfers, "Id", "Id", stockTransferItem.TransferId);
            return View(stockTransferItem);
        }

        // POST: StockTransferItems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TransferId,BatchId,Quantity,IsActive,IsDelete")] StockTransferItem stockTransferItem)
        {
            if (id != stockTransferItem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(stockTransferItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StockTransferItemExists(stockTransferItem.Id))
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
            ViewData["BatchId"] = new SelectList(_context.ProductBatches, "Id", "Id", stockTransferItem.BatchId);
            ViewData["TransferId"] = new SelectList(_context.StockTransfers, "Id", "Id", stockTransferItem.TransferId);
            return View(stockTransferItem);
        }

        // GET: StockTransferItems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stockTransferItem = await _context.StockTransferItems
                .Include(s => s.Batch)
                .Include(s => s.Transfer)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (stockTransferItem == null)
            {
                return NotFound();
            }

            return View(stockTransferItem);
        }

        // POST: StockTransferItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var stockTransferItem = await _context.StockTransferItems.FindAsync(id);
            if (stockTransferItem != null)
            {
                _context.StockTransferItems.Remove(stockTransferItem);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StockTransferItemExists(int id)
        {
            return _context.StockTransferItems.Any(e => e.Id == id);
        }
    }
}
