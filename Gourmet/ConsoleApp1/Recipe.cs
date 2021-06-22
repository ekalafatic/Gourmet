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

        // Entrega2
        public bool isForCeliacs()
        {
            return !HasFoodGroup(FoodGroup.Cereals);
        }

        public bool isForVegetarians()
        {
            return !HasFoodGroup(FoodGroup.Meets);
        }
        public bool isForVegans()
        {
            return (!HasFoodGroup(FoodGroup.Dairies) && !HasFoodGroup(FoodGroup.Meets));
        }
        public bool isForCarnivores()
        {
            return (HasFoodGroup(FoodGroup.Meets) && (CaloriesRecipe() >= 200));
        }

        public bool isAccording(Profile profile)
        {
            switch (profile)
            {
                case Profile.Celiac:
                    return isForCeliacs();
                case Profile.Vegetarian:
                    return isForVegetarians();
                case Profile.Vegan:
                    return isForVegans();
                case Profile.Carnivorous:
                    return isForCarnivores();
                default:
                    return false;
            }
        }
    }
}
