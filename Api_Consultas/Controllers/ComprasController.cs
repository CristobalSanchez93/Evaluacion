using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api_Consultas.Data;
using Api_Consultas.Tablas;

namespace Api_Consultas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComprasController : ControllerBase
    {
        private readonly DataContext _context;

        public ComprasController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Compras
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Compra_Cab>>> GetFactura_Cabecera()
        {
            return await _context.Factura_Cabecera.ToListAsync();
        }

        // GET: api/Compras/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Compra_Cab>> GetCompra_Cab(int id)
        {
            var compra_Cab = await _context.Factura_Cabecera.FindAsync(id);

            if (compra_Cab == null)
            {
                return NotFound();
            }

            return compra_Cab;
        }

        // PUT: api/Compras/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompra_Cab(int id, Compra_Cab compra_Cab)
        {
            if (id != compra_Cab.Compra_ID)
            {
                return BadRequest();
            }

            _context.Entry(compra_Cab).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Compra_CabExists(id))
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

        // POST: api/Compras
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Compra_Cab>> PostCompra_Cab(Compra_Cab compra_Cab)
        {
            _context.Factura_Cabecera.Add(compra_Cab);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCompra_Cab", new { id = compra_Cab.Compra_ID }, compra_Cab);
        }

        // DELETE: api/Compras/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompra_Cab(int id)
        {
            var compra_Cab = await _context.Factura_Cabecera.FindAsync(id);
            if (compra_Cab == null)
            {
                return NotFound();
            }

            _context.Factura_Cabecera.Remove(compra_Cab);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Compra_CabExists(int id)
        {
            return _context.Factura_Cabecera.Any(e => e.Compra_ID == id);
        }
    }
}
