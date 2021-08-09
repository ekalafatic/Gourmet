using System;
using System.Collections.Generic;
using System.Text;

namespace GourmetSp
{
    public class Food
    {
        public int FoodID { get; set; }
        public double Calories { get; set; }
        public string Name { get; set; }
        public FoodGroup Group { get; set; }
        public Unit Unit { get; set; }
        public readonly List<Ingredient> Ingredients;

        public Food(double calories, Unit unit, FoodGroup group, string name)
        {
            this.Calories = calories;
            this.Unit = unit;
            this.Group = group;
            this.Name = name;
            this.Ingredients = new List<Ingredient>();
        }

        public Food() 
        {
            this.Name = "";
            this.Calories = 0;
            this.Unit = new Unit();
            this.Group = new FoodGroup();
            this.Ingredients = new List<Ingredient>();
        }

        public List<Ingredient> GetIngredients()
        {
            List<Ingredient> ingredientsCopy = new List<Ingredient>(this.Ingredients);
            return ingredientsCopy;
        }
    }
}
