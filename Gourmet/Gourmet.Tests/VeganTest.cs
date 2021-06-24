using System;
using System.Collections.Generic;
using Xunit;

namespace GourmetSp.Tests
{
    public class VeganTest
    {
        private List<Ingredient> _ingredientsRecipe = new List<Ingredient>();
        private Recipe _recipe;
        private Food
            _food1 = new Food(23, Unit.unit, FoodGroup.Vegetables, "food1"),
            _food2 = new Food(45, Unit.kilos, FoodGroup.Legumes, "food2"),
            _food3 = new Food(210, Unit.kilos, FoodGroup.Dairies, "food3"),
            _food4 = new Food(176, Unit.kilos, FoodGroup.Meets, "food4");

        [Fact]
        public void isSuitableVegan()
        {
            Vegan vegan = new Vegan();

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

            bool result = vegan.IsAccording(this._recipe);

            Assert.True(result);
        }

        [Fact]
        public void isNotSuitableVegan()
        {
            Vegan vegan = new Vegan();

            // Creating ingredients
            Ingredient ingredients1 = new Ingredient();
            ingredients1.Food = this._food3;
            ingredients1.Amount = 1;

            Ingredient ingredients2 = new Ingredient();
            ingredients2.Food = this._food4;
            ingredients2.Amount = 1;

            // Adding ingredients to recipe
            this._ingredientsRecipe.Add(ingredients1);
            this._ingredientsRecipe.Add(ingredients2);

            this._recipe = new Recipe("recipe1", _ingredientsRecipe);

            bool result = vegan.IsAccording(this._recipe);

            Assert.False(result);
        }
    }
}
