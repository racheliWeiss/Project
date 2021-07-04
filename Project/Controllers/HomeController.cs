using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Project.Models;
using Project.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class HomeController : Controller
    {
        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
         //The function Login to server with jwt 
        public async Task<ActionResult<dynamic>> Authenticate([FromBody] User model)
        {
          try
          {

        
            string jsonLogin = await Manager.Manager.Login(model);
            var jsonResponse =  JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(jsonLogin);
            string permission =  jsonResponse["err_code"];
             if (!permission.Equals("0"))
                  return "dont login";
                 //NotFound(new { message = "User or password invalid" });

            if (permission.Equals("0") ){ 
          
               var token = TokenService.CreateToken(model);
               model.login_password = "";
               return new
               {
                 user= jsonLogin,
                 token = token
               };

            }
          }
          catch(Exception ex)
           {
               return (ex.ToString());
           }

            return "dont login";
        }

        [Route("uspEntity")]
        [HttpPost]
        public async Task <ActionResult<dynamic>> UspEntity([FromBody] EntityRequst model)
        {
            string jsonResponse = await Manager.Manager.UspEntity(model);
            return jsonResponse;
        }

        [HttpPost]
        [Route("search")]
        [AllowAnonymous]
        //paginate in table search  Customer
        public async Task<ActionResult<dynamic>>SearchEntity([FromBody] EntitySearch model)
        {
            
            string jsonSearch = Manager.Manager.EntitySearch(model);
            return jsonSearch;
        }

        [HttpPost]
        [Route("uspEnum")]
        public async Task<ActionResult<dynamic>> uspEnum([FromBody] EntityEnum model)
        {
            string  jsonOfValue= await Manager.Manager.UspEnum(model);
            return jsonOfValue;

        }

        //[HttpPost]
        //[Route("si")]
        //public JObject PostAlbumJObject(JObject jAlbum)
        //{
        //    // dynamic input from inbound JSON
        //    dynamic album = jAlbum;

        //    // create a new JSON object to write out
        //    dynamic newAlbum = new JObject();

        //    // Create properties on the new instance
        //    // with values from the first
        //    newAlbum.AlbumName = album.AlbumName + " New";
        //    newAlbum.NewProperty = "something new";
        //    newAlbum.Songs = new JArray();

        //    foreach (dynamic song in album.Songs)
        //    {
        //        song.SongName = song.SongName + " New";
        //        newAlbum.Songs.Add(song);
        //    }

        //    return newAlbum;
        //}

        //[HttpPost]
        //[Route("sihi")]
        //public Task<dynamic>FundAllocation(JObject jsonResult)
        //{

        //   dynamic item = JsonConvert.DeserializeObject<dynamic>(jsonResult.ToString());
        //    return item;
        //}
    }

}

