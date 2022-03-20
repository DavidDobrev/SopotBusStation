using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sopot_BusStation.Data;

namespace Sopot_BusStation.Controllers
{
    public class UserTicketBuysController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserTicketBuysController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: UserTicketBuys
        public async Task<IActionResult> Index()
        {
            return View(await _context.userTicketBuys.ToListAsync());
        }

        // GET: UserTicketBuys/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userTicketBuy = await _context.userTicketBuys
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userTicketBuy == null)
            {
                return NotFound();
            }

            return View(userTicketBuy);
        }

        // GET: UserTicketBuys/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserTicketBuys/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Price,Amount,Type,Discription")] UserTicketBuy userTicketBuy)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userTicketBuy);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(userTicketBuy);
        }

        // GET: UserTicketBuys/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userTicketBuy = await _context.userTicketBuys.FindAsync(id);
            if (userTicketBuy == null)
            {
                return NotFound();
            }
            return View(userTicketBuy);
        }

        // POST: UserTicketBuys/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Price,Amount,Type,Discription")] UserTicketBuy userTicketBuy)
        {
            if (id != userTicketBuy.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userTicketBuy);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserTicketBuyExists(userTicketBuy.Id))
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
            return View(userTicketBuy);
        }

        // GET: UserTicketBuys/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userTicketBuy = await _context.userTicketBuys
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userTicketBuy == null)
            {
                return NotFound();
            }

            return View(userTicketBuy);
        }

        // POST: UserTicketBuys/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userTicketBuy = await _context.userTicketBuys.FindAsync(id);
            _context.userTicketBuys.Remove(userTicketBuy);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserTicketBuyExists(int id)
        {
            return _context.userTicketBuys.Any(e => e.Id == id);
        }
    }
}
