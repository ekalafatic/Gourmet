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
        private Food _food1, _food2, _food3;
        private Recipe _recipe;

        [Fact]
        public void amountIngredientsTest()
        {
            // <- Food >
            Food _food1 = new Food(23, _units[2], _foodGroups[2]);
            Food _food2 = new Food(45, _units[2], _foodGroups[3]);
            Food _food3 = new Food(123, _units[3], _foodGroups[0]);

            // < Recipes >
            // Recipe1
            Dictionary<Food, double> _ingredients = new Dictionary<Food, double>();
            _ingredients.Add(_food1, 1);
            _ingredients.Add(_food2, 1);
            _ingredients.Add(_food3, 5);

            Recipe _recipe = new Recipe("recipe1", _ingredients);

            var result = _recipe.amountIngredients();

            Assert.Equal(3, result);
        }


        [Fact]
        public void amountIngredientsNullTest()
        {
            Recipe _recipe = new Recipe();

            var result = _recipe.amountIngredients();

            Assert.Equal(0, result);
        }
    }
}
