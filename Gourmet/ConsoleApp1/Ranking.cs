using System;
using System.Collections.Generic;
using System.Text;

namespace GourmetSp
{
    public class Ranking
    {
        private readonly List<RecipeScore> recipeScores;
        public string Name { get; set; }

        public Ranking(List<RecipeScore> recipeScores, string name)
        {
            this.recipeScores = recipeScores;
            this.Name = name;
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
    }
}
