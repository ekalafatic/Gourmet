using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GourmetSp
{
    public class Ranking
    {
        private readonly List<RecipeScore> _recipeScores;
        public string Name { get; set; }

        public Ranking(List<RecipeScore> recipeScores, string name)
        {
            this._recipeScores = recipeScores;
            this.Name = name;
        }

        public Ranking()
        {
            this._recipeScores = new List<RecipeScore>();
            this.Name = "";
        }
        
        public List<RecipeScore> GetRecipeScores()
        {
            return new List<RecipeScore>(this._recipeScores);
        }

        public bool RecipeExists(Recipe recipe)
        {
            return this._recipeScores.Any(x => x.Recipe.Equals(recipe));
        }

        public void AddPoints(Recipe recipe)
        {
            var recipeScoreTemp = this._recipeScores.Find(x => x.Recipe.Equals(recipe));

            if (recipeScoreTemp == null)
            {
                RecipeScore recipeScore = new RecipeScore(recipe, 10);
                this._recipeScores.Add(recipeScore);
            }
            else
            {
                recipeScoreTemp.Score += 10;
            }
        }
    }
}
