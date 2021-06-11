using System;
using System.Collections.Generic;
using System.Text;

namespace GourmetSp
{
    public class Recipe
    {
        public string recipeTitle { get; set; }
        //public List<Food> listFood { get; set; }
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

        // Comentario sólo para recordar la maravilla de get set automático :')
        //public void setListFood(List<Food> listFood)
        //{
        //    this.listFood = listFood;
        //}
        //public List<Food> getFood()
        //{
        //    return this.listFood;
        //}

        //public void setAmountIngredients(Dictionary<Food,double> amountIngredients)
        //{
        //    this.amountIngredients = amountIngredients;
        //}

        //public Dictionary<Food, double> getAmountIngredients()
        //{
        //    return this.amountIngredients;
        //}
    }
}
