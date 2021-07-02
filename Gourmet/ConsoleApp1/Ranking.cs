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
            List<RecipeScore> recipeScoresCopy = new List<RecipeScore>();
            recipeScoresCopy = this.recipeScores;

            return recipeScoresCopy;
        }

        public bool RecipeExists(Recipe recipe)
        {
            var recipeScoreTemp = this.recipeScores.Find(x => x.Recipe.Equals(recipe));
            
            if (recipeScoreTemp == null) return false;

            return true;
        }

        public void AddPoints(Recipe recipe)
        {
            var recipeScoreTemp = this.recipeScores.Find(x => x.Recipe.Equals(recipe));

            if (recipeScoreTemp == null)
            {
                RecipeScore recipeScore = new RecipeScore(recipe, 10);
                this.recipeScores.Add(recipeScore);
            }
            else
            {
                recipeScoreTemp.score += 10;
            }
        }
    }
}
