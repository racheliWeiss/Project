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
using static Microsoft.SqlServer.Management.Sdk.Sfc.OrderBy;

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
        {// "Data Source=82.166.177.109;Initial Catalog=MSB;User Id=ReactLogin;Password=!qazXsw2"

            connection = "Data Source=82.166.177.109;Initial Catalog=MSB;User ID=ReactLogin;Password=!qazXsw2;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        }
        //check if the user existing  in server
 
        public int Login(Models.User model)
        {
            int retunRole = -1;
            SqlConnection conn = null;

            string jsonUser = JsonConvert.SerializeObject(model);


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
                        cmd.Parameters.Add(new SqlParameter
                        {
                            ParameterName = "@login",
                            SqlDbType = SqlDbType.NVarChar,
                            Direction = ParameterDirection.InputOutput,
                            Value = jsonUser
                        });
                       cmd.ExecuteScalar();
                        var entity = cmd.Parameters["@login"];

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

        public int Search(Object model)
        {
            int retunRole = -1;
            SqlConnection conn = null;

            string jsonUser = JsonConvert.SerializeObject(model);


            //string jsonUser = JsonConvert.SerializeObject(testUser);‏

            try
            {
                using (conn = new SqlConnection(connection))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {


                        conn.Open();

                        cmd.CommandText = "usp_entity_search";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@search", model));
                        retunRole = (int)cmd.ExecuteScalar();
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


        public int UspEntity(Object model)
        {
            int retunRole = -1;
            SqlConnection conn = null;

            string jsonUser = JsonConvert.SerializeObject(model);


            //string jsonUser = JsonConvert.SerializeObject(testUser);‏

            try
            {
                using (conn = new SqlConnection(connection))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {


                        conn.Open();

                        cmd.CommandText = "usp_entity";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@entity", model));
                        retunRole = (int)cmd.ExecuteScalar();
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
