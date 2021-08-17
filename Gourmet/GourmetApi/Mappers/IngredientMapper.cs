using GourmetSp;
using GourmetApi.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace GourmetApi.Mappers
{
    public static class IngredientMapper
    {
        public static IngredientDTO ToDTO(this Ingredient ingredient)
        {
            return new IngredientDTO
            {
                IngredientId = ingredient.IngredientId,
                Food = ingredient.Food,
                Amount = ingredient.Amount
            };
        }

        public static List<IngredientDTO> ToDTO(this List<Ingredient> ingredients)
        {
            return ingredients.Select(rb => rb.ToDTO()).ToList();
        }
    }
}