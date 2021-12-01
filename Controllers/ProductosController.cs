using Diavamedic.Context;
using Diavamedic.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Diavamedic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly DiavaDBContext context;
        public ProductosController(DiavaDBContext context)
        {
            this.context = context;
        }
        // GET: api/<ProductosController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Productos>>> Get()
        {
            try
            {
                return await context.Producto.ToListAsync();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<ProductosController>/5
        [HttpGet("{id}", Name = "GetProducto")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var producto = await context.Producto.FindAsync(id);
                return Ok(producto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("busqueda/{lote}")]
        public ActionResult<List<Productos>> MostrarPorLote(string lote)
        {

            var ListaPorLote = context.Producto.Where(x => x.lote == lote).ToList();
            if (ListaPorLote == null || ListaPorLote.Count() == 0)
            {
                return NotFound("No hay productos con el lote " + lote);
            }
            return ListaPorLote;


        }



        // POST api/<ProductosController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Productos producto)
        {
            try
            {
                context.Producto.Add(producto);
                await context.SaveChangesAsync();
                return CreatedAtRoute("GetProducto", new { id = producto.id }, producto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<ProductosController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Productos producto)
        {
            try
            {
                if (producto.id == id)
                {
                    context.Entry(producto).State = EntityState.Modified;
                    await context.SaveChangesAsync();
                    return CreatedAtRoute("GetProducto", new { id = producto.id }, producto);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<ProductosController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var categoria = context.Producto.FirstOrDefault(g => g.id == id);
                if (categoria != null)
                {
                    context.Producto.Remove(categoria);
                    await context.SaveChangesAsync();
                    return Ok("Se elimino correctamente el producto: " + id);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
