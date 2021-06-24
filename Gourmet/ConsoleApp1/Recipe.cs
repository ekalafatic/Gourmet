using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GourmetSp
{
    public class Recipe
    {
        public string RecipeTitle { get; set; }

        private List<Ingredient> _ingredients;

        public Recipe(string recipeTitle, List<Ingredient> ingredients)
        {
            this.RecipeTitle = recipeTitle;
            this._ingredients = ingredients;
        }

        public Recipe() 
        {
            this._ingredients = new List<Ingredient>();
            this.RecipeTitle = "";
        }

        public double CaloriesRecipe()
        {
           return this._ingredients.Sum(x => x.Calories());
        }

        public double AmountIngredients()
        {
            return this._ingredients.Count;
        }

        public bool HasFood(Food food)
        {
            return this._ingredients.Any(x => x.HasFood(food));
        }

        public bool HasFoodGroup(FoodGroup group)
        {
            return this._ingredients.Any(x => x.HasFoodGroup(group));
        }
    }
}
