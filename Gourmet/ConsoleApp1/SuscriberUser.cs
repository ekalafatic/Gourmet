using System;
using System.Collections.Generic;
using System.Text;

namespace GourmetSp
{
    public class SuscriberUser : ISuscriber
    {
        public User user { get; set; }
        public IProfile Profile { get; set; }
        public bool notificationsActivated { get; set; }

        public SuscriberUser(User user, IProfile profile)
        {
            this.user = user;
            Profile = profile;
            this.notificationsActivated = true;
        }

        // Se recibe actualización
        public void Update(Recipe recipe)
        {
            if (this.Profile.IsAccording(recipe) && this.notificationsActivated)
            {
                this.user.MailSended = true;
            }
            else
            {
                this.user.MailSended = false;
            }
        }

    }
}
