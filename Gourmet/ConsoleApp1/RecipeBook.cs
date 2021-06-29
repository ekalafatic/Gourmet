using System;
using System.Collections.Generic;
using System.Text;

namespace GourmetSp
{
    public class RecipeBook
    {
        private readonly List<Recipe> _recipes;
        private readonly List<IUser> _suscribedUsers;

        public RecipeBook(List<Recipe> recipes)
        {
            this._recipes = recipes;
        }

        public RecipeBook() 
        {
            this._recipes = new List<Recipe>();
            this._suscribedUsers = new List<IUser>();
        }

        public void AddRecipe(Recipe recipe)
        {
            _recipes.Add(recipe);
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
        public void Subscribe(IUser suscribedUser)
        {
            this._suscribedUsers.Add(suscribedUser);
        }

        public void Unsuscribe(IUser suscribedUser)
        {
            this._suscribedUsers.Remove(suscribedUser);
        }

        // Notify the observers
        public void Notify(Recipe recipe)
        {
            foreach (IUser suscribedUser in this._suscribedUsers)
            {
               suscribedUser.Update(recipe);
            }
;
        }

    }
}
