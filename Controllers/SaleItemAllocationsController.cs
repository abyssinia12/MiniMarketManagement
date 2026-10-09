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
    public class SaleItemAllocationsController : Controller
    {
        private readonly DBContext _context;

        public SaleItemAllocationsController(DBContext context)
        {
            _context = context;
        }

        // GET: SaleItemAllocations
        public async Task<IActionResult> Index()
        {
            var dBContext = _context.SaleItemAllocations.Include(s => s.Batch).Include(s => s.Location).Include(s => s.Sale);
            return View(await dBContext.ToListAsync());
        }

        // GET: SaleItemAllocations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var saleItemAllocation = await _context.SaleItemAllocations
                .Include(s => s.Batch)
                .Include(s => s.Location)
                .Include(s => s.Sale)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (saleItemAllocation == null)
            {
                return NotFound();
            }

            return View(saleItemAllocation);
        }

        // GET: SaleItemAllocations/Create
        public IActionResult Create()
        {
            ViewData["BatchId"] = new SelectList(_context.ProductBatches, "Id", "Id");
            ViewData["LocationId"] = new SelectList(_context.StorageLocations, "Id", "Id");
            ViewData["SaleId"] = new SelectList(_context.Sales, "Id", "Id");
            return View();
        }

        // POST: SaleItemAllocations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SaleId,BatchId,LocationId,Quantity,IsActive,IsDelete")] SaleItemAllocation saleItemAllocation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(saleItemAllocation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BatchId"] = new SelectList(_context.ProductBatches, "Id", "Id", saleItemAllocation.BatchId);
            ViewData["LocationId"] = new SelectList(_context.StorageLocations, "Id", "Id", saleItemAllocation.LocationId);
            ViewData["SaleId"] = new SelectList(_context.Sales, "Id", "Id", saleItemAllocation.SaleId);
            return View(saleItemAllocation);
        }

        // GET: SaleItemAllocations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var saleItemAllocation = await _context.SaleItemAllocations.FindAsync(id);
            if (saleItemAllocation == null)
            {
                return NotFound();
            }
            ViewData["BatchId"] = new SelectList(_context.ProductBatches, "Id", "Id", saleItemAllocation.BatchId);
            ViewData["LocationId"] = new SelectList(_context.StorageLocations, "Id", "Id", saleItemAllocation.LocationId);
            ViewData["SaleId"] = new SelectList(_context.Sales, "Id", "Id", saleItemAllocation.SaleId);
            return View(saleItemAllocation);
        }

        // POST: SaleItemAllocations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SaleId,BatchId,LocationId,Quantity,IsActive,IsDelete")] SaleItemAllocation saleItemAllocation)
        {
            if (id != saleItemAllocation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(saleItemAllocation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SaleItemAllocationExists(saleItemAllocation.Id))
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
            ViewData["BatchId"] = new SelectList(_context.ProductBatches, "Id", "Id", saleItemAllocation.BatchId);
            ViewData["LocationId"] = new SelectList(_context.StorageLocations, "Id", "Id", saleItemAllocation.LocationId);
            ViewData["SaleId"] = new SelectList(_context.Sales, "Id", "Id", saleItemAllocation.SaleId);
            return View(saleItemAllocation);
        }

        // GET: SaleItemAllocations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var saleItemAllocation = await _context.SaleItemAllocations
                .Include(s => s.Batch)
                .Include(s => s.Location)
                .Include(s => s.Sale)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (saleItemAllocation == null)
            {
                return NotFound();
            }

            return View(saleItemAllocation);
        }

        // POST: SaleItemAllocations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var saleItemAllocation = await _context.SaleItemAllocations.FindAsync(id);
            if (saleItemAllocation != null)
            {
                _context.SaleItemAllocations.Remove(saleItemAllocation);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SaleItemAllocationExists(int id)
        {
            return _context.SaleItemAllocations.Any(e => e.Id == id);
        }
    }
}
