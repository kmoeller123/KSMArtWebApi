using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KSMArtWebApi.Models;

namespace KSMArtWebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ItemViewsController : ControllerBase
    {
        private readonly KsmartContext _context;

        public ItemViewsController(KsmartContext context)
        {
            _context = context;
        }

        // GET: ItemViews/All
        [HttpGet("All")]
        public async Task<ActionResult<IEnumerable<ItemViews>>> GetItemViews()
        {
            return await _context.ItemViews.ToListAsync();
        }

        // GET: /ItemViews/5
        [HttpGet("Details{id}")]
        public async Task<ActionResult<ItemViews>> GetItemViews(int id)
        {
            var itemViews = await _context.ItemViews.FindAsync(id);

            if (itemViews == null)
            {
                return NotFound();
            }

            return itemViews;
        }

        // PUT: api/ItemViews/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("Update{id}")]
        public async Task<ActionResult<ItemViews>> PutItemViews(int id,[FromBody] ItemViews itemViews)
        {
            if (id != itemViews.Id)
            {
                return BadRequest();
            }

            _context.Entry(itemViews).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemViewsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return itemViews;
        }

        // POST: api/ItemViews
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("Create")]
        public async Task<ActionResult<ItemViews>> PostItemViews([FromBody] ItemViews itemViews)
        {
            _context.ItemViews.Add(itemViews);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetItemViews", new { id = itemViews.Id }, itemViews);
        }

        // DELETE: api/ItemViews/5
        [HttpDelete("Delete{id}")]
        public async Task<IActionResult> DeleteItemViews(int id)
        {
            var itemViews = await _context.ItemViews.FindAsync(id);
            if (itemViews == null)
            {
                return NotFound();
            }

            _context.ItemViews.Remove(itemViews);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ItemViewsExists(int id)
        {
            return _context.ItemViews.Any(e => e.Id == id);
        }
    }
}
