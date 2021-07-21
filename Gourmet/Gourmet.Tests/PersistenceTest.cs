using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
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
            var randomName = Guid.NewGuid().ToString();

            // Act
            DbContext.RecipeBooks.Add(new RecipeBook { RecipeBookTitle = randomName });
            DbContext.SaveChanges();

            // Assert
            Assert.Equal(1, await DbContext.RecipeBooks.Where(x => randomName.Equals(x.RecipeBookTitle)).CountAsync());
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

    }
}
