using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GourmetSp;

namespace GourmetApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeBooksController : ControllerBase
    {
        private readonly GourmetContext _context;

        public RecipeBooksController(GourmetContext context)
        {
            _context = context;
        }

        // GET: api/RecipeBooks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RecipeBook>>> GetRecipeBooks()
        {
            return await _context.RecipeBooks.ToListAsync();
        }

        //// GET: api/RecipeBooks/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<RecipeBook>> GetRecipeBook(int id)
        //{
        //    var recipeBook = await _context.RecipeBooks.FindAsync(id);

        //    if (recipeBook == null)
        //    {
        //        return NotFound();
        //    }

        //    return recipeBook;
        //}

        //// GET: api/RecipeBooks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<List<Recipe>>> GetFoodRecipeBook(int id)
        {
            //var recipes =  _context.RecipeBooks.Include(x => x.Recipes).ToList();
            var recipeBook = await _context.RecipeBooks
                                   .Include(x => x.Recipes)
                                   .FirstOrDefaultAsync(x => x.RecipeBookId == id);

            if (recipeBook == null)
            {
                return NotFound();
            }
            
            return recipeBook.Recipes;
        }

        // PUT: api/RecipeBooks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRecipeBook(int id, RecipeBook recipeBook)
        {
            if (id != recipeBook.RecipeBookId)
            {
                return BadRequest();
            }

            _context.Entry(recipeBook).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecipeBookExists(id))
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

        // POST: api/RecipeBooks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RecipeBook>> PostRecipeBook(RecipeBook recipeBook)
        {
            _context.RecipeBooks.Add(recipeBook);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRecipeBook", new { id = recipeBook.RecipeBookId }, recipeBook);
        }

        // DELETE: api/RecipeBooks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecipeBook(int id)
        {
            var recipeBook = await _context.RecipeBooks.FindAsync(id);
            if (recipeBook == null)
            {
                return NotFound();
            }

            _context.RecipeBooks.Remove(recipeBook);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RecipeBookExists(int id)
        {
            return _context.RecipeBooks.Any(e => e.RecipeBookId == id);
        }
    }
}
