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
    public class PutnikController : ControllerBase
    {
        private readonly PutniNalogDbContext _context;

        public PutnikController(PutniNalogDbContext context)
        {
            _context = context;
        }

        // GET: api/Putnik
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Putnik>>> GetPutnici()
        {
            return await _context.Putnici.ToListAsync();
        }
        [Route("api/Putnik/PutnikoviNalozi")]
        // GET: api/Putnik/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Putnik>> GetPutnik(int id)
        {
            var putnik = await _context.Putnici.Include(n => n.PutniNalozi).FirstOrDefaultAsync(p => p.PutnikId == id);

            if (putnik == null)
            {
                return NotFound();
            }

            return putnik;
        }

        // PUT: api/Putnik/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPutnik(int id, Putnik putnik)
        {
            if (id != putnik.PutnikId)
            {
                return BadRequest();
            }

            _context.Entry(putnik).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PutnikExists(id))
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

        // POST: api/Putnik
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Putnik>> PostPutnik(Putnik putnik)
        {
            _context.Putnici.Add(putnik);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPutnik", new { id = putnik.PutnikId }, putnik);
        }

        // DELETE: api/Putnik/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePutnik(int id)
        {
            var putnik = await _context.Putnici.FindAsync(id);
            if (putnik == null)
            {
                return NotFound();
            }

            _context.Putnici.Remove(putnik);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PutnikExists(int id)
        {
            return _context.Putnici.Any(e => e.PutnikId == id);
        }
    }
}
