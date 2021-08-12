using GourmetSp;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GourmetApi.Repositories
{
    public class RecipeBookRepository
    {
        private readonly GourmetContext _context;

        public RecipeBookRepository(GourmetContext context)
        {
            _context = context;
        }

        public async Task<List<RecipeBook>> Get()
        {
            return await _context.RecipeBooks.ToListAsync();
        }
        public async Task<RecipeBook> Get(int id)
        {
            return await _context.RecipeBooks.FindAsync(id);
        }

        public async Task<List<Recipe>> GetRecipes(int id)
        {
            var recipeBook = await _context.RecipeBooks
                                   .Include(x => x.Recipes)
                                   .ThenInclude(y => y.Ingredients)
                                   .ThenInclude(x => x.Food)
                                   .FirstOrDefaultAsync(x => x.RecipeBookId == id);

            return recipeBook.Recipes;
        }

        public async Task<List<Ingredient>> GetIngredients(int id)
        {
            var recipeBook = await _context.RecipeBooks
                                   .Include(x => x.Recipes)
                                   .ThenInclude(y => y.Ingredients)
                                   .ThenInclude(x => x.Food)
                                   .FirstOrDefaultAsync(x => x.RecipeBookId == id);

            return recipeBook.Recipes[0].Ingredients;
        }
    }
}