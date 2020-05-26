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
    public class PlayerPositionController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PlayerPositionController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/PlayerPosition
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlayerPosition>>> GetPlayerPositions()
        {
            return await _context.PlayerPositions.ToListAsync();
        }

        // GET: api/PlayerPosition/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PlayerPosition>> GetPlayerPosition(Guid id)
        {
            var playerPosition = await _context.PlayerPositions.FindAsync(id);

            if (playerPosition == null)
            {
                return NotFound();
            }

            return playerPosition;
        }

        // PUT: api/PlayerPosition/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlayerPosition(Guid id, PlayerPosition playerPosition)
        {
            if (id != playerPosition.Id)
            {
                return BadRequest();
            }

            _context.Entry(playerPosition).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlayerPositionExists(id))
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

        // POST: api/PlayerPosition
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<PlayerPosition>> PostPlayerPosition(PlayerPosition playerPosition)
        {
            _context.PlayerPositions.Add(playerPosition);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPlayerPosition", new { id = playerPosition.Id }, playerPosition);
        }

        // DELETE: api/PlayerPosition/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PlayerPosition>> DeletePlayerPosition(Guid id)
        {
            var playerPosition = await _context.PlayerPositions.FindAsync(id);
            if (playerPosition == null)
            {
                return NotFound();
            }

            _context.PlayerPositions.Remove(playerPosition);
            await _context.SaveChangesAsync();

            return playerPosition;
        }

        private bool PlayerPositionExists(Guid id)
        {
            return _context.PlayerPositions.Any(e => e.Id == id);
        }
    }
}
