using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPIPetshop.Model;

namespace WebAPIPetshop.Controllers
{
    [ApiController]
    [Route("api/v4/[controller]")]
    public class ProductoController : ControllerBase
    {
        private readonly UsuarioProductoContext _context;

        public ProductoController(UsuarioProductoContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Producto>>> GetProductos()
        {
            if (_context.Productos == null)
            {
                return NotFound();
            }
            return await _context.Productos.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Producto>> GetProductoID(int id)
        {
            if (_context.Productos == null)
            {
                return NotFound();
            }

            var producto = await _context.Productos.FindAsync(id);

            if (producto == null)
            {
                return NotFound();
            }

            return producto; 
        }

        [HttpPost]
        public async Task<ActionResult<Producto>> PostProducto(Producto producto){
            _context.Productos.Add(producto);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProductoID), new { id = producto.id }, producto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutProducto (int id, Producto producto){
            if (id != producto.id)
            {
                return BadRequest();
            }

            _context.Entry(producto).State = EntityState.Modified;
            try{
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException){
                if (!ProductoExist(id)){
                    return NotFound();
                }
                else{
                    throw;
                }
            }

            return Ok();
        }

        private bool ProductoExist(int id){
            return (_context.Productos?.Any(e => e.id == id)).GetValueOrDefault();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProducto(int id){
            if (_context.Productos == null)
            {
                return NotFound();
            }

            var producto = await _context.Productos.FindAsync(id);

            if (producto == null)
            {
                return NotFound();
            }

            _context.Productos.Remove(producto);

            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}