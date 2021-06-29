using System;
using System.Collections.Generic;
using System.Text;

namespace GourmetSp
{
    class Ranking
    {
        private readonly List<RecipeScore> recipeScores;
        public string Name { get; set; }

        public Ranking(List<RecipeScore> recipeScores, string name)
        {
            this.recipeScores = recipeScores;
            this.Name = name;
        }
        
        public List<RecipeScore> GetRecipeScores()
        {
            return this.recipeScores;
        }
    }
}
