using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
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
            var recipeBookName = "CreateTest";

            // Act
            DbContext.RecipeBooks.Add(new RecipeBook { RecipeBookTitle = recipeBookName });
            DbContext.SaveChanges();

            // Assert
            Assert.Equal(1, await DbContext.RecipeBooks.Where(x => recipeBookName.Equals(x.RecipeBookTitle)).CountAsync());
        }

        [Fact]
        public async void Can_Persist_RecipeBook_Update()
        {
            // Arrange
            var randomName = Guid.NewGuid().ToString();
            var recipeBookName = "UpdateTest";

            // Act
            DbContext.RecipeBooks.Add(new RecipeBook { RecipeBookTitle = randomName });
            DbContext.SaveChanges();

            RecipeBook r = DbContext.RecipeBooks.First(i => i.RecipeBookTitle == randomName);
            r.RecipeBookTitle = recipeBookName;
            DbContext.SaveChanges();

            // Assert
            Assert.Equal(1, await DbContext.RecipeBooks.Where(x => recipeBookName.Equals(x.RecipeBookTitle)).CountAsync());
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
