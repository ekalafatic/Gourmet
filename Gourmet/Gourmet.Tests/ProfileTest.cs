using System;
using System.Collections.Generic;
using Xunit;


namespace GourmetSp.Tests
{
    public class ProfileTest
    {
        private List<Ingredient> _ingredientsRecipe = new List<Ingredient>();
        private Recipe _recipe;
        private Profile _profile;
        private Food
            _food1 = new Food(23, Unit.unit, FoodGroup.Vegetables, "food1"),
            _food2 = new Food(45, Unit.kilos, FoodGroup.Legumes, "food2"),
            _food3 = new Food(123, Unit.grams, FoodGroup.Cereals, "food3"),
            _food4 = new Food(250, Unit.kilos, FoodGroup.Meets, "food4"),
            _food5 = new Food(210, Unit.kilos, FoodGroup.Dairies, "food5"),
            _food6 = new Food(176, Unit.kilos, FoodGroup.Meets, "food6"); // 200 cal - food1 = 177 cal

        [Fact]
        public void isSuitableCeliac()
        {
            this._profile = new Profile(ProfileType.Celiac);

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

            this._recipe = new Recipe("recipe", _ingredientsRecipe);

            bool result = this._profile.isAccording(this._recipe);

            Assert.True(result);
        }

        [Fact]
        public void isNotSuitableCeliac()
        {
            this._profile = new Profile(ProfileType.Celiac);

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

            this._recipe = new Recipe("recipe1", _ingredientsRecipe);

            bool result = this._profile.isAccording(this._recipe);

            Assert.False(result);
        }

        [Fact]
        public void isSuitableVegetarian()
        {
            this._profile = new Profile(ProfileType.Vegetarian);

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

            this._recipe = new Recipe("recipe1", _ingredientsRecipe);

            bool result = this._profile.isAccording(this._recipe);

            Assert.True(result);
        }

        [Fact]
        public void isNotSuitableVegetarian()
        {
            this._profile = new Profile(ProfileType.Vegetarian);

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

            this._recipe = new Recipe("recipe1", _ingredientsRecipe);

            bool result = this._profile.isAccording(this._recipe);

            Assert.False(result);
        }

        [Fact]
        public void isSuitableVegan()
        {
            this._profile = new Profile(ProfileType.Vegan);

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

            this._recipe = new Recipe("recipe1", _ingredientsRecipe);

            bool result = this._profile.isAccording(this._recipe);

            Assert.True(result);
        }

        [Fact]
        public void isNotSuitableVegan()
        {
            this._profile = new Profile(ProfileType.Vegan);

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

            this._recipe = new Recipe("recipe1", _ingredientsRecipe);

            bool result = this._profile.isAccording(this._recipe);

            Assert.False(result);
        }

        [Fact]
        public void isSuitableCarnivores()
        {
            this._profile = new Profile(ProfileType.Carnivorous);

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

            this._recipe = new Recipe("recipe1", _ingredientsRecipe);

            bool result = this._profile.isAccording(this._recipe);

            Assert.True(result);
        }

        [Fact]
        public void isNotSuitableCarnivores()
        {
            this._profile = new Profile(ProfileType.Carnivorous);

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

            this._recipe = new Recipe("recipe1", _ingredientsRecipe);

            bool result = this._profile.isAccording(this._recipe);

            Assert.False(result);
        }
    }
}
