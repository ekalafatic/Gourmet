using System;
using System.Collections.Generic;
using Xunit;

namespace GourmetSp.Tests
{
    public class SuscriberRankingTest
    {
        private List<Ingredient> _ingredientsRecipe = new List<Ingredient>();
        private Recipe _recipe;
        private Food
            _food2 = new Food(250, Unit.kilos, FoodGroup.Meets, "food2"),

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
            
            Recipe recipe2 = new Recipe("recipe2", _ingredientsRecipe);

            RecipeScore recipeScore = new RecipeScore(recipe2, 10);
            List<RecipeScore> recipeScores = new List<RecipeScore>();
            recipeScores.Add(recipeScore);

            // Se crean posibles observadores
            Ranking ranking = new Ranking(recipeScores, "Ranking de algo");

            SuscriberRanking suscriberRanking = new SuscriberRanking(ranking);

            // Se suscribe
            recipeBook.Subscribe(suscriberRanking);

            // se añade una nueva receta y debería notificar
            recipeBook.AddRecipe(recipe2);

            var result = recipeScore.score;

            Assert.Equal(20,result);
        }

        // Testing deactivated notifications
        [Fact]
        public void NotificationTest()
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

            // Subject
            RecipeBook recipeBook = new RecipeBook();

            recipeBook.AddRecipe(this._recipe);

            Recipe recipe2 = new Recipe("recipe2", _ingredientsRecipe);

            RecipeScore recipeScore = new RecipeScore(recipe2, 10);

            List<RecipeScore> recipeScores = new List<RecipeScore>();

            recipeScores.Add(recipeScore);

            // Observer
            Ranking ranking = new Ranking(recipeScores, "Ranking de algo");

            SuscriberRanking suscriberRanking = new SuscriberRanking(ranking);

            recipeBook.Subscribe(suscriberRanking);

            // Notification disabled
            suscriberRanking.NotificationsActivated = false;

            // Adding a recipe to send the notification
            recipeBook.AddRecipe(recipe2);

            var result = recipeScore.score;

            Assert.Equal(10, result);
        }
    }
}
