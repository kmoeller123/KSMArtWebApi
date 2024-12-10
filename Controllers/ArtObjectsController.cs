using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KSMArtWebApi.Models;
using KSMArtMauiApp.Services;
using Azure.Storage.Blobs.Models;
using System.Drawing;

namespace KSMArtWebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ArtObjectsController : ControllerBase
    {
        private readonly KsmartContext _context;

        public ArtObjectsController(KsmartContext context)
        {
            _context = context;
        }

        // GET: api/ArtObjects
        [HttpGet("All")]    
        public async Task<ActionResult<IEnumerable<ArtObject>>> GetArtObjects()
        {
            
            return await _context.ArtObjects.ToListAsync();

        }

        // GET: api/ArtObjects/5
        [HttpGet("Details/{id}")]
        
        public async Task<ActionResult<ArtObject>> GetArtObject(int id)
        {
            var artObject = await _context.ArtObjects.FindAsync(id);

            if (artObject == null)
            {
                return NotFound();
            }

            return artObject;
        }

        // PUT: api/ArtObjects/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("Update/{id}")]
        public async Task<ActionResult<ArtObject>> PutArtObject(int id,[FromBody] ArtObject artObject)
        {
            if (id != artObject.Id)
            {
                return BadRequest();
            }

            _context.Entry(artObject).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArtObjectExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return artObject;
        }

        // POST: api/ArtObjects
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("Create")]
        public async Task<ActionResult<ArtObject>> PostArtObject([FromBody] ArtObject artObject)
        {
            _context.ArtObjects.Add(artObject);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetArtObject", new { id = artObject.Id }, artObject);
        }

        // DELETE: api/ArtObjects/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArtObject(int id)
        {
            var artObject = await _context.ArtObjects.FindAsync(id);
            if (artObject == null)
            {
                return NotFound();
            }

            _context.ArtObjects.Remove(artObject);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // GET: api/ArtObjects
        [HttpGet("Test")]
        public async Task<List<Image>> Test()
        {
            //var builder = WebApplication.CreateBuilder();
            //var app = builder.Build();

            //return app.Environment.IsDevelopment();
            //New code

            AzureFileService srv = new AzureFileService();
           return await srv.DownloadImageFiles();
        }

        private bool ArtObjectExists(int id)
        {
            return _context.ArtObjects.Any(e => e.Id == id);
        }
    }
}
