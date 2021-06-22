using System;
using System.Collections.Generic;
using System.Text;

namespace GourmetSp
{
    public class RecipeBook
    {
        private List<Recipe> _recipes;

        public RecipeBook(List<Recipe> recipes)
        {
            this._recipes = recipes;
        }

        public RecipeBook() 
        {
            this._recipes = new List<Recipe>();
        }

        public void addRecipe(Recipe recipe)
        {
            _recipes.Add(recipe);
        }

        public int amountRecipes()
        {
            return _recipes.Count;
        }


    }
}
