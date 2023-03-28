using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShipmentStgsController : ControllerBase
    {
        private readonly ORDMNG_81310Context _context;

        public ShipmentStgsController(ORDMNG_81310Context context)
        {
            _context = context;
        }

        // GET: api/ShipmentStgs
        [HttpGet]
        public IEnumerable<ShipmentStg> GetShipmentStg()
        {
            return _context.ShipmentStg;
        }

        // GET: api/ShipmentStgs/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetShipmentStg([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var shipmentStg = await _context.ShipmentStg.FindAsync(id);

            if (shipmentStg == null)
            {
                return NotFound();
            }

            return Ok(shipmentStg);
        }

        // PUT: api/ShipmentStgs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShipmentStg([FromRoute] int id, [FromBody] ShipmentStg shipmentStg)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != shipmentStg.ShipStg)
            {
                return BadRequest();
            }

            _context.Entry(shipmentStg).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShipmentStgExists(id))
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

        // POST: api/ShipmentStgs
        [HttpPost]
        public async Task<IActionResult> PostShipmentStg([FromBody] ShipmentStg shipmentStg)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ShipmentStg.Add(shipmentStg);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetShipmentStg", new { id = shipmentStg.ShipStg }, shipmentStg);
        }

        // DELETE: api/ShipmentStgs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShipmentStg([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var shipmentStg = await _context.ShipmentStg.FindAsync(id);
            if (shipmentStg == null)
            {
                return NotFound();
            }

            _context.ShipmentStg.Remove(shipmentStg);
            await _context.SaveChangesAsync();

            return Ok(shipmentStg);
        }

        private bool ShipmentStgExists(int id)
        {
            return _context.ShipmentStg.Any(e => e.ShipStg == id);
        }
    }
}