using GourmetSp;
using GourmetApi.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace GourmetApi.Mappers
{
    public static class RecipeBookMapper
    {
        public static RecipeBookDTO ToDTO(this RecipeBook recipeBook)
        {
            return new RecipeBookDTO
            {
                RecipeBookId = recipeBook.RecipeBookId,
                RecipeBookTitle = recipeBook.RecipeBookTitle
            };
        }

        public static List<RecipeBookDTO> ToDTO(this List<RecipeBook> recipeBooks)
        {
            return recipeBooks.Select(rb => rb.ToDTO()).ToList();
        }
    }
}