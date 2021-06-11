using System;
using System.Collections.Generic;
using System.Text;

namespace GourmetSp
{
    public class RecipeBook
    {
        public List<Recipe> recipes { get; set; }

        public RecipeBook(List<Recipe> recipes)
        {
            this.recipes = recipes;
        }

        public RecipeBook() { }

        public void addRecipe(Recipe recipe)
        {
            recipes.Add(recipe);
        }

        public int amountRecipes()
        {
            if(recipes == null)
            {
                this.recipes = new List<Recipe>();
            }

            return recipes.Count;
        }


    }
}
