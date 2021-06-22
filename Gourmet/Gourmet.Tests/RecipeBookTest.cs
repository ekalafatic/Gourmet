using System;
using System.Collections.Generic;
using Xunit;


namespace GourmetSp.Tests
{
    public class RecipeBookTest
    {
        private List<Ingredient> _ingredientsRecipe1 = new List<Ingredient>(), _ingredientsRecipe2 = new List<Ingredient>();
        private Food
            _food1 = new Food(55, Unit.grams, FoodGroup.Fruits, "food1"),
            _food2 = new Food(135, Unit.unit, FoodGroup.Legumes, "food2"),
            _food3 = new Food(200, Unit.kilos, FoodGroup.Vegetables, "food3"),
            _food4 = new Food(180, Unit.grams, FoodGroup.Cereals, "food4");
        private Recipe recipe1, recipe2;


        [Fact]
        public void AmountRecipeTest()
        {
            // Creating ingredients
            Ingredient ingredients1 = new Ingredient();
            ingredients1.Food = this._food1;
            ingredients1.Amount = 1;

            Ingredient ingredients2 = new Ingredient();
            ingredients1.Food = this._food2;
            ingredients1.Amount = 1;

            Ingredient ingredients3 = new Ingredient();
            ingredients1.Food = this._food3;
            ingredients1.Amount = 2;

            Ingredient ingredients4 = new Ingredient();
            ingredients1.Food = this._food4;
            ingredients1.Amount = 3;

            // Adding ingredients to recipes
            // Recipe1
            this._ingredientsRecipe1.Add(ingredients1);
            this._ingredientsRecipe1.Add(ingredients2);

            this.recipe1 = new Recipe("recipe1", _ingredientsRecipe1);


            // Recipe2
            this._ingredientsRecipe2.Add(ingredients3);
            this._ingredientsRecipe2.Add(ingredients4);

            this.recipe2 = new Recipe("recipe2", _ingredientsRecipe2);


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
