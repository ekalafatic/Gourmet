using System;
using System.Collections.Generic;
using Xunit;


namespace GourmetSp.Tests
{
    public class RecipeBookTest
    {
        // lácteos, carnes, legumbres, vegetales, frutas, cereales.
        private static List<string> foodGroups = new List<string> { "dairies", "meets", "vegetables", "fruits", "legumes", "cereals" };
        private static List<string> units = new List<string> { "grams", "kilos", "c/n", "unit" };
        private Dictionary<Food, double> ingredientsRecipe1, ingredientsRecipe2;
        private Food
            food1 = new Food(55, units[3], foodGroups[2], "food1"),
            food2 = new Food(135, units[3], foodGroups[3], "food2"),
            food3 = new Food(200, units[0], foodGroups[5], "food3"),
            food4 = new Food(180, units[3], foodGroups[0], "food4");
        private Recipe recipe1, recipe2;


        [Fact]
        public void AmountRecipeTest()
        {

            // < Recipes >
            // Recipe1
            this.ingredientsRecipe1 = new Dictionary<Food, double>();
            ingredientsRecipe1.Add(food1, 1);
            ingredientsRecipe1.Add(food2, 1);

            this.recipe1 = new Recipe("recipe1", ingredientsRecipe1);


            // Recipe2
            this.ingredientsRecipe2 = new Dictionary<Food, double>();
            ingredientsRecipe2.Add(food3, 1);
            ingredientsRecipe2.Add(food4, 3);

            this.recipe2 = new Recipe("recipe2", ingredientsRecipe2);


            // < RecipeBooks >
            List<Recipe> _recipes = new List<Recipe>();
            _recipes.Add(recipe1);
            _recipes.Add(recipe2);

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
