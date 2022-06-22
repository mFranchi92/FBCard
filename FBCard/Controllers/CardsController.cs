using FBCard.Data;
using FBCard.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FBCard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public CardsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/<CardsController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var CardList = await _context.CreditCard.ToListAsync();
                return Ok(CardList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<CardsController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreditCard card)
        {
            try
            {
                _context.Add(card);
                await _context.SaveChangesAsync();

                return Ok(card);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<CardsController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] CreditCard card)
        {
            try
            {
                if (id != card.Id)
                {
                    return NotFound();
                }

                _context.Update(card);
                await _context.SaveChangesAsync();

                return Ok(new { message = "Card succesfully updated" });

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<CardsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var card = await _context.CreditCard.FindAsync(id);
                if (card == null)
                {
                    return NotFound();
                }

                _context.CreditCard.Remove(card);
                await _context.SaveChangesAsync();

                return Ok(new {message = "Card deleted succesfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
