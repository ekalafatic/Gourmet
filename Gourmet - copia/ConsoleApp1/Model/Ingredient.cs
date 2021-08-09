using System;
using System.Collections.Generic;
using System.Text;

namespace GourmetSp
{
    public class Ingredient
    {
        public int IngredientId { get; set; }
        public Food Food { get; set; }
        public double Amount { get; set; }
        public readonly List<Recipe> Recipes;

        public Ingredient() 
        {
            this.Food = new Food();
            this.Amount = 0;
            this.Recipes = new List<Recipe>();
        }
        public Ingredient(Food food, double amount)
        {
            this.Food = food;
            this.Amount = amount;
            this.Recipes = new List<Recipe>();
        }

        public List<Recipe> getRecipes()
        {
            List<Recipe> recipesCopy = new List<Recipe>(this.Recipes);
            return recipesCopy;
        }
        public bool HasFood(Food food)
        {
            if (this.Food.Name == food.Name) return true;
            return false;
        }

        public bool HasFoodGroup(FoodGroup group)
        {
            if (this.Food.Group == group) return true;
            return false;
        }

        public double Calories()
        {
            return this.Food.Calories * this.Amount;
        }
    }
}
