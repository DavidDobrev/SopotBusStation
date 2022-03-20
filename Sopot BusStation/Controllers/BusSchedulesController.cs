﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sopot_BusStation.Data;

namespace Sopot_BusStation.Controllers
{
    public class BusSchedulesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BusSchedulesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: BusSchedules
        public async Task<IActionResult> Index()
        {
            return View(await _context.busSchedules.ToListAsync());
        }

        // GET: BusSchedules/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var busSchedule = await _context.busSchedules
                .FirstOrDefaultAsync(m => m.Id == id);
            if (busSchedule == null)
            {
                return NotFound();
            }

            return View(busSchedule);
        }

        // GET: BusSchedules/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BusSchedules/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Road,Price,dateTime")] BusSchedule busSchedule)
        {
            if (ModelState.IsValid)
            {
                _context.Add(busSchedule);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(busSchedule);
        }

        // GET: BusSchedules/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var busSchedule = await _context.busSchedules.FindAsync(id);
            if (busSchedule == null)
            {
                return NotFound();
            }
            return View(busSchedule);
        }

        // POST: BusSchedules/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Road,Price,dateTime")] BusSchedule busSchedule)
        {
            if (id != busSchedule.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(busSchedule);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BusScheduleExists(busSchedule.Id))
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
            return View(busSchedule);
        }

        // GET: BusSchedules/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var busSchedule = await _context.busSchedules
                .FirstOrDefaultAsync(m => m.Id == id);
            if (busSchedule == null)
            {
                return NotFound();
            }

            return View(busSchedule);
        }

        // POST: BusSchedules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var busSchedule = await _context.busSchedules.FindAsync(id);
            _context.busSchedules.Remove(busSchedule);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BusScheduleExists(int id)
        {
            return _context.busSchedules.Any(e => e.Id == id);
        }
    }
}
