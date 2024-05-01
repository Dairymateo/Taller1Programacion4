using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Taller1.Data;
using Taller1.Models;

namespace Taller1.Controllers
{
    public class MotorsController : Controller
    {
        private readonly Taller1Context _context;

        public MotorsController(Taller1Context context)
        {
            _context = context;
        }

        // GET: Motors
        public async Task<IActionResult> Index()
        {
            var taller1Context = _context.Motor.Include(m => m.Auto);
            return View(await taller1Context.ToListAsync());
        }

        // GET: Motors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var motor = await _context.Motor
                .Include(m => m.Auto)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (motor == null)
            {
                return NotFound();
            }

            return View(motor);
        }

        // GET: Motors/Create
        public IActionResult Create()
        {
            ViewData["AutoId"] = new SelectList(_context.Auto, "Id", "Id");
            return View();
        }

        // POST: Motors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TipoMotor,caballos,anio,AutoId")] Motor motor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(motor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AutoId"] = new SelectList(_context.Auto, "Id", "Id", motor.AutoId);
            return View(motor);
        }

        // GET: Motors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var motor = await _context.Motor.FindAsync(id);
            if (motor == null)
            {
                return NotFound();
            }
            ViewData["AutoId"] = new SelectList(_context.Auto, "Id", "Id", motor.AutoId);
            return View(motor);
        }

        // POST: Motors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TipoMotor,caballos,anio,AutoId")] Motor motor)
        {
            if (id != motor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(motor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MotorExists(motor.Id))
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
            ViewData["AutoId"] = new SelectList(_context.Auto, "Id", "Id", motor.AutoId);
            return View(motor);
        }

        // GET: Motors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var motor = await _context.Motor
                .Include(m => m.Auto)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (motor == null)
            {
                return NotFound();
            }

            return View(motor);
        }

        // POST: Motors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var motor = await _context.Motor.FindAsync(id);
            if (motor != null)
            {
                _context.Motor.Remove(motor);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MotorExists(int id)
        {
            return _context.Motor.Any(e => e.Id == id);
        }
    }
}
