using System;
using System.Collections.Generic;
using Xunit;

namespace GourmetSp.Tests
{
    public class UserTest
    {
        private List<Ingredient> _ingredientsRecipe = new List<Ingredient>();
        private Recipe _recipe;
        private Food
            _food1 = new Food(23, Unit.unit, FoodGroup.Vegetables, "food1"),
            _food2 = new Food(250, Unit.kilos, FoodGroup.Meets, "food2"),
            _food3 = new Food(176, Unit.kilos, FoodGroup.Meets, "food3"); // 200 cal - food1 = 177 cal

        [Fact]
        public void UpdateTest()
        {

            Carnivorous carnivorous = new Carnivorous();

            // Creating ingredients
            Ingredient ingredients1 = new Ingredient();
            ingredients1.Food = this._food2;
            ingredients1.Amount = 1;

            Ingredient ingredients2 = new Ingredient();
            ingredients2.Food = this._food2;
            ingredients2.Amount = 1;

            // Adding ingredients to recipe
            this._ingredientsRecipe.Add(ingredients1);
            this._ingredientsRecipe.Add(ingredients2);
            
            this._recipe = new Recipe("recipe1", _ingredientsRecipe);

            // Se crea el sujeto
            RecipeBook recipeBook = new RecipeBook();
            recipeBook.AddRecipe(this._recipe);

            string email = "ekalafatic@hexacta.com";
            // Se crean posibles observadores
            User user1 = new User(email, carnivorous, recipeBook);

            // se añade una nueva receta y debería notificar
            Recipe recipe2 = new Recipe("recipe2", _ingredientsRecipe);

            recipeBook.AddRecipe(recipe2);

            Console.WriteLine("PROBANDO");

            var result = user1.MailSended;

            Assert.True(result);
            


        }
    }
}
