using System;
using System.Collections.Generic;
using Xunit;


namespace GourmetSp.Tests
{
    public class RecipeTest
    {
        // lácteos, carnes, legumbres, vegetales, frutas, cereales.
        private static List<string> _foodGroups = new List<string> { "dairies", "meets", "vegetables", "fruits", "legumes", "cereals" };
        private static List<string> _units = new List<string> { "grams", "kilos", "c/n", "unit" };
        private Dictionary<Food, double> ingredients;
        private Food food1, food2, food3;
        private Recipe recipe;

        [Fact]
        public void amountIngredientsTest()
        {
            // <- Food >
            this.food1 = new Food(23, _units[2], _foodGroups[2]);
            this.food2 = new Food(45, _units[2], _foodGroups[3]);
            this.food3 = new Food(123, _units[3], _foodGroups[0]);

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
    }
}
