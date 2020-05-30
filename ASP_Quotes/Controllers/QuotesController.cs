using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ASP_Quotes.Models;

namespace ASP_Quotes.Controllers
{
    [Route("api/Quotes")]
    [ApiController]
    public class QuotesController : ControllerBase
    {
        private readonly ASP_QuotesContext _context;

        public QuotesController(ASP_QuotesContext context)
        {
            _context = context;
        }

        // GET: api/Quotes
        [HttpGet]
        public async Task<IEnumerable<Quotes>> GetQuotes()
        {
            await DeleteQuotes();
            return _context.Quotes;
        }


        public async Task DeleteQuotes()
        {
            var list = _context.Quotes.Where(m => m.InsertDate.AddMonths(1) == DateTime.Now);
            await list.ForEachAsync(m=> { _context.Quotes.RemoveRange(); });
            await _context.SaveChangesAsync();
        }

        // GET: api/Quotes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetQuotes([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var quotes = await _context.Quotes.FindAsync(id);

            if (quotes == null)
            {
                return NotFound();
            }

            return Ok(quotes);
        }

        // PUT: api/Quotes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuotes([FromRoute] int id, [FromBody] Quotes quotes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != quotes.QuotesId)
            {
                return BadRequest();
            }

            _context.Entry(quotes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuotesExists(id))
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

        // POST: api/Quotes
        [HttpPost]
        public async Task<IActionResult> PostQuotes([FromBody] Quotes quotes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            quotes.InsertDate = DateTime.Now;
            _context.Quotes.Add(quotes);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetQuotes", new { id = quotes.QuotesId }, quotes);
        }

        // DELETE: api/Quotes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuotes([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var quotes = await _context.Quotes.FindAsync(id);
            if (quotes == null)
            {
                return NotFound();
            }

            _context.Quotes.Remove(quotes);
            await _context.SaveChangesAsync();

            return Ok(quotes);
        }

        private bool QuotesExists(int id)
        {
            return _context.Quotes.Any(e => e.QuotesId == id);
        }
    }
}