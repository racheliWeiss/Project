using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models
{
    public class User
    {

        public string login_entity_number { get; set; }
        public string login_ID { get; set; }
        public string login_password { get; set; }

        public string login_finger_print { get; set; }

        public string login_request_method{ get; set; }

        public string ip { get; set; }


        //public User()
        //{ }
        // public User(string Username,string Password)
        //{
        //    this.login_password = Password;
        //    this.login_ID = Username;
        //}

    }
}
