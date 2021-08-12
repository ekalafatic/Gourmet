using System.Collections.Generic;
using GourmetSp;

namespace GourmetApi.DTOs
{
    public class RecipeDTO
    {
        public int RecipeId { get; set; }
        public string RecipeTitle { get; set; }
        public List<IngredientDTO> Ingredients { get; set; }
    }
}