using GourmetSp;
using GourmetApi.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace GourmetApi.Mappers
{
    public static class RecipeMapper
    {
        public static RecipeDTO ToDTO(this Recipe recipe)
        {
            return new RecipeDTO
            {
                RecipeId = recipe.RecipeId,
                RecipeTitle = recipe.RecipeTitle,
                Ingredients = recipe.Ingredients.ToDTO()
            };
        }

        public static List<RecipeDTO> ToDTO(this List<Recipe> recipes)
        {
            return recipes.Select(rb => rb.ToDTO()).ToList();
        }
    }
}