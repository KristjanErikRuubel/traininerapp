using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL.App.EF;
using Domain;

namespace WebApp.Controllers
{
    public class PlayerPositionController : Controller
    {
        private readonly AppDbContext _context;

        public PlayerPositionController(AppDbContext context)
        {
            _context = context;
        }

        // GET: PlayerPosition
        public async Task<IActionResult> Index()
        {
            return View(await _context.PlayerPositions.ToListAsync());
        }

        // GET: PlayerPosition/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var playerPosition = await _context.PlayerPositions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (playerPosition == null)
            {
                return NotFound();
            }

            return View(playerPosition);
        }

        // GET: PlayerPosition/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PlayerPosition/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PersonPosition,Id")] PlayerPosition playerPosition)
        {
            if (ModelState.IsValid)
            {
                playerPosition.Id = Guid.NewGuid();
                _context.Add(playerPosition);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(playerPosition);
        }

        // GET: PlayerPosition/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var playerPosition = await _context.PlayerPositions.FindAsync(id);
            if (playerPosition == null)
            {
                return NotFound();
            }
            return View(playerPosition);
        }

        // POST: PlayerPosition/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("PersonPosition,Id")] PlayerPosition playerPosition)
        {
            if (id != playerPosition.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(playerPosition);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlayerPositionExists(playerPosition.Id))
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
            return View(playerPosition);
        }

        // GET: PlayerPosition/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var playerPosition = await _context.PlayerPositions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (playerPosition == null)
            {
                return NotFound();
            }

            return View(playerPosition);
        }

        // POST: PlayerPosition/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var playerPosition = await _context.PlayerPositions.FindAsync(id);
            _context.PlayerPositions.Remove(playerPosition);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlayerPositionExists(Guid id)
        {
            return _context.PlayerPositions.Any(e => e.Id == id);
        }
    }
}
