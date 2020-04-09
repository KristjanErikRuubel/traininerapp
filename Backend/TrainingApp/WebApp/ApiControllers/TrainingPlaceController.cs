using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DAL.App.EF;
using Domain;

namespace WebApp.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainingPlaceController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TrainingPlaceController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/TrainingPlace
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TrainingPlace>>> GetTrainingPlaces()
        {
            return await _context.TrainingPlaces.ToListAsync();
        }

        // GET: api/TrainingPlace/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TrainingPlace>> GetTrainingPlace(Guid id)
        {
            var trainingPlace = await _context.TrainingPlaces.FindAsync(id);

            if (trainingPlace == null)
            {
                return NotFound();
            }

            return trainingPlace;
        }

        // PUT: api/TrainingPlace/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrainingPlace(Guid id, TrainingPlace trainingPlace)
        {
            if (id != trainingPlace.Id)
            {
                return BadRequest();
            }

            _context.Entry(trainingPlace).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrainingPlaceExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/TrainingPlace
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<TrainingPlace>> PostTrainingPlace(TrainingPlace trainingPlace)
        {
            _context.TrainingPlaces.Add(trainingPlace);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTrainingPlace", new { id = trainingPlace.Id }, trainingPlace);
        }

        // DELETE: api/TrainingPlace/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TrainingPlace>> DeleteTrainingPlace(Guid id)
        {
            var trainingPlace = await _context.TrainingPlaces.FindAsync(id);
            if (trainingPlace == null)
            {
                return NotFound();
            }

            _context.TrainingPlaces.Remove(trainingPlace);
            await _context.SaveChangesAsync();

            return trainingPlace;
        }

        private bool TrainingPlaceExists(Guid id)
        {
            return _context.TrainingPlaces.Any(e => e.Id == id);
        }
    }
}
