using Microsoft.SqlServer.Management.Smo;
using Nancy.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Project.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Dynamic;

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
                            instance = new();
                        }

                    }
                }
                return instance;
            }
        }

        private UserRepository()
        {// "Data Source=82.166.177.109;Initial Catalog=MSB;User Id=ReactLogin;Password="

            connection = "Data Source=82.166.177.109;Initial Catalog=MSB;User ID=ReactLogin;Password=!qazXsw2;" +
                "Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        }
        //check if the user existing  in server
        public async Task<string> Login(Models.User model)
        {
            string jsonLogin = "";
            SqlConnection conn = null;
            string jsonUser = JsonConvert.SerializeObject(model);
            try
            {
                using (conn = new SqlConnection(connection))
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {

                        await conn.OpenAsync();
                        //conn.Open();
                        cmd.CommandText = "usp_login";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter
                        {
                            ParameterName = "@login",
                            SqlDbType = SqlDbType.VarChar,
                            Direction = ParameterDirection.InputOutput,
                            Value = jsonUser,
                            Size = 8000
                        });
                        //cmd.ExecuteNonQuery();
                        await cmd.ExecuteNonQueryAsync();
                        var login = cmd.Parameters["@login"];
                        jsonLogin = cmd.Parameters["@login"].Value.ToString();
                    }
                }
            }
            catch (SqlException ex)
            {
                string error = ex.Message;
                return $"Data could not be read [{ex}]";

            }
            catch (Exception ex)
            {
                return $"error [{ex}]";

            }

            finally
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            return jsonLogin;
        }




        public  string Search(EntitySearch model)
        {
            SqlConnection conn = null;
            string jsonUser = JsonConvert.SerializeObject(model);
            string jsonSearch = "";
            try
            {
                using (conn = new SqlConnection(connection))
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {


                        conn.Open();
                        cmd.CommandText = "usp_entity_search";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter
                        {
                            ParameterName = "@search",
                            SqlDbType = SqlDbType.VarChar,
                            Direction = ParameterDirection.InputOutput,
                            Value = jsonUser,
                            Size = 8000
                        });
                        cmd.ExecuteNonQuery();
                        var login = cmd.Parameters["@search"];
                        jsonSearch = cmd.Parameters["@search"].Value.ToString();
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
            return jsonSearch;

        }


        public async Task<string> UspEntity(EntityRequst entity)
        {

            string jsonResult = "";
            SqlConnection conn = null;
            string jsonEntity = JsonConvert.SerializeObject(entity);
            Console.WriteLine(entity);
            try
            {
                using (conn = new SqlConnection(connection))
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        conn.Open();
                        cmd.CommandText = "usp_entity";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter
                        {
                            ParameterName = "@entity",
                             SqlDbType = SqlDbType.NVarChar,
                            Direction = ParameterDirection.InputOutput,
                            Value = jsonEntity,
                            Size = 8000,
                        }) ;
                        cmd.ExecuteNonQuery();
                        var login = cmd.Parameters["@entity"];
                        jsonResult = cmd.Parameters["@entity"].Value.ToString();
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
            return jsonResult;

        }

        public async Task<string> UspEnum(EntityEnum entity)
        {
            string jsonResult = "";
            SqlConnection conn = null;
            string jsonEntity = JsonConvert.SerializeObject(entity);
            Console.WriteLine(entity);
            try
            {
                using (conn = new SqlConnection(connection))
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        conn.Open();
                        cmd.CommandText = "usp_enum";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter
                        {
                            ParameterName = "@enum",
                            SqlDbType = SqlDbType.NVarChar,
                            Direction = ParameterDirection.InputOutput,
                            Value = jsonEntity,
                            Size = 8000,
                        });
                        cmd.ExecuteNonQuery();
                        var login = cmd.Parameters["@enum"];
                        jsonResult = cmd.Parameters["@enum"].Value.ToString();
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
            return jsonResult;

        }
    }


}
