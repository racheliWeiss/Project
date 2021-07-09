using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models
{
    public class User
    {
        //// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 

        //    [JsonProperty("login_request_method")]
        //    public string LoginRequestMethod { get; set; }

        //    [JsonProperty("login_entity_number")]
        //    public string LoginEntityNumber { get; set; }

        //    [JsonProperty("login_ID")]
        //    public string LoginID { get; set; }

        //    [JsonProperty("login_password")]
        //    public string LoginPassword { get; set; }


        public string login_entity_number { get; set; }
        public string login_ID { get; set; }
        public string login_password { get; set; }

        public string login_finger_print { get; set; }

        public string login_request_method { get; set; }

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
