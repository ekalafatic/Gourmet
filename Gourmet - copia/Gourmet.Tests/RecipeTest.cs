using System;
using System.Collections.Generic;
using Xunit;


namespace GourmetSp.Tests
{
    public class RecipeTest
    {
        private List<Ingredient> _ingredientsRecipe = new List<Ingredient>();
        private Recipe recipe;
        private Food
            _food1 = new Food(23, Unit.unit, FoodGroup.Vegetables, "food1"),
            _food2 = new Food(45, Unit.kilos, FoodGroup.Legumes, "food2"),
            _food3 = new Food(123, Unit.grams, FoodGroup.Cereals, "food3");

        [Fact]
        public void AmountIngredientsTest()
        {
            // Creating ingredients
            Ingredient ingredients1 = new Ingredient();
            ingredients1.Food = this._food1;
            ingredients1.Amount = 1;

            Ingredient ingredients2 = new Ingredient();
            ingredients2.Food = this._food2;
            ingredients2.Amount = 1;

            Ingredient ingredients3 = new Ingredient();
            ingredients3.Food = this._food3;
            ingredients3.Amount = 2;

            // Adding ingredients to recipe
            this._ingredientsRecipe.Add(ingredients1);
            this._ingredientsRecipe.Add(ingredients2);
            this._ingredientsRecipe.Add(ingredients3);

            this.recipe = new Recipe("recipe1", _ingredientsRecipe);

            var result = recipe.AmountIngredients();

            Assert.Equal(3, result);
        }


        [Fact]
        public void amountIngredientsNullTest()
        {
            this.recipe = new Recipe();

            var result = this.recipe.AmountIngredients();

            Assert.Equal(0, result);
        }

        [Fact]
        public void amountCalories()
        {

            // Creating ingredients
            Ingredient ingredients1 = new Ingredient();
            ingredients1.Food = this._food1;
            ingredients1.Amount = 1;

            Ingredient ingredients2 = new Ingredient();
            ingredients2.Food = this._food2;
            ingredients2.Amount = 1;

            Ingredient ingredients3 = new Ingredient();
            ingredients3.Food = this._food3;
            ingredients3.Amount = 5;

            // Adding ingredients to recipe
            this._ingredientsRecipe.Add(ingredients1);
            this._ingredientsRecipe.Add(ingredients2);
            this._ingredientsRecipe.Add(ingredients3);

            this.recipe = new Recipe("recipe1", _ingredientsRecipe);

            var result = recipe.CaloriesRecipe();

            Assert.Equal(683, result);
        }

        [Fact]
        public void amountCaloriesNullTest()
        {
            this.recipe = new Recipe();

            var result = this.recipe.CaloriesRecipe();

            Assert.Equal(0, result);
        }

        [Fact]
        public void foodNameTest()
        {
            // Creating ingredients
            Ingredient ingredients1 = new Ingredient();
            ingredients1.Food = this._food1;
            ingredients1.Amount = 1;

            Ingredient ingredients2 = new Ingredient();
            ingredients2.Food = this._food2;
            ingredients2.Amount = 1;

            // Adding ingredients to recipe
            this._ingredientsRecipe.Add(ingredients1);
            this._ingredientsRecipe.Add(ingredients2);

            this.recipe = new Recipe("recipe1", _ingredientsRecipe);

            bool result = recipe.HasFood(this._food1);

            Assert.True(result);
        }

        [Fact]
        public void foodNameFalseTest()
        {
            Food food4 = new Food(143, Unit.unit, FoodGroup.Fruits, "food4");

            this.recipe = new Recipe("recipe1", _ingredientsRecipe);

            bool result = this.recipe.HasFood(food4);
           
            Assert.False(result);
        }


        [Fact]
        public void groupTrueTest()
        {
            // Creating ingredients
            Ingredient ingredients1 = new Ingredient();
            ingredients1.Food = this._food1;
            ingredients1.Amount = 1;

            Ingredient ingredients2 = new Ingredient();
            ingredients2.Food = this._food2;
            ingredients2.Amount = 1;

            // Adding ingredients to recipe
            this._ingredientsRecipe.Add(ingredients1);
            this._ingredientsRecipe.Add(ingredients2);

            this.recipe = new Recipe("recipe1", _ingredientsRecipe);

            bool result = recipe.HasFoodGroup(FoodGroup.Vegetables);

            Assert.True(result);
        }

        [Fact]
        public void groupFalseTest()
        {
            // Creating ingredients
            Ingredient ingredients1 = new Ingredient();
            ingredients1.Food = this._food1;
            ingredients1.Amount = 1;

            Ingredient ingredients2 = new Ingredient();
            ingredients2.Food = this._food2;
            ingredients2.Amount = 1;

            // Adding ingredients to recipe
            this._ingredientsRecipe.Add(ingredients1);
            this._ingredientsRecipe.Add(ingredients2);

            this.recipe = new Recipe("recipe1", _ingredientsRecipe);

            bool result = recipe.HasFoodGroup(FoodGroup.Meets);

            Assert.False(result);
        }

    }
}
