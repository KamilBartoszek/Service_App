using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ServiceApp.Data;
using ServiceApp.Models;

namespace ServiceApp.Controllers
{
    public class ServiceOrdersController : Controller
    {
        private readonly ServiceAppContext _context;

        public ServiceOrdersController(ServiceAppContext context)
        {
            _context = context;
        }

        // GET: ServiceOrders
        public async Task<IActionResult> Index()
        {
              return _context.ServiceOrders != null ? 
                          View(await _context.ServiceOrders.ToListAsync()) :
                          Problem("Entity set 'ServiceAppContext.ServiceOrders'  is null.");
        }

        // GET: ServiceOrders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ServiceOrders == null)
            {
                return NotFound();
            }

            var serviceOrders = await _context.ServiceOrders
                .FirstOrDefaultAsync(m => m.Id == id);
            if (serviceOrders == null)
            {
                return NotFound();
            }

            return View(serviceOrders);
        }

        // GET: ServiceOrders/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ServiceOrders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,OrderID,OrderDate,SerialNumber,Type,Description,PowerAdapter,IsFixed")] ServiceOrders serviceOrders)
        {
            if (ModelState.IsValid)
            {
                _context.Add(serviceOrders);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(serviceOrders);
        }

        // GET: ServiceOrders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ServiceOrders == null)
            {
                return NotFound();
            }

            var serviceOrders = await _context.ServiceOrders.FindAsync(id);
            if (serviceOrders == null)
            {
                return NotFound();
            }
            return View(serviceOrders);
        }

        // POST: ServiceOrders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,OrderID,OrderDate,SerialNumber,Type,Description,PowerAdapter,IsFixed")] ServiceOrders serviceOrders)
        {
            if (id != serviceOrders.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(serviceOrders);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServiceOrdersExists(serviceOrders.Id))
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
            return View(serviceOrders);
        }

        // GET: ServiceOrders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ServiceOrders == null)
            {
                return NotFound();
            }

            var serviceOrders = await _context.ServiceOrders
                .FirstOrDefaultAsync(m => m.Id == id);
            if (serviceOrders == null)
            {
                return NotFound();
            }

            return View(serviceOrders);
        }

        // POST: ServiceOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ServiceOrders == null)
            {
                return Problem("Entity set 'ServiceAppContext.ServiceOrders'  is null.");
            }
            var serviceOrders = await _context.ServiceOrders.FindAsync(id);
            if (serviceOrders != null)
            {
                _context.ServiceOrders.Remove(serviceOrders);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ServiceOrdersExists(int id)
        {
          return (_context.ServiceOrders?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
