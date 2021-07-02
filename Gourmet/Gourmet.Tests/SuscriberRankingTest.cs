using System;
using System.Collections.Generic;
using Xunit;

namespace GourmetSp.Tests
{
    public class SuscriberRankingTest
    {
        private List<Ingredient> _ingredientsRecipe = new List<Ingredient>();
        private Recipe _recipe;
        private Food _food2 = new Food(250, Unit.kilos, FoodGroup.Meets, "food2");

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

            // Subject
            RecipeBook recipeBook = new RecipeBook();
            
            this._recipe = new Recipe("recipe2", _ingredientsRecipe);

            RecipeScore recipeScore = new RecipeScore(_recipe, 10);
            List<RecipeScore> recipeScores = new List<RecipeScore>();
            recipeScores.Add(recipeScore);

            // Observer
            Ranking ranking = new Ranking(recipeScores, "Ranking de algo");

            SuscriberRanking suscriberRanking = new SuscriberRanking(ranking);

            recipeBook.Subscribe(suscriberRanking);

            // Adding a recipe to send the notification
            recipeBook.AddRecipe(_recipe);

            var result = recipeScore.score;

            Assert.Equal(20,result);
        }

        [Fact]
        public void UpdateNullRecipeTest()
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

            // Subject
            RecipeBook recipeBook = new RecipeBook();

            RecipeScore recipeScore = new RecipeScore();
            List<RecipeScore> recipeScores = new List<RecipeScore>();
            recipeScores.Add(recipeScore);

            // Observers
            Ranking ranking = new Ranking(recipeScores, "Ranking de algo");

            SuscriberRanking suscriberRanking = new SuscriberRanking(ranking);

            recipeBook.Subscribe(suscriberRanking);

            // Adding a recipe to send the notification that isn't in RecipeScores
            this._recipe = new Recipe("recipe2", _ingredientsRecipe);
            recipeBook.AddRecipe(_recipe);

            var result = ranking.RecipeExists(this._recipe);

            Assert.True(result);
        }


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

            // Subject
            RecipeBook recipeBook = new RecipeBook();

            this._recipe = new Recipe("recipe2", _ingredientsRecipe);

            RecipeScore recipeScore = new RecipeScore(_recipe, 10);

            List<RecipeScore> recipeScores = new List<RecipeScore>();

            recipeScores.Add(recipeScore);

            // Observer
            Ranking ranking = new Ranking(recipeScores, "Ranking de algo");

            SuscriberRanking suscriberRanking = new SuscriberRanking(ranking);

            recipeBook.Subscribe(suscriberRanking);

            // Notification disabled
            suscriberRanking.NotificationsActivated = false;

            // Adding a recipe to send the notification
            recipeBook.AddRecipe(_recipe);

            var result = recipeScore.score;

            Assert.Equal(10, result);
        }
    }
}
