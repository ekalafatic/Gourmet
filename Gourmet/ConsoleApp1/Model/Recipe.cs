using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GourmetSp
{
    public class Recipe
    {
        public int RecipeId { get; set; }
        public string RecipeTitle { get; set; }
        public List<Ingredient> _ingredients;
        public List<RecipeBook> _recipeBooks;

        public Recipe(string recipeTitle, List<Ingredient> ingredients)
        {
            this.RecipeTitle = recipeTitle;
            this._ingredients = ingredients;
            this._recipeBooks = new List<RecipeBook>();
        }

        public List<RecipeBook> getRecipeBooks()
        {
            List<RecipeBook> recipeBooksCopy = new List<RecipeBook>(this._recipeBooks);
            return recipeBooksCopy;
        }
        
        public List<Ingredient> GetIngredients()
        {
            List<Ingredient> ingredientsCopy = new List<Ingredient>(this._ingredients);
            return ingredientsCopy;
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
