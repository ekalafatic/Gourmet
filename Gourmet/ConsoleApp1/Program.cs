using System;
using System.Collections.Generic;

namespace GourmetSp
{
    class Program
    {
        static void Main(string[] args)
        {
            
            // lácteos, carnes, legumbres, vegetales, frutas, cereales.
            List<string> foodGroups = new List<string> { "dairies", "meets", "vegetables", "fruits", "legumes", "cereals"};
            List<string> units = new List<string> { "grams", "kilos", "c/n", "unit"};
            
            // < Food >
            Food carrot = new Food(55, units[3], foodGroups[2]);
            Food banana = new Food(135, units[3], foodGroups[3]);
            Food flour = new Food(200, units[0], foodGroups[5]);
            Food egg = new Food(180, units[3], foodGroups[0]);


            // < Recipes >
            // Thai Salad
            Dictionary<Food, double> ingredientsThaiSalad = new Dictionary<Food, double>();
            ingredientsThaiSalad.Add(carrot,1);
            ingredientsThaiSalad.Add(banana, 1);

            Recipe thaiSalad = new Recipe("Thai Rice Noodle Salad", ingredientsThaiSalad);

            Console.WriteLine("Amount Ingredients of Thai Salad: " + thaiSalad.amountByIngredients.Count);
   
            // Bread
            Dictionary<Food, double> ingredientsBread = new Dictionary<Food, double>();
            ingredientsBread.Add(flour, 1);
            ingredientsBread.Add(egg, 3);

            Recipe bread = new Recipe("Bread", ingredientsBread);


            // < RecipeBooks >
            List<Recipe> recipes = new List<Recipe>();
            recipes.Add(thaiSalad);
            recipes.Add(bread);

            RecipeBook someRecipeBook = new RecipeBook(recipes);

            Console.WriteLine("Amount recipes in Asian RecipeBook: " + someRecipeBook.amountRecipes());


        }
    }
}
