using System;
using System.Collections.Generic;
using Xunit;


namespace GourmetSp.Tests
{
    public class RecipeBookTest
    {
        // lácteos, carnes, legumbres, vegetales, frutas, cereales.
        private static List<string> _foodGroups = new List<string> { "dairies", "meets", "vegetables", "fruits", "legumes", "cereals" };
        private static List<string> _units = new List<string> { "grams", "kilos", "c/n", "unit" };
        private Dictionary<Food, double> ingredients;
        private Food _food1, _food2, _food3, _food4;
        private Recipe _recipe1, _recipe2;


        [Fact]
        public void AmountRecipeTest()
        {

            // <- Food >
            Food _food1 = new Food(55, _units[3], _foodGroups[2]);
            Food _food2 = new Food(135, _units[3], _foodGroups[3]);
            Food _food3 = new Food(200, _units[0], _foodGroups[5]);
            Food _food4 = new Food(180, _units[3], _foodGroups[0]);


            // < Recipes >
            // Recipe1
            Dictionary<Food, double> _ingredients = new Dictionary<Food, double>();
            _ingredients.Add(_food1, 1);
            _ingredients.Add(_food2, 1);

            Recipe _recipe1 = new Recipe("recipe1", _ingredients);


            // Recipe2
            Dictionary<Food, double> _ingredientsRecipe2 = new Dictionary<Food, double>();
            _ingredientsRecipe2.Add(_food3, 1);
            _ingredientsRecipe2.Add(_food4, 3);

            Recipe _recipe2 = new Recipe("recipe2", _ingredientsRecipe2);


            // < RecipeBooks >
            List<Recipe> _recipes = new List<Recipe>();
            _recipes.Add(_recipe1);
            _recipes.Add(_recipe2);

            RecipeBook _someRecipeBook = new RecipeBook(_recipes);

            var result = _someRecipeBook.amountRecipes();

            Assert.Equal(2,result);
        }

        [Fact]
        public void AmountRecipeNullTest()
        {
            RecipeBook _someRecipeBook = new RecipeBook();

            var result = _someRecipeBook.amountRecipes();

            Assert.Equal(0, result);
        }
    }
}
