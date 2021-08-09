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
        public readonly List<Ingredient> Ingredients;
        public readonly List<RecipeBook> RecipeBooks;

        public Recipe(string recipeTitle, List<Ingredient> ingredients)
        {
            this.RecipeTitle = recipeTitle;
            this.Ingredients = ingredients;
            this.RecipeBooks = new List<RecipeBook>();
        }

        public List<RecipeBook> getRecipeBooks()
        {
            List<RecipeBook> recipeBooksCopy = new List<RecipeBook>(this.RecipeBooks);
            return recipeBooksCopy;
        }
        
        public List<Ingredient> GetIngredients()
        {
            List<Ingredient> ingredientsCopy = new List<Ingredient>(this.Ingredients);
            return ingredientsCopy;
        }

        public Recipe() 
        {
            this.Ingredients = new List<Ingredient>();
            this.RecipeTitle = "";
        }

        public double CaloriesRecipe()
        {
           return this.Ingredients.Sum(x => x.Calories());
        }

        public double AmountIngredients()
        {
            return this.Ingredients.Count;
        }

        public bool HasFood(Food food)
        {
            return this.Ingredients.Any(x => x.HasFood(food));
        }

        public bool HasFoodGroup(FoodGroup group)
        {
            return this.Ingredients.Any(x => x.HasFoodGroup(group));
        }
    }
}
