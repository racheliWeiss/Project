using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models
{
    public class EntityEnum
    {
        public int id_client { get; set; }

        public int id_initiator { get; set; }
        public string enum_type { get; set; }

        public string enum_request_method { get; set; }

        public string category { get; set; }

        public string user_language { get; set; }

    }
}
