using System;
using System.Collections.Generic;
using System.Text;

namespace GourmetSp
{
    public class Vegan : IProfile
    {
        public bool isAccording(Recipe recipe)
        {
            return !recipe.HasFoodGroup(FoodGroup.Dairies) && !recipe.HasFoodGroup(FoodGroup.Meets);
        }
    }
}
