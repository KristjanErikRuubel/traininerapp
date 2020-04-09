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
    public class TrainingPlaceController : Controller
    {
        private readonly AppDbContext _context;

        public TrainingPlaceController(AppDbContext context)
        {
            _context = context;
        }

        // GET: TrainingPlace
        public async Task<IActionResult> Index()
        {
            return View(await _context.TrainingPlaces.ToListAsync());
        }

        // GET: TrainingPlace/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trainingPlace = await _context.TrainingPlaces
                .FirstOrDefaultAsync(m => m.Id == id);
            if (trainingPlace == null)
            {
                return NotFound();
            }

            return View(trainingPlace);
        }

        // GET: TrainingPlace/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TrainingPlace/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Address,OpeningTime,ClosingTime,Id")] TrainingPlace trainingPlace)
        {
            if (ModelState.IsValid)
            {
                trainingPlace.Id = Guid.NewGuid();
                _context.Add(trainingPlace);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(trainingPlace);
        }

        // GET: TrainingPlace/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trainingPlace = await _context.TrainingPlaces.FindAsync(id);
            if (trainingPlace == null)
            {
                return NotFound();
            }
            return View(trainingPlace);
        }

        // POST: TrainingPlace/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Name,Address,OpeningTime,ClosingTime,Id")] TrainingPlace trainingPlace)
        {
            if (id != trainingPlace.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(trainingPlace);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrainingPlaceExists(trainingPlace.Id))
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
            return View(trainingPlace);
        }

        // GET: TrainingPlace/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trainingPlace = await _context.TrainingPlaces
                .FirstOrDefaultAsync(m => m.Id == id);
            if (trainingPlace == null)
            {
                return NotFound();
            }

            return View(trainingPlace);
        }

        // POST: TrainingPlace/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var trainingPlace = await _context.TrainingPlaces.FindAsync(id);
            _context.TrainingPlaces.Remove(trainingPlace);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TrainingPlaceExists(Guid id)
        {
            return _context.TrainingPlaces.Any(e => e.Id == id);
        }
    }
}
