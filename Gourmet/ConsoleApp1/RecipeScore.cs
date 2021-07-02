using System;
using System.Collections.Generic;
using System.Text;

namespace GourmetSp
{
    public class RecipeScore
    {
        public RecipeScore(Recipe recipe, double score)
        {
            Recipe = recipe;
            this.score = score;
        }
        public RecipeScore() 
        {
            this.Recipe = new Recipe();
            this.score = 0;
        }

        public Recipe Recipe { get; set; }
        public double score { get; set; }

    }
}
