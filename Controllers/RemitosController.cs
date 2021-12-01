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
    public class RemitosController : ControllerBase
    {
        private readonly DiavaDBContext context;
        public RemitosController(DiavaDBContext context)
        {
            this.context = context;
        }
        // GET: api/<ProductosController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Remitos>>> Get()
        {
            try
            {
                return await context.Remito.ToListAsync();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<ProductosController>/5
        [HttpGet("{id}", Name = "GetRemito")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var remito = await context.Remito.FindAsync(id);
                return Ok(remito);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        

        [HttpGet("busqueda/{nroremito}")]
        public ActionResult<List<Remitos>> MostrarPorNroRemito(int nroremito)
        {
            
            var ListaPorNroRemito = context.Remito.Where(x => x.nroremito == nroremito).ToList();
            if (ListaPorNroRemito == null || ListaPorNroRemito.Count() == 0)
            {
                return NotFound("No hay remitos con el numero " + nroremito);
            }
            return ListaPorNroRemito;


        }

        // POST api/<ProductosController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Remitos remito)
        {
            try
            {
                context.Remito.Add(remito);
                await context.SaveChangesAsync();
                return CreatedAtRoute("GetRemito", new { id = remito.id }, remito);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<ProductosController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Remitos remito)
        {
            try
            {
                if (remito.id == id)
                {
                    context.Entry(remito).State = EntityState.Modified;
                    await context.SaveChangesAsync();
                    return CreatedAtRoute("GetRemito", new { id = remito.id }, remito);
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
                var remito = context.Remito.FirstOrDefault(g => g.id == id);
                if (remito != null)
                {
                    context.Remito.Remove(remito);
                    await context.SaveChangesAsync();
                    return Ok("Se elimino correctamente el remito: " + id);
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
