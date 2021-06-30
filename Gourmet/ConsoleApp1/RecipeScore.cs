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

        public Recipe Recipe { get; set; }
        public double score { get; set; }

    }
}
