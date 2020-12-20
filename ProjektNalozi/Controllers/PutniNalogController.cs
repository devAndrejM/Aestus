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
    public class PutniNalogController : ControllerBase
    {
        private readonly PutniNalogDbContext _context;

        public PutniNalogController(PutniNalogDbContext context)
        {
            _context = context;
        }

        // GET: api/PutniNalog
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PutniNalog>>> GetPutniNalozi()
        {
            return await _context.PutniNalozi.ToListAsync();
        }

        // GET: api/PutniNalog/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PutniNalog>> GetPutniNalog(int id)
        {

            var putniNalog = await _context.PutniNalozi.FindAsync(id);

            if (putniNalog == null)
            {
                return NotFound();
            }

            return putniNalog;
        }

        // PUT: api/PutniNalog/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPutniNalog(int id, PutniNalog putniNalog)
        {
            if (id != putniNalog.PutniNalogId)
            {
                return BadRequest();
            }

            _context.Entry(putniNalog).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PutniNalogExists(id))
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

        // POST: api/PutniNalog
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PutniNalog>> PostPutniNalog(PutniNalog putniNalog)
        {
            _context.PutniNalozi.Add(putniNalog);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPutniNalog", new { id = putniNalog.PutniNalogId }, putniNalog);
        }

        // DELETE: api/PutniNalog/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePutniNalog(int id)
        {
            var putniNalog = await _context.PutniNalozi.FindAsync(id);
            if (putniNalog == null)
            {
                return NotFound();
            }

            _context.PutniNalozi.Remove(putniNalog);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PutniNalogExists(int id)
        {
            return _context.PutniNalozi.Any(e => e.PutniNalogId == id);
        }
    }
}
