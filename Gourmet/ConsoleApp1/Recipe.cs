using System;
using System.Collections.Generic;
using System.Text;

namespace GourmetSp
{
    public class Recipe
    {
        public string recipeTitle { get; set; }
        //public List<Food> listFood { get; set; }

        //CAMBIAR PARA NO TENER GET SET DE COLECCIÓN
        public Dictionary<Food, double> amountByIngredients { get; set; }

        public Recipe(string recipeTitle, Dictionary<Food,double> amountByIngredients)
        {
            this.recipeTitle = recipeTitle;
            this.amountByIngredients = amountByIngredients;
        }

        public Recipe() { }

        public double caloriesRecipe()
        {
            double calories = 0;

            if (this.amountByIngredients == null) return calories;

            Dictionary<Food, double>.KeyCollection keyIngredients = this.amountByIngredients.Keys;

            foreach (Food food in keyIngredients)
            {
                calories += food.calories * amountByIngredients[food];
            }

            return calories;
        }

        public double amountIngredients()
        {
            if (amountByIngredients == null) this.amountByIngredients = new Dictionary<Food, double>();

            return this.amountByIngredients.Count;
        }

        public Boolean haveFood(string nameFood)
        {
            Dictionary<Food, double>.KeyCollection keyIngredients = this.amountByIngredients.Keys;

            foreach (Food food in keyIngredients)
            {
                if (food.name == nameFood) return true;
            }

            return false;
        }

        public Boolean haveFoodGroup(FoodGroup group)
        {
            Dictionary<Food, double>.KeyCollection keyIngredients = this.amountByIngredients.Keys;

            foreach (Food food in keyIngredients)
            {
                if (food.group == group) return true;
            }

            return false;
        }

    }
}
