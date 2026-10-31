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
    public class InventoryStocksController : Controller
    {
        private readonly DBContext _context;

        public InventoryStocksController(DBContext context)
        {
            _context = context;
        }

        // GET: InventoryStocks
        public async Task<IActionResult> Index()
        {
            var dBContext = _context.InventoryStocks.Include(i => i.Batch).Include(i => i.Location);
            return View(await dBContext.ToListAsync());
        }

        // GET: InventoryStocks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventoryStock = await _context.InventoryStocks
                .Include(i => i.Batch)
                .Include(i => i.Location)
                .FirstOrDefaultAsync(m => m.BatchId == id);
            if (inventoryStock == null)
            {
                return NotFound();
            }

            return View(inventoryStock);
        }

        // GET: InventoryStocks/Create
        public IActionResult Create()
        {
            ViewData["BatchId"] = new SelectList(_context.ProductBatches, "Id", "Id");
            ViewData["LocationId"] = new SelectList(_context.StorageLocations, "Id", "Id");
            return View();
        }

        // POST: InventoryStocks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BatchId,LocationId,Quantity,Updatedat,IsActive,IsDelete")] InventoryStock inventoryStock)
        {
            if (ModelState.IsValid)
            {
                _context.Add(inventoryStock);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BatchId"] = new SelectList(_context.ProductBatches, "Id", "Id", inventoryStock.BatchId);
            ViewData["LocationId"] = new SelectList(_context.StorageLocations, "Id", "Id", inventoryStock.LocationId);
            return View(inventoryStock);
        }

        // GET: InventoryStocks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventoryStock = await _context.InventoryStocks.FindAsync(id);
            if (inventoryStock == null)
            {
                return NotFound();
            }
            ViewData["BatchId"] = new SelectList(_context.ProductBatches, "Id", "Id", inventoryStock.BatchId);
            ViewData["LocationId"] = new SelectList(_context.StorageLocations, "Id", "Id", inventoryStock.LocationId);
            return View(inventoryStock);
        }

        // POST: InventoryStocks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BatchId,LocationId,Quantity,Updatedat,IsActive,IsDelete")] InventoryStock inventoryStock)
        {
            if (id != inventoryStock.BatchId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(inventoryStock);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InventoryStockExists(inventoryStock.BatchId))
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
            ViewData["BatchId"] = new SelectList(_context.ProductBatches, "Id", "Id", inventoryStock.BatchId);
            ViewData["LocationId"] = new SelectList(_context.StorageLocations, "Id", "Id", inventoryStock.LocationId);
            return View(inventoryStock);
        }

        // GET: InventoryStocks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventoryStock = await _context.InventoryStocks
                .Include(i => i.Batch)
                .Include(i => i.Location)
                .FirstOrDefaultAsync(m => m.BatchId == id);
            if (inventoryStock == null)
            {
                return NotFound();
            }

            return View(inventoryStock);
        }

        // POST: InventoryStocks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var inventoryStock = await _context.InventoryStocks.FindAsync(id);
            if (inventoryStock != null)
            {
                _context.InventoryStocks.Remove(inventoryStock);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InventoryStockExists(int id)
        {
            return _context.InventoryStocks.Any(e => e.BatchId == id);
        }
    }
}
