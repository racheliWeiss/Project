using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models
{
    public class EntitySearch
    {
        public int id_initiator { get; set; }

        public int id_client { get; set; }

        // private string[] myNumbers= { ["name","address","thelephone"]};

        private string[] search_field = { "name", "address", "thelephone" };
        public string[] search_fields
        {
            get { return search_field; }
            set { search_field = value; }
        }
        public string search_type { get; set; }

        private string[] search_types_id = { "customer", "user" };
        public string[] search_entity_type_id
        {
            get { return search_types_id; }
            set { search_types_id = value; }
        }
        public string order_by { get; set; }
        public int page_size { get; set; }

        public int page_index { get; set; }

        public string search_value { get; set; }


    }
}


