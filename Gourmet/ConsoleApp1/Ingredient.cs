using System;
using System.Collections.Generic;
using System.Text;

namespace GourmetSp
{
    public class Ingredient
    {
        public Food Food { get; set; }
        public double Amount { get; set; }

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
