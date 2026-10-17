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
    public class StockTransfersController : Controller
    {
        private readonly DBContext _context;

        public StockTransfersController(DBContext context)
        {
            _context = context;
        }

        // GET: StockTransfers
        public async Task<IActionResult> Index()
        {
            var dBContext = _context.StockTransfers.Include(s => s.FromLocation).Include(s => s.ToLocation).Include(s => s.User);
            return View(await dBContext.ToListAsync());
        }

        // GET: StockTransfers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stockTransfer = await _context.StockTransfers
                .Include(s => s.FromLocation)
                .Include(s => s.ToLocation)
                .Include(s => s.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (stockTransfer == null)
            {
                return NotFound();
            }

            return View(stockTransfer);
        }

        // GET: StockTransfers/Create
        public IActionResult Create()
        {
            ViewData["FromLocationId"] = new SelectList(_context.StorageLocations, "Id", "Name");
            ViewData["ToLocationId"] = new SelectList(_context.StorageLocations, "Id", "Name");
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Username");
            return View();
        }

        // POST: StockTransfers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FromLocationId,ToLocationId,UserId,Date,IsActive,IsDelete")] StockTransfer stockTransfer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(stockTransfer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FromLocationId"] = new SelectList(_context.StorageLocations, "Id", "Name", stockTransfer.FromLocationId);
            ViewData["ToLocationId"] = new SelectList(_context.StorageLocations, "Id", "Name", stockTransfer.ToLocationId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Username", stockTransfer.UserId);
            return View(stockTransfer);
        }

        // GET: StockTransfers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stockTransfer = await _context.StockTransfers.FindAsync(id);
            if (stockTransfer == null)
            {
                return NotFound();
            }
            ViewData["FromLocationId"] = new SelectList(_context.StorageLocations, "Id", "Name", stockTransfer.FromLocationId);
            ViewData["ToLocationId"] = new SelectList(_context.StorageLocations, "Id", "Name", stockTransfer.ToLocationId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Username", stockTransfer.UserId);
            return View(stockTransfer);
        }

        // POST: StockTransfers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FromLocationId,ToLocationId,UserId,Date,IsActive,IsDelete")] StockTransfer stockTransfer)
        {
            if (id != stockTransfer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(stockTransfer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StockTransferExists(stockTransfer.Id))
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
            ViewData["FromLocationId"] = new SelectList(_context.StorageLocations, "Id", "Name", stockTransfer.FromLocationId);
            ViewData["ToLocationId"] = new SelectList(_context.StorageLocations, "Id", "Name", stockTransfer.ToLocationId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Username", stockTransfer.UserId);
            return View(stockTransfer);
        }

        // GET: StockTransfers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stockTransfer = await _context.StockTransfers
                .Include(s => s.FromLocation)
                .Include(s => s.ToLocation)
                .Include(s => s.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (stockTransfer == null)
            {
                return NotFound();
            }

            return View(stockTransfer);
        }

        // POST: StockTransfers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var stockTransfer = await _context.StockTransfers.FindAsync(id);
            if (stockTransfer != null)
            {
                _context.StockTransfers.Remove(stockTransfer);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StockTransferExists(int id)
        {
            return _context.StockTransfers.Any(e => e.Id == id);
        }
    }
}
