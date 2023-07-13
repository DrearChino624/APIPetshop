
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPIPetshop.Model;

namespace WebAPIPetshop.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompraController : ControllerBase
    {
        private readonly UsuarioProductoContext _context;

        public CompraController(UsuarioProductoContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Compra>>> GetCompras()
        {
            if (_context.Compras == null)
            {
                return NotFound();
            }
            return await _context.Compras.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Compra>> GetCompraID(int id)
        {
            if (_context.Compras == null)
            {
                return NotFound();
            }

            var compra = await _context.Compras.FindAsync(id);
            if (compra == null)
            {
                return NotFound();
            }

            return compra;
        }

        [HttpPost]
        public async Task<ActionResult<Compra>> PostCompra(Compra compra)
        {
            _context.Compras.Add(compra);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCompraID), new { id = compra.id }, compra);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompra(Compra compra){
            if (compra.id == 0){
                return BadRequest();
            }

            _context.Entry(compra).State = EntityState.Modified;
            try{
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException){
                if (!CompraExists(compra.id)){
                    return NotFound();
                }
                else{
                    throw;
                }
            }

            return Ok();
        }

        private bool CompraExists(int id){
            return (_context.Compras?.Any(e => e.id == id)).GetValueOrDefault();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompra(int id){
            if (_context.Compras == null)
            {
                return NotFound();
            }

            var compra = await _context.Compras.FindAsync(id);

            if (compra == null)
            {
                return NotFound();
            }

            _context.Compras.Remove(compra);

            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}