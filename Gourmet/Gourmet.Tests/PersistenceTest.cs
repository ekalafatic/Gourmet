﻿using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;


namespace GourmetSp.Tests
{
    public class PersistenceTest
    {
        private readonly GourmetContext DbContext;
        private readonly SqliteConnection Connection;

        public PersistenceTest()
        {
            Connection = new SqliteConnection(@"Data Source = c:\gourmet.db");
            Connection.Open();

            var options = new DbContextOptionsBuilder<GourmetContext>()
                    .UseSqlite(Connection)
                    .Options;

            DbContext = new GourmetContext(options);
            DbContext.Database.EnsureCreated();

        }

        [Fact]
        public async void Can_Persist_Foods()
        {
            // Arrange
            var randomName = Guid.NewGuid().ToString();

            // Act
            DbContext.Foods.Add(new Food { Name = randomName });
            DbContext.SaveChanges();

            // Assert
            Assert.Equal(1, await DbContext.Foods.Where(x => randomName.Equals(x.Name)).CountAsync());
        }

        [Fact]
        public async void Can_Persist_Recipe_Create()
        {
            // Arrange
            var randomName = Guid.NewGuid().ToString();

            // Act
            DbContext.Recipes.Add(new Recipe { RecipeTitle = randomName });
            DbContext.SaveChanges();

            // Assert
            Assert.Equal(1, await DbContext.Recipes.Where(x => randomName.Equals(x.RecipeTitle)).CountAsync());
        }

        [Fact]
        public async void Can_Persist_RecipeBook_Create()
        {
            // Arrange
            var recipeBookName = "Italian recipes";
            var recipeBookName2 = "French recipes";

            // Act
            DbContext.RecipeBooks.Add(new RecipeBook { RecipeBookTitle = recipeBookName });
            DbContext.RecipeBooks.Add(new RecipeBook { RecipeBookTitle = recipeBookName2 });
            DbContext.SaveChanges();

            // Assert
            Assert.Equal(1, await DbContext.RecipeBooks.Where(x => recipeBookName.Equals(x.RecipeBookTitle)).CountAsync());
        }

        [Fact]
        public async void Can_Persist_RecipeBook_Update()
        {
            // Arrange
            var randomName = Guid.NewGuid().ToString();
            var recipeBookRandomName = Guid.NewGuid().ToString();

            // Act
            DbContext.RecipeBooks.Add(new RecipeBook { RecipeBookTitle = randomName });
            DbContext.SaveChanges();

            RecipeBook r = DbContext.RecipeBooks.First(i => i.RecipeBookTitle == randomName);
            r.RecipeBookTitle = recipeBookRandomName;
            DbContext.SaveChanges();

            // Assert
            Assert.Equal(1, await DbContext.RecipeBooks.Where(x => recipeBookRandomName.Equals(x.RecipeBookTitle)).CountAsync());
        }

        [Fact]
        public async void Can_Persist_RecipeBook_Read()
        {
            // Arrange
            var randomName = Guid.NewGuid().ToString();

            // Act
            RecipeBook r = DbContext.RecipeBooks.First();

            // Assert
            Assert.Equal(1, await DbContext.RecipeBooks.Where(x => x.Equals(r)).CountAsync());
        }

        [Fact]
        public async void Can_Persist_RecipeBook_Delete()
        {
            // Arrange
            var recipeBookName = "DeleteTest";

            // Act
            DbContext.RecipeBooks.Add(new RecipeBook { RecipeBookTitle = recipeBookName });
            DbContext.SaveChanges();
            RecipeBook r = DbContext.RecipeBooks.First(i => i.RecipeBookTitle == recipeBookName);
            //DbContext.RecipeBooks.Find(1);
            DbContext.RecipeBooks.Remove(r);
            DbContext.SaveChanges();

            // Assert
            //Assert.Null(DbContext.RecipeBooks.Where(r => r.RecipeBookId==1));
            Assert.Equal(0, await DbContext.RecipeBooks.Where(r => r.RecipeBookTitle == recipeBookName).CountAsync());
        }

        [Fact]
        public async void CreateAGoodRecipeBook()
        {
            List<Ingredient> _ingredientsRecipe = new List<Ingredient>();
            List<Ingredient> _ingredientsRecipe2 = new List<Ingredient>();
            Recipe recipe, recipe2;
            Food
            _food1 = new Food(30, Unit.unit, FoodGroup.Vegetables, "Potato"),
            _food2 = new Food(45, Unit.kilos, FoodGroup.Legumes, "Vetch"),
            _food3 = new Food(123, Unit.grams, FoodGroup.Cereals, "Rice"),
            _food4 = new Food(100, Unit.grams, FoodGroup.Cereals, "Bread crumbs"),
            _food5 = new Food(20, Unit.unit, FoodGroup.Dairies, "Egg");

            // Creating ingredients
            Ingredient ingredients1 = new Ingredient();
            ingredients1.Food = _food1;
            ingredients1.Amount = 1;

            Ingredient ingredients2 = new Ingredient();
            ingredients2.Food = _food2;
            ingredients2.Amount = 1;

            Ingredient ingredients3 = new Ingredient();
            ingredients3.Food = _food3;
            ingredients3.Amount = 2;

            Ingredient ingredients4 = new Ingredient();
            ingredients4.Food = _food4;
            ingredients4.Amount = 5;

            Ingredient ingredients5 = new Ingredient();
            ingredients5.Food = _food5;
            ingredients5.Amount = 2;

            // Adding ingredients to recipe
            _ingredientsRecipe.Add(ingredients1);
            _ingredientsRecipe.Add(ingredients2);
            _ingredientsRecipe.Add(ingredients3);

            _ingredientsRecipe2.Add(ingredients4);
            _ingredientsRecipe2.Add(ingredients5);

            recipe = new Recipe("German noodles", _ingredientsRecipe);

            recipe2 = new Recipe("Knödel", _ingredientsRecipe2);

            // Arrange
            var recipeBookName = "German recipes";
            List<Recipe> recipes = new List<Recipe>();
            recipes.Add(recipe);
            recipes.Add(recipe2);

            RecipeBook recipeBook = new RecipeBook(recipeBookName, recipes);

            // Act
            DbContext.RecipeBooks.Add(recipeBook);
            DbContext.SaveChanges();

            // Assert
            Assert.Equal(1, await DbContext.RecipeBooks.Where(x => recipeBookName.Equals(x.RecipeBookTitle)).CountAsync());

        }

    }
}
