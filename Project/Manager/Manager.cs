using Newtonsoft.Json.Linq;
using Project.Models;
using Project.Repositories;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Project.Manager
{
    public class Manager
    {
        //get the login user
        public static async Task<string> Login(User model)
        {
            return await UserRepository.Instance.Login(model);
        }

        //entity for update delete and..
        public static async Task<string> UspEntity(EntityRequst model)
        {
            return await UserRepository.Instance.UspEntity(model);
        }

        public static  string EntitySearch(EntitySearch model)
        {
            return UserRepository.Instance.Search(model);
        }




        //api to post israel to recive the postalCode of address
        public static string PostCode(Address obj)
        {

            string urlParams = GetQueryString( obj);
            var client = new RestClient("https://services.israelpost.co.il/zip_data.nsf/SearchZip?OpenAgent&" + urlParams);
            var request = new RestRequest(Method.GET);
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            IRestResponse response = client.Execute(request);

            string postalCode="";

            if (response.StatusCode==HttpStatusCode.OK)
            {
                //the take string with tag html andmodivy to stringwithouttag
              string noHTML = Regex.Replace(response.Content, @"<[^>]+>|&nbsp;", "").Trim();
                string noHTMLNormalised = Regex.Replace(noHTML, @"\s{2,}", " ");
                postalCode = noHTMLNormalised;
                postalCode=postalCode.Substring(4);
                postalCode = postalCode.Substring(0,7);
            }
            return postalCode;
        }

       
        //map parmter to url
        public static string GetQueryString(object obj)
        {
            var properties = from p in obj.GetType().GetProperties()
                             where p.GetValue(obj, null) != null
                             select p.Name + "=" + p.GetValue(obj, null).ToString();

            return String.Join("&", properties.ToArray());

        }

        

    }
}