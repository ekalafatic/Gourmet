using System;
using System.Collections.Generic;
using System.Text;

namespace GourmetSp
{
    public class Celiac : IProfile
    {
        public bool isAccording(Recipe recipe)
        {
            return !recipe.HasFoodGroup(FoodGroup.Cereals);
        }
    }
}
