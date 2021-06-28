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

        public int ID_type_id { get; set; }

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

        public int gender_id { get; set; }

        public int id_identifier { get; set; }

        public Boolean is_identified { get; set; }

        public Boolean is_loaded_documentation { get; set; }

        public Boolean is_locked { get; set; }

        public string note { get; set; }

        public int permission_group_id { get; set; }

        public Boolean return_entity { get; set; }

        public string user_language { get; set; }

        public string user_time_zone { get; set; }
    }
}


