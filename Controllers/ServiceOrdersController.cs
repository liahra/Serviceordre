using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Serviceordre.Data;
using Serviceordre.Models;

namespace Serviceordre.Controllers
{
    public class ServiceOrdersController : Controller
    {
        private readonly ServiceordreContext _context;

        public ServiceOrdersController(ServiceordreContext context)
        {
            _context = context;
        }

        // GET: ServiceOrders
        public async Task<IActionResult> Index()
        {
              return _context.ServiceOrder != null ? 
                          View(await _context.ServiceOrder.ToListAsync()) :
                          Problem("Entity set 'ServiceordreContext.ServiceOrder'  is null.");
        }

        // GET: ServiceOrders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ServiceOrder == null)
            {
                return NotFound();
            }

            var serviceOrder = await _context.ServiceOrder
                .FirstOrDefaultAsync(m => m.ServiceOrderID == id);
            if (serviceOrder == null)
            {
                return NotFound();
            }

            return View(serviceOrder);
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
        public async Task<IActionResult> Create([Bind("ServiceOrderID,OrderNum,OrderDate,CustomerName")] ServiceOrder serviceOrder)
        {
            if (ModelState.IsValid)
            {
                _context.Add(serviceOrder);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(serviceOrder);
        }

        // GET: ServiceOrders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ServiceOrder == null)
            {
                return NotFound();
            }

            var serviceOrder = await _context.ServiceOrder.FindAsync(id);
            if (serviceOrder == null)
            {
                return NotFound();
            }
            return View(serviceOrder);
        }

        // POST: ServiceOrders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ServiceOrderID,OrderNum,OrderDate,CustomerName")] ServiceOrder serviceOrder)
        {
            if (id != serviceOrder.ServiceOrderID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(serviceOrder);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServiceOrderExists(serviceOrder.ServiceOrderID))
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
            return View(serviceOrder);
        }

        // GET: ServiceOrders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ServiceOrder == null)
            {
                return NotFound();
            }

            var serviceOrder = await _context.ServiceOrder
                .FirstOrDefaultAsync(m => m.ServiceOrderID == id);
            if (serviceOrder == null)
            {
                return NotFound();
            }

            return View(serviceOrder);
        }

        // POST: ServiceOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ServiceOrder == null)
            {
                return Problem("Entity set 'ServiceordreContext.ServiceOrder'  is null.");
            }
            var serviceOrder = await _context.ServiceOrder.FindAsync(id);
            if (serviceOrder != null)
            {
                _context.ServiceOrder.Remove(serviceOrder);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ServiceOrderExists(int id)
        {
          return (_context.ServiceOrder?.Any(e => e.ServiceOrderID == id)).GetValueOrDefault();
        }
    }
}
