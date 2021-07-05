using System;
using System.Collections.Generic;
using System.Text;

namespace GourmetSp
{
    public class SuscriberUser : ISuscriber
    {
        public User User { get; set; }
        public IProfile Profile { get; set; }
        public bool NotificationsActivated { get; set; }

        public SuscriberUser(User user, IProfile profile)
        {
            this.User = user;
            Profile = profile;
            this.NotificationsActivated = true;
        }

        // Se recibe actualización
        public void Update(Recipe recipe)
        {
            if (this.Profile.IsAccording(recipe) && this.NotificationsActivated)
            {
                this.User.MailSent = true;
            }
            else
            {
                this.User.MailSent = false;
            }
        }

    }
}
