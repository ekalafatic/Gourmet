using System;
using System.Collections.Generic;
using System.Text;

namespace GourmetSp
{
    public class Carnivorous : IProfile
    {
        private readonly double _caloriesNeeded = 200;
        public bool IsAccording(Recipe recipe)
        {
            return recipe.HasFoodGroup(FoodGroup.Meets) && (recipe.CaloriesRecipe() >= _caloriesNeeded);
        }
    }
}
