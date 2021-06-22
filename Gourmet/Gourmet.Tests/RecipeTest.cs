using System;
using System.Collections.Generic;
using Xunit;


namespace GourmetSp.Tests
{
    public class RecipeTest
    {
        //private Dictionary<Food, double> ingredients;
        private List<Ingredient> _ingredientsRecipe = new List<Ingredient>();
        private Recipe recipe;
        private Food 
            _food1 = new Food(23, Unit.unit, FoodGroup.Vegetables, "food1"), 
            _food2 = new Food(45, Unit.kilos, FoodGroup.Legumes, "food2"),
            _food3 = new Food(123, Unit.grams, FoodGroup.Cereals, "food3"),
            _food4 = new Food(250, Unit.kilos, FoodGroup.Meets, "food4"),
            _food5 = new Food(210, Unit.kilos, FoodGroup.Dairies, "food5"),
            _food6 = new Food(176, Unit.kilos, FoodGroup.Meets, "food6"); // 200 cal - food1 = 177 cal

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

        // Entrega2
        [Fact]
        public void isSuitableCeliac()
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

            this.recipe = new Recipe("recipe", _ingredientsRecipe);

            bool result = recipe.isAccording(Profile.Celiac);

            Assert.True(result);
        }

        [Fact]
        public void isNotSuitableCeliac()
        {
            // Creating ingredients
            Ingredient ingredients1 = new Ingredient();
            ingredients1.Food = this._food5;
            ingredients1.Amount = 1;

            Ingredient ingredients2 = new Ingredient();
            ingredients2.Food = this._food3;
            ingredients2.Amount = 1;

            // Adding ingredients to recipe
            this._ingredientsRecipe.Add(ingredients1);
            this._ingredientsRecipe.Add(ingredients2);

            this.recipe = new Recipe("recipe1", _ingredientsRecipe);

            bool result = recipe.isAccording(Profile.Celiac);

            Assert.False(result);
        }

        [Fact]
        public void isSuitableVegetarian()
        {
            // Creating ingredients
            Ingredient ingredients1 = new Ingredient();
            ingredients1.Food = this._food2;
            ingredients1.Amount = 1;

            Ingredient ingredients2 = new Ingredient();
            ingredients2.Food = this._food3;
            ingredients2.Amount = 1;

            // Adding ingredients to recipe
            this._ingredientsRecipe.Add(ingredients1);
            this._ingredientsRecipe.Add(ingredients2);

            this.recipe = new Recipe("recipe1", _ingredientsRecipe);

            bool result = recipe.isAccording(Profile.Vegetarian);

            Assert.True(result);
        }

        [Fact]
        public void isNotSuitableVegetarian()
        {
            // Creating ingredients
            Ingredient ingredients1 = new Ingredient();
            ingredients1.Food = this._food4;
            ingredients1.Amount = 1;

            Ingredient ingredients2 = new Ingredient();
            ingredients2.Food = this._food5;
            ingredients2.Amount = 1;

            // Adding ingredients to recipe
            this._ingredientsRecipe.Add(ingredients1);
            this._ingredientsRecipe.Add(ingredients2);

            this.recipe = new Recipe("recipe1", _ingredientsRecipe);

            bool result = recipe.isAccording(Profile.Vegetarian);

            Assert.False(result);
        }

        [Fact]
        public void isSuitableVegan()
        {
            // Creating ingredients
            Ingredient ingredients1 = new Ingredient();
            ingredients1.Food = this._food2;
            ingredients1.Amount = 1;

            Ingredient ingredients2 = new Ingredient();
            ingredients2.Food = this._food1;
            ingredients2.Amount = 1;

            // Adding ingredients to recipe
            this._ingredientsRecipe.Add(ingredients1);
            this._ingredientsRecipe.Add(ingredients2);

            this.recipe = new Recipe("recipe1", _ingredientsRecipe);

            bool result = recipe.isAccording(Profile.Vegan);

            Assert.True(result);
        }

        [Fact]
        public void isNotSuitableVegan()
        {
            // Creating ingredients
            Ingredient ingredients1 = new Ingredient();
            ingredients1.Food = this._food4;
            ingredients1.Amount = 1;

            Ingredient ingredients2 = new Ingredient();
            ingredients2.Food = this._food5;
            ingredients2.Amount = 1;

            // Adding ingredients to recipe
            this._ingredientsRecipe.Add(ingredients1);
            this._ingredientsRecipe.Add(ingredients2);

            this.recipe = new Recipe("recipe1", _ingredientsRecipe);

            bool result = recipe.isAccording(Profile.Vegan);

            Assert.False(result);
        }

        [Fact]
        public void isSuitableCarnivores()
        {
            // Creating ingredients
            Ingredient ingredients1 = new Ingredient();
            ingredients1.Food = this._food1;
            ingredients1.Amount = 1;

            Ingredient ingredients2 = new Ingredient();
            ingredients2.Food = this._food4;
            ingredients2.Amount = 1;

            // Adding ingredients to recipe
            this._ingredientsRecipe.Add(ingredients1);
            this._ingredientsRecipe.Add(ingredients2);

            this.recipe = new Recipe("recipe1", _ingredientsRecipe);

            bool result = recipe.isAccording(Profile.Carnivorous);

            Assert.True(result);
        }

        [Fact]
        public void isNotSuitableCarnivores()
        {
            // Creating ingredients
            Ingredient ingredients1 = new Ingredient();
            ingredients1.Food = this._food1;
            ingredients1.Amount = 1;

            Ingredient ingredients2 = new Ingredient();
            ingredients2.Food = this._food6;
            ingredients2.Amount = 1;

            // _food1 calories + _food6 calories = 199 cal

            // Adding ingredients to recipe
            this._ingredientsRecipe.Add(ingredients1);
            this._ingredientsRecipe.Add(ingredients2);

            this.recipe = new Recipe("recipe1", _ingredientsRecipe);

            bool result = recipe.isAccording(Profile.Carnivorous);

            Assert.False(result);
        }
    }
}
