using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EnergyApi.Data;
using EnergyApi.Data.Model;

namespace EnergyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ObjectPotrebleniyasController : ControllerBase
    {
        private readonly TNDbContext _context;

        public ObjectPotrebleniyasController(TNDbContext context)
        {
            _context = context;
        }

        // GET: api/ObjectPotrebleniyas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ObjectPotrebleniya>>> GetObjectPotrebleniyas()
        {
            return await _context.ObjectPotrebleniyas.ToListAsync();
        }

        // GET: api/ObjectPotrebleniyas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ObjectPotrebleniya>> GetObjectPotrebleniya(int id)
        {
            var objectPotrebleniya = await _context.ObjectPotrebleniyas.FindAsync(id);

            if (objectPotrebleniya == null)
            {
                return NotFound();
            }

            return objectPotrebleniya;
        }

        // PUT: api/ObjectPotrebleniyas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutObjectPotrebleniya(int id, ObjectPotrebleniya objectPotrebleniya)
        {
            if (id != objectPotrebleniya.ObjectPotrebleniyaId)
            {
                return BadRequest();
            }

            _context.Entry(objectPotrebleniya).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ObjectPotrebleniyaExists(id))
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

        // POST: api/ObjectPotrebleniyas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ObjectPotrebleniya>> PostObjectPotrebleniya(ObjectPotrebleniya objectPotrebleniya)
        {
            _context.ObjectPotrebleniyas.Add(objectPotrebleniya);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetObjectPotrebleniya", new { id = objectPotrebleniya.ObjectPotrebleniyaId }, objectPotrebleniya);
        }

        // DELETE: api/ObjectPotrebleniyas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteObjectPotrebleniya(int id)
        {
            var objectPotrebleniya = await _context.ObjectPotrebleniyas.FindAsync(id);
            if (objectPotrebleniya == null)
            {
                return NotFound();
            }

            _context.ObjectPotrebleniyas.Remove(objectPotrebleniya);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ObjectPotrebleniyaExists(int id)
        {
            return _context.ObjectPotrebleniyas.Any(e => e.ObjectPotrebleniyaId == id);
        }
    }
}
