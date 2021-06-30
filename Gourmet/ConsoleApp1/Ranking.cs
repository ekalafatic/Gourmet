using System;
using System.Collections.Generic;
using System.Text;

namespace GourmetSp
{
    public class Ranking : ISuscriber
    {
        private readonly List<RecipeScore> recipeScores;
        public string Name { get; set; }
        public bool NotificationsActivated { get; set; }
        private RecipeBook recipeBook;

        public Ranking(List<RecipeScore> recipeScores, string name, RecipeBook recipeBook)
        {
            this.recipeScores = recipeScores;
            this.Name = name;
            this.NotificationsActivated = true;
            this.recipeBook = recipeBook;
            recipeBook.Subscribe(this);
        }

        public Ranking()
        {
            this.recipeScores = new List<RecipeScore>();
            this.Name = "";
        }
        
        public List<RecipeScore> GetRecipeScores()
        {
            return this.recipeScores;
        }

        public void AddPoints(Recipe recipe)
        {
            if(this.recipeScores != null) this.recipeScores.Find(x => x.Recipe == recipe).score += 10;
        }

        public void Update(Recipe recipe)
        {
            if(this.NotificationsActivated) AddPoints(recipe);
        }
    }
}
