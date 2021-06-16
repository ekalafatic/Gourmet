using System;
using System.Collections.Generic;
using System.Text;

namespace GourmetSp
{
    public class Recipe
    {
        public string RecipeTitle { get; set; }

        private List<Ingredient> _lIngredients;

        public Recipe(string recipeTitle, List<Ingredient> ingredients)
        {
            this.RecipeTitle = recipeTitle;
            this._lIngredients = ingredients;
        }

        public Recipe() 
        {
            this._lIngredients = new List<Ingredient>();
            this.RecipeTitle = "";
        }

        public double CaloriesRecipe()
        {
            double calories = 0;

            foreach (Ingredient ingredient in _lIngredients)
            {
                calories += ingredient.Food.Calories * ingredient.Amount;
            }

            return calories;
        }

        public double AmountIngredients()
        {
            return this._lIngredients.Count;
        }

        public Boolean HaveFood(string nameFood)
        {

            foreach (Ingredient ingredient in _lIngredients)
            {
                if(ingredient.Food.Name == nameFood) return true;
            }

            return false;
        }

        public Boolean HaveFoodGroup(FoodGroup group)
        {
            foreach (Ingredient ingredient in _lIngredients)
            {
                if (ingredient.Food.Group == group) return true;
            }

            return false;
        }

    }
}
