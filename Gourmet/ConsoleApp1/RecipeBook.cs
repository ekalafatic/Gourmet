using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class RecipeBook
    {
        public List<Recipe> recipes { get; set; }

        public RecipeBook(List<Recipe> recipes)
        {
            this.recipes = recipes;
        }

        public void addRecipe(Recipe recipe)
        {
            recipes.Add(recipe);
        }

        public int amountRecipes()
        {
            return recipes.Count;
        }


    }
}
