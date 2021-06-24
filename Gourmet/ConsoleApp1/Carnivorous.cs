using System;
using System.Collections.Generic;
using System.Text;

namespace GourmetSp
{
    public class Carnivorous : IProfile
    {
        double caloriesNeeded = 200;
        public bool isAccording(Recipe recipe)
        {
            return recipe.HasFoodGroup(FoodGroup.Meets) && (recipe.CaloriesRecipe() >= caloriesNeeded);
        }
    }
}
