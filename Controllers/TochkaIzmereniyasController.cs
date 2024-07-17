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
    [Tags("Точка Измерения")]
    [Route("api/[controller]")]
    [ApiController]
    public class TochkaIzmereniyasController : ControllerBase
    {
        private readonly TNDbContext _context;

        public TochkaIzmereniyasController(TNDbContext context)
        {
            _context = context;
        }

        // GET: api/TochkaIzmereniyas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TochkaIzmereniya>>> GetTochkaIzmereniyas()
        {
            return await _context.TochkaIzmereniyas.ToListAsync();
        }

        // GET: api/TochkaIzmereniyas/5
        [HttpGet("{id}", Name = "Получить все")]
        private async Task<ActionResult<TochkaIzmereniya>> GetTochkaIzmereniya(int id)
        {
            var tochkaIzmereniya = await _context.TochkaIzmereniyas.FindAsync(id);

            if (tochkaIzmereniya == null)
            {
                return NotFound();
            }

            return tochkaIzmereniya;
        }

        // PUT: api/TochkaIzmereniyas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        private async Task<IActionResult> PutTochkaIzmereniya(int id, TochkaIzmereniya tochkaIzmereniya)
        {
            if (id != tochkaIzmereniya.TochkaIzmereniyaId)
            {
                return BadRequest();
            }

            _context.Entry(tochkaIzmereniya).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TochkaIzmereniyaExists(id))
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

        // POST: api/TochkaIzmereniyas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TochkaIzmereniya>> PostTochkaIzmereniya(TochkaIzmereniya tochkaIzmereniya)
        {
            _context.TochkaIzmereniyas.Add(tochkaIzmereniya);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TochkaIzmereniyaExists(tochkaIzmereniya.TochkaIzmereniyaId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTochkaIzmereniya", new { id = tochkaIzmereniya.TochkaIzmereniyaId }, tochkaIzmereniya);
        }

        // DELETE: api/TochkaIzmereniyas/5
        [HttpDelete("{id}")]
        private async Task<IActionResult> DeleteTochkaIzmereniya(int id)
        {
            var tochkaIzmereniya = await _context.TochkaIzmereniyas.FindAsync(id);
            if (tochkaIzmereniya == null)
            {
                return NotFound();
            }

            _context.TochkaIzmereniyas.Remove(tochkaIzmereniya);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TochkaIzmereniyaExists(int id)
        {
            return _context.TochkaIzmereniyas.Any(e => e.TochkaIzmereniyaId == id);
        }
    }
}
