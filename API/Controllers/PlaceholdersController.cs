using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Models;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaceholdersController : ControllerBase
    {
        private readonly PlaceholderContext _context;

        public PlaceholdersController(PlaceholderContext context)
        {
            _context = context;
        }

        // GET: api/Placeholders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Placeholder>>> GetPlaceholder()
        {
            return await _context.Placeholder.ToListAsync();
        }

        // GET: api/Placeholders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Placeholder>> GetPlaceholder(int id)
        {
            var placeholder = await _context.Placeholder.FindAsync(id);

            if (placeholder == null)
            {
                return NotFound();
            }

            return placeholder;
        }

        // PUT: api/Placeholders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlaceholder(int id, Placeholder placeholder)
        {
            if (id != placeholder.Id)
            {
                return BadRequest();
            }

            _context.Entry(placeholder).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlaceholderExists(id))
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

        // POST: api/Placeholders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Placeholder>> PostPlaceholder(Placeholder placeholder)
        {
            _context.Placeholder.Add(placeholder);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPlaceholder", new { id = placeholder.Id }, placeholder);
        }

        // DELETE: api/Placeholders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlaceholder(int id)
        {
            var placeholder = await _context.Placeholder.FindAsync(id);
            if (placeholder == null)
            {
                return NotFound();
            }

            _context.Placeholder.Remove(placeholder);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PlaceholderExists(int id)
        {
            return _context.Placeholder.Any(e => e.Id == id);
        }
    }
}
