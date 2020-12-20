using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjektNalozi.Models;

namespace ProjektNalozi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PutnikovNalogController : ControllerBase
    {
        private readonly PutniNalogDbContext _context;

        public PutnikovNalogController(PutniNalogDbContext context)
        {
            _context = context;
        }

        // GET: api/PutnikovNalog
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PutnikovNalog>>> GetPutnikoviNalozi()
        {
            return await _context.PutnikoviNalozi.ToListAsync();
        }

        // GET: api/PutnikovNalog/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PutnikovNalog>> GetPutnikovNalog(int id)
        {
            var putnikovNalog = await _context.PutnikoviNalozi.FindAsync(id);

            if (putnikovNalog == null)
            {
                return NotFound();
            }

            return putnikovNalog;
        }

        // PUT: api/PutnikovNalog/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPutnikovNalog(int id, PutnikovNalog putnikovNalog)
        {
            if (id != putnikovNalog.PutnikId)
            {
                return BadRequest();
            }

            _context.Entry(putnikovNalog).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PutnikovNalogExists(id))
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

        // POST: api/PutnikovNalog
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PutnikovNalog>> PostPutnikovNalog(PutnikovNalog putnikovNalog)
        {
            _context.PutnikoviNalozi.Add(putnikovNalog);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PutnikovNalogExists(putnikovNalog.PutnikId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPutnikovNalog", new { id = putnikovNalog.PutnikId }, putnikovNalog);
        }

        // DELETE: api/PutnikovNalog/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePutnikovNalog(int id)
        {
            var putnikovNalog = await _context.PutnikoviNalozi.FindAsync(id);
            if (putnikovNalog == null)
            {
                return NotFound();
            }

            _context.PutnikoviNalozi.Remove(putnikovNalog);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PutnikovNalogExists(int id)
        {
            return _context.PutnikoviNalozi.Any(e => e.PutnikId == id);
        }
    }
}
