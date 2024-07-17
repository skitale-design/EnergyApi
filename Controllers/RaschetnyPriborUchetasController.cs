using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EnergyApi.Data;
using EnergyApi.Data.Model;
using System.ComponentModel.DataAnnotations;

namespace EnergyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RaschetnyPriborUchetasController : ControllerBase
    {
        private readonly TNDbContext _context;

        public RaschetnyPriborUchetasController(TNDbContext context)
        {
            _context = context;
        }

        // GET: api/RaschetnyPriborUchetas
        [HttpGet]
        private async Task<ActionResult<IEnumerable<RaschetnyPriborUcheta>>> GetRaschetnyPriborUchetas()
        {
            return await _context.RaschetnyPriborUchetas.ToListAsync();
        }

        // GET: api/RaschetnyPriborUchetas/5
        [HttpGet("{id}")]
        private async Task<ActionResult<RaschetnyPriborUcheta>> GetRaschetnyPriborUcheta(int id)
        {
            var raschetnyPriborUcheta = await _context.RaschetnyPriborUchetas.FindAsync(id);

            if (raschetnyPriborUcheta == null)
            {
                return NotFound();
            }

            return raschetnyPriborUcheta;
        }

        [HttpGet("{year:int}")] // TODO: как добавь валидацию на формат "YYYY"
        public async Task<ActionResult<List<RaschetnyPriborUcheta>>> GetRaschetnyPriborUchetaByYear(int year)
        {
            var raschetnyPriborUcheta = await _context.RaschetnyPriborUchetas.Where(x => x.SDate.Year <= year && x.EDate.Year >= year).ToListAsync();

            if (raschetnyPriborUcheta == null)
            {
                return NotFound();
            }

            return raschetnyPriborUcheta;
        }

        // PUT: api/RaschetnyPriborUchetas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        private async Task<IActionResult> PutRaschetnyPriborUcheta(int id, RaschetnyPriborUcheta raschetnyPriborUcheta)
        {
            if (id != raschetnyPriborUcheta.RaschetnyPriborUchetaId)
            {
                return BadRequest();
            }

            _context.Entry(raschetnyPriborUcheta).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RaschetnyPriborUchetaExists(id))
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

        // POST: api/RaschetnyPriborUchetas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        private async Task<ActionResult<RaschetnyPriborUcheta>> PostRaschetnyPriborUcheta(RaschetnyPriborUcheta raschetnyPriborUcheta)
        {
            _context.RaschetnyPriborUchetas.Add(raschetnyPriborUcheta);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRaschetnyPriborUcheta", new { id = raschetnyPriborUcheta.RaschetnyPriborUchetaId }, raschetnyPriborUcheta);
        }

        // DELETE: api/RaschetnyPriborUchetas/5
        [HttpDelete("{id}")]
        private async Task<IActionResult> DeleteRaschetnyPriborUcheta(int id)
        {
            var raschetnyPriborUcheta = await _context.RaschetnyPriborUchetas.FindAsync(id);
            if (raschetnyPriborUcheta == null)
            {
                return NotFound();
            }

            _context.RaschetnyPriborUchetas.Remove(raschetnyPriborUcheta);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RaschetnyPriborUchetaExists(int id)
        {
            return _context.RaschetnyPriborUchetas.Any(e => e.RaschetnyPriborUchetaId == id);
        }
    }
}
