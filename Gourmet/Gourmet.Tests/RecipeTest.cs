using System;
using System.Collections.Generic;
using Xunit;


namespace GourmetSp.Tests
{
    public class RecipeTest
    {
        private Dictionary<Food, double> ingredients;
        private Food 
            food1 = new Food(23, Unit.unit, FoodGroup.Vegetables, "food1"), 
            food2 = new Food(45, Unit.kilos, FoodGroup.Legumes, "food2"),
            food3 = new Food(123, Unit.grams, FoodGroup.Cereals, "food3");
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

            bool result = recipe.haveFood("food1");

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
        public void groupTrueTest()
        {
            // < Recipe >
            this.ingredients = new Dictionary<Food, double>();
            ingredients.Add(food1, 1);
            ingredients.Add(food2, 1);

            this.recipe = new Recipe("recipe1", ingredients);

            bool result = recipe.haveFoodGroup(FoodGroup.Vegetables);

            Assert.True(result);
        }

        [Fact]
        public void groupFalseTest()
        {
            this.ingredients = new Dictionary<Food, double>();
            ingredients.Add(food1, 1);
            ingredients.Add(food2, 1);

            this.recipe = new Recipe("recipe1", ingredients);

            bool result = recipe.haveFoodGroup(FoodGroup.Meets);

            Assert.False(result);
        }
    }
}
