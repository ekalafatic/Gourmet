using System;
using System.Collections.Generic;
using System.Text;

namespace GourmetSp
{
    public class Profile
    {
        public ProfileType type { get; set; }

        public Profile(ProfileType type) => this.type = type;

        public Profile() => this.type = new ProfileType();

        public bool isAccording(Recipe recipe)
        {
            double caloriesNeeded = 200;

            switch (this.type)
            {
                case ProfileType.Celiac:
                    return !recipe.HasFoodGroup(FoodGroup.Cereals);
                case ProfileType.Vegetarian:
                    return !recipe.HasFoodGroup(FoodGroup.Meets);
                case ProfileType.Vegan:
                    return !recipe.HasFoodGroup(FoodGroup.Dairies) && !recipe.HasFoodGroup(FoodGroup.Meets);
                case ProfileType.Carnivorous:
                    return recipe.HasFoodGroup(FoodGroup.Meets) && (recipe.CaloriesRecipe() >= caloriesNeeded);
                default:
                    return false;
            }
        }
    }
}
