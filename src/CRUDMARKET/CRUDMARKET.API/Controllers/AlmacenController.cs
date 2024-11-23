using CRUDMARKET.API.Controllers;
using CRUDMARKET.DOMAIN.Entities;
using CRUDMARKET.INFRASTRUCTURE.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRUDMARKET.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlmacenController : ControllerBase
    {
        private readonly AlmacenRepository _repository;

        public AlmacenController(AlmacenRepository repository)
        {
            _repository = repository;
        }

        // GET: api/Almacen
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Almacen>>> GetAlmacenes()
        {
            try
            {
                var almacenes = await _repository.GetAllAsync();
                return Ok(almacenes);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, $"Error interno: {ex.Message}");
            }
        }

        // GET: api/Almacen/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Almacen>> GetAlmacen(int id)
        {
            try
            {
                var almacen = await _repository.GetByIdAsync(id);
                if (almacen == null)
                {
                    return NotFound($"Almacén con ID {id} no encontrado.");
                }

                return Ok(almacen);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, $"Error interno: {ex.Message}");
            }
        }

        // POST: api/Almacen
        [HttpPost]
        public async Task<ActionResult> PostAlmacen([FromBody] Almacen almacen)
        {
            try
            {
                await _repository.AddAsync(almacen);
                return CreatedAtAction(nameof(GetAlmacen), new { id = almacen.Id }, almacen);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, $"Error interno: {ex.Message}");
            }
        }

        // PUT: api/Almacen/5
        [HttpPut("{id}")]
        public async Task<ActionResult> PutAlmacen(int id, [FromBody] Almacen almacen)
        {
            if (id != almacen.Id)
            {
                return BadRequest("El ID del parámetro no coincide con el ID del objeto.");
            }

            try
            {
                await _repository.UpdateAsync(almacen);
                return NoContent();
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, $"Error interno: {ex.Message}");
            }
        }

        // DELETE: api/Almacen/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAlmacen(int id)
        {
            try
            {
                var almacen = await _repository.GetByIdAsync(id);
                if (almacen == null)
                {
                    return NotFound($"Almacén con ID {id} no encontrado.");
                }

                await _repository.DeleteAsync(id);
                return NoContent();
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, $"Error interno: {ex.Message}");
            }
        }
    }
}
