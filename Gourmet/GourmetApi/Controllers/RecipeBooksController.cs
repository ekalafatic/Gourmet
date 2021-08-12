using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GourmetSp;
using GourmetApi.DTOs;
using GourmetApi.Repositories;
using GourmetApi.Mappers;

namespace GourmetApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeBooksController : ControllerBase
    {

        private readonly RecipeBookRepository _repository;

        public RecipeBooksController(GourmetContext context)
        {
            _repository = new RecipeBookRepository(context);
        }

        [HttpGet]
        public async Task<ActionResult<List<RecipeBookDTO>>> GetRecipeBooks()
        {
            var recipeBooks = await _repository.Get();

            if (recipeBooks == null)
            {
                return NotFound();
            }

            return recipeBooks.ToDTO();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RecipeBookDTO>> GetRecipeBook(int id)
        {
            var recipeBook = await _repository.Get(id);

            if (recipeBook == null)
            {
                return NotFound();
            }

            return recipeBook.ToDTO();
        }

        [HttpGet("{id}/Recipes")]
        public async Task<ActionResult<List<RecipeDTO>>> GetRecipes(int id)
        {
            var recipes = await _repository.GetRecipes(id);

            if (recipes == null)
            {
                return NotFound();
            }

            return recipes.ToDTO();
        }

        /*
         // JUST IN CASE

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
        */
    }
}
