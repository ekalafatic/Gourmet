using System;
using System.Collections.Generic;
using System.Text;

namespace GourmetSp
{
    public class User : ISuscriber
    {
        public string Email { get; set; }
        public IProfile Profile { get; set; }
        private RecipeBook _recipeBook;
        public bool MailSended { get; set; }
        public bool notificationsActivated { get; set; }

        // sacar recipeBook, hacer la suscripción a través de una clase aparte UserSuscriber
        public User(string email, IProfile profile, RecipeBook recipeBook)
        {
            Email = email;
            this.Profile = profile;
            _recipeBook = recipeBook;
            _recipeBook.Subscribe(this);
            this.MailSended = false;
            this.notificationsActivated = true;
        }

        // Se recibe actualización
        public void Update(Recipe recipe)
        {
            if (this.Profile.IsAccording(recipe) && this.notificationsActivated) {
                this.MailSended = true;
            } 
            else
            {
                this.MailSended = false;
            }
        }
    }
}
