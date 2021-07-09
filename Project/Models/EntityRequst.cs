using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models
{
    public class EntityRequst
    {

        public int id_initiator { get; set; }

        public int id_client { get; set; }

        public int id_branch { get; set; }

        public string entity_request_method { get; set; }

        public string ID_country_code { get; set; }

        public string ID_number { get; set; }

        public string ID_type_id { get; set; }

        public int status_id { get; set; }

        public int class_id { get; set; }

        public string entity_type_id { get; set; }

        public int entity_sub_type_id { get; set; }

        public string first_name { get; set; }

        public string last_name { get; set; }

        public string entity_name { get; set; }

        public string first_name_en { get; set; }

        public string last_name_en { get; set; }

        public string entity_name_en { get; set; }

        public DateTime date_birth { get; set; }

        public string gender_id { get; set; }

        public int id_identifier { get; set; }

        public Boolean is_identified { get; set; }

        public Boolean is_loaded_documentation { get; set; }

        public Boolean is_locked { get; set; }

        public string note { get; set; }
        //check parm
        public int permission_group_id { get; set; }

        public Boolean return_entity { get; set; }

        public string user_language { get; set; }

        public string user_time_zone { get; set; }
        public int id_entity { get; set; }

        public string attribute_request_method { get; set; }
        public string attribute { get; set; }

        public int address_type_id { get; set; }

        public string address_name { get; set; }

        public string address_number { get; set; }

        public string address_city { get; set; }

        public string address_country_code { get; set; }

        public string address_zip_code { get; set; }
        public int is_deleted { get; set; }
        public int is_default { get; set; }

        public int email_type_id { get; set; }

        public string email_address { get; set; }

        public string telephone_number { get; set; }

        public string telephone_country_code { get; set; }

        
      
      

    }
}


