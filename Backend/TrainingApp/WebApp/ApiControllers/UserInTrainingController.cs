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
    public class UserInTrainingController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UserInTrainingController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/UserInTraining
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserInTraining>>> GetUsersInTrainings()
        {
            return await _context.UsersInTrainings.ToListAsync();
        }

        // GET: api/UserInTraining/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserInTraining>> GetUserInTraining(Guid id)
        {
            var userInTraining = await _context.UsersInTrainings.FindAsync(id);

            if (userInTraining == null)
            {
                return NotFound();
            }

            return userInTraining;
        }

        // PUT: api/UserInTraining/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserInTraining(Guid id, UserInTraining userInTraining)
        {
            if (id != userInTraining.Id)
            {
                return BadRequest();
            }

            _context.Entry(userInTraining).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserInTrainingExists(id))
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

        // POST: api/UserInTraining
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<UserInTraining>> PostUserInTraining(UserInTraining userInTraining)
        {
            _context.UsersInTrainings.Add(userInTraining);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserInTraining", new { id = userInTraining.Id }, userInTraining);
        }

        // DELETE: api/UserInTraining/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserInTraining>> DeleteUserInTraining(Guid id)
        {
            var userInTraining = await _context.UsersInTrainings.FindAsync(id);
            if (userInTraining == null)
            {
                return NotFound();
            }

            _context.UsersInTrainings.Remove(userInTraining);
            await _context.SaveChangesAsync();

            return userInTraining;
        }

        private bool UserInTrainingExists(Guid id)
        {
            return _context.UsersInTrainings.Any(e => e.Id == id);
        }
    }
}
