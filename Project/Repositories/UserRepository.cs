using Microsoft.SqlServer.Management.Smo;
using Nancy.Json;
using Newtonsoft.Json;
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
            connection = @"server= Data Source=82.166.177.109;User Id=cpiLogin;Password=!qazXsw2";
        }

        public int Login(Models.User model)
        {
            int retunRole = -1;
            SqlConnection conn = null;

            string jsonUser = new JavaScriptSerializer().Serialize(model);


            //string jsonUser = JsonConvert.SerializeObject(testUser);‏

            try
            {
                using (conn = new SqlConnection(connection))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {


                        conn.Open();

                        cmd.CommandText = "usp_login";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@login",model));
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
