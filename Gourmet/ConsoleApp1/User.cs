using System;
using System.Collections.Generic;
using System.Text;

namespace GourmetSp
{
    public class User
    {
        public string Email { get; set; }
        
        public bool MailSended { get; set; }
        
        public User(string email)
        {
            Email = email;
            this.MailSended = false;
        }

    }
}
