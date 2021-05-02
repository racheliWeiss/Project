using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Repositories
{
    public class Repository
    {
        private static Repository instance = new Repository();
        private static readonly object mutex = new object();
        private string connection = "";
        public static Repository Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (mutex)
                    {
                        if (instance == null)
                        {
                            instance = new Repository();
                        }

                    }
                }
                return instance;
            }
        }

        private Repository()
        {
            connection = @"server= Data Source = 82.166.177.109; Encrypt = False; Initial Catalog = MSB; Integrated Security = False; User ID = cpiLogin";
        }

        

    }
}
