using System;
using System.Collections.Generic;
using System.Text;

namespace GourmetSp
{
    public class User : IUser
    {
        public string Email { get; set; }
        public IProfile Profile { get; set; }
        private RecipeBook _recipeBook;
        public bool MailSended { get; set; }

        public User(string email, IProfile profile, RecipeBook recipeBook)
        {
            Email = email;
            this.Profile = profile;
            _recipeBook = recipeBook;
            _recipeBook.Subscribe(this);
            this.MailSended = false;
        }

        // Se recibe actualización
        public void Update(Recipe recipe)
        {
            //Console.ForegroundColor = ConsoleColor.Green;
            //Console.WriteLine("Se envió el correo a: ", this.Email);
            string message = "Se envió un correo a: " + this.Email;
            if (this.Profile.IsAccording(recipe)) {
                this.MailSended = true;
            } 
            else
            {
                this.MailSended = false;
            }
        }
    }
}
