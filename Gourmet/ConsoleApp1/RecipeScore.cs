using System;
using System.Collections.Generic;
using System.Text;

namespace GourmetSp
{
    public class RecipeScore
    {
        public Recipe Recipe { get; set; }
        public double Score { get; set; }
        public RecipeScore(Recipe recipe, double score)
        {
            Recipe = recipe;
            this.Score = score;
        }
        public RecipeScore() 
        {
            this.Recipe = new Recipe();
            this.Score = 0;
        }

    }
}
