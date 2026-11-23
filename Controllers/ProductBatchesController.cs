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
    public class ProductBatchesController : Controller
    {
        private readonly DBContext _context;

        public ProductBatchesController(DBContext context)
        {
            _context = context;
        }

        // GET: ProductBatches
        public async Task<IActionResult> Index()
        {
            var dBContext = _context.ProductBatches.Include(p => p.Product).Include(p => p.Purchase);
            return View(await dBContext.ToListAsync());
        }

        // GET: ProductBatches/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productBatch = await _context.ProductBatches
                .Include(p => p.Product)
                .Include(p => p.Purchase)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productBatch == null)
            {
                return NotFound();
            }

            return View(productBatch);
        }

        // GET: ProductBatches/Create
        public IActionResult Create()
        {
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Id");
            ViewData["PurchaseId"] = new SelectList(_context.Purchases, "Id", "Id");
            return View();
        }

        // POST: ProductBatches/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProductId,PurchaseId,BatchNumber,ManufacturedDate,ExpireDate,IsActive,IsDelete")] ProductBatch productBatch)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productBatch);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Id", productBatch.ProductId);
            ViewData["PurchaseId"] = new SelectList(_context.Purchases, "Id", "Id", productBatch.PurchaseId);
            return View(productBatch);
        }

        // GET: ProductBatches/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productBatch = await _context.ProductBatches.FindAsync(id);
            if (productBatch == null)
            {
                return NotFound();
            }
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Id", productBatch.ProductId);
            ViewData["PurchaseId"] = new SelectList(_context.Purchases, "Id", "Id", productBatch.PurchaseId);
            return View(productBatch);
        }

        // POST: ProductBatches/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProductId,PurchaseId,BatchNumber,ManufacturedDate,ExpireDate,IsActive,IsDelete")] ProductBatch productBatch)
        {
            if (id != productBatch.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productBatch);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductBatchExists(productBatch.Id))
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
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Id", productBatch.ProductId);
            ViewData["PurchaseId"] = new SelectList(_context.Purchases, "Id", "Id", productBatch.PurchaseId);
            return View(productBatch);
        }

        // GET: ProductBatches/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productBatch = await _context.ProductBatches
                .Include(p => p.Product)
                .Include(p => p.Purchase)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productBatch == null)
            {
                return NotFound();
            }

            return View(productBatch);
        }

        // POST: ProductBatches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productBatch = await _context.ProductBatches.FindAsync(id);
            if (productBatch != null)
            {
                _context.ProductBatches.Remove(productBatch);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductBatchExists(int id)
        {
            return _context.ProductBatches.Any(e => e.Id == id);
        }
    }
}
