using System;
using System.Collections.Generic;
using System.Text;

namespace GourmetSp
{
    public class RecipeBook
    {
        private readonly List<Recipe> _recipes;
        private readonly List<ISuscriber> _suscribers;

        public RecipeBook(List<Recipe> recipes)
        {
            this._recipes = recipes;
        }

        public RecipeBook() 
        {
            this._recipes = new List<Recipe>();
            this._suscribers = new List<ISuscriber>();
        }

        public void AddRecipe(Recipe recipe)
        {
            _recipes.Add(recipe);
            // Send a notification
            Notify(recipe);
        }

        public int AmountRecipes()
        {
            return _recipes.Count;
        }

        public List<Recipe> GetRecipes()
        {
            return this._recipes;
        }

        // Suscribe user
        public void Subscribe(ISuscriber suscriber)
        {
            this._suscribers.Add(suscriber);
            
        }

        public void Unsuscribe(ISuscriber suscriber)
        {
            this._suscribers.Remove(suscriber);
        }

        // Notify the observers
        public void Notify(Recipe recipe)
        {
            foreach (ISuscriber suscriber in this._suscribers)
            {
               suscriber.Update(recipe);
            }
;
        }

    }
}
