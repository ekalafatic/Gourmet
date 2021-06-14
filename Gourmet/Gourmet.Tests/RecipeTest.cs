using System;
using System.Collections.Generic;
using Xunit;


namespace GourmetSp.Tests
{
    public class RecipeTest
    {
        // lácteos, carnes, legumbres, vegetales, frutas, cereales.
        private static List<string> foodGroups = new List<string> { "dairies", "meets", "vegetables", "fruits", "legumes", "cereals" };
        private static List<string> units = new List<string> { "grams", "kilos", "c/n", "unit" };
        private Dictionary<Food, double> ingredients;
        private Food 
            food1 = new Food(23, units[2], foodGroups[2], "food1"), 
            food2 = new Food(45, units[2], foodGroups[3], "food2"),
            food3 = new Food(123, units[3], foodGroups[0], "food3");
        private Recipe recipe;

        [Fact]
        public void amountIngredientsTest()
        {

            // < Recipes >
            // Recipe1
            this.ingredients = new Dictionary<Food, double>();
            ingredients.Add(food1, 1);
            ingredients.Add(food2, 1);
            ingredients.Add(food3, 5);

            this.recipe = new Recipe("recipe1", ingredients);

            var result = recipe.amountIngredients();

            Assert.Equal(3, result);
        }


        [Fact]
        public void amountIngredientsNullTest()
        {
            this.recipe = new Recipe();

            var result = this.recipe.amountIngredients();

            Assert.Equal(0, result);
        }

        [Fact]
        public void amountCalories()
        {

            // < Recipes >
            // Recipe1
            this.ingredients = new Dictionary<Food, double>();
            ingredients.Add(food1, 1);
            ingredients.Add(food2, 1);
            ingredients.Add(food3, 5);

            this.recipe = new Recipe("recipe1", ingredients);

            var result = recipe.caloriesRecipe();

            Assert.Equal(683, result);
        }

        [Fact]
        public void amountCaloriesNullTest()
        {
            this.recipe = new Recipe();

            var result = this.recipe.caloriesRecipe();

            Assert.Equal(0, result);
        }

        [Fact]
        public void foodNameTest()
        {
            // < Recipe >
            this.ingredients = new Dictionary<Food, double>();
            ingredients.Add(food1, 1);
            ingredients.Add(food2, 1);

            this.recipe = new Recipe("recipe1", ingredients);

            var lFood = this.recipe.getFood();

            bool result = false;

            foreach (Food food in lFood)
            {
                if (food.name == "food1") result = true;
            }

            Assert.True(result);
        }

        [Fact]
        public void foodNameNullTest()
        {
            // < Recipe >
            this.ingredients = new Dictionary<Food, double>();

            this.recipe = new Recipe("recipe1", ingredients);

            var lFood = this.recipe.getFood();

            bool result = false;

            foreach (Food food in lFood)
            {
                if (food.name == "food1") result = true;
            }

            Assert.False(result);
        }


        [Fact]
        public void groupTest()
        {
            // < Recipe >
            this.ingredients = new Dictionary<Food, double>();
            ingredients.Add(food1, 1);
            ingredients.Add(food2, 1);

            this.recipe = new Recipe("recipe1", ingredients);

            var lFood = this.recipe.getFood();

            bool result = false;

            foreach (Food food in lFood)
            {
                if (food.group == "vegetables") result = true;
            }

            Assert.True(result);
        }

        [Fact]
        public void groupNullTest()
        {
            this.recipe = new Recipe();

            var lFood = recipe.getFood();

            bool result = false;

            foreach (Food food in lFood)
            {
                if (food.group == "vegetables") result = true;
            }

            Assert.False(result);
        }
    }
}
