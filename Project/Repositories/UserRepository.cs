using Microsoft.SqlServer.Management.Smo;
using Nancy.Json;
using Project.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Repositories
{
    public class UserRepository
    {
        private int retunRole;

        private static UserRepository instance = new UserRepository();
        private static readonly object mutex = new object();
        private string connection = "";
        public static UserRepository Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (mutex)
                    {
                        if (instance == null)
                        {
                            instance = new ();
                        }

                    }
                }
                return instance;
            }
        }

        private UserRepository()
        {
            connection = @"server= Data Source = 82.166.177.109; Encrypt = False; Initial Catalog = MSB; Integrated Security = False; User ID = cpiLogin";
        }

        public int Login(Models.User model)
        {

            SqlConnection conn = null;
           /* string jsonUser = new JavaScriptSerializer().Serialize(model);‏*/

            try
            {
                using (conn = new SqlConnection())
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {


                        conn.Open();

                        cmd.CommandText = "usp_login";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@login",model));
                        /*cmd.Parameters.Add(new SqlParameter(@Password, password));
                        cmd.Parameters.Add(new SqlParameter(@PersonId, personId));*/
                        retunRole=(int)cmd.ExecuteScalar();
                    }
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
            finally
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }

            }
            return retunRole;

        }
    }


}
