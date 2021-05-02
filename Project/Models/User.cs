using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models
{
    public class User
    {

        public int Login_ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public string Login_entity_number { get; set; }

        
        public User(string Username,string Password)
        {
            this.Password = Password;
            this.Username = Username;
        }
    }
}
