using Microsoft.AspNetCore.Mvc;
using Project.Models;

namespace Project.Controllers
{
    public class PostIsraelController : Controller
    {

        [HttpGet]
        [Route("getPostalCode")]
        public string PostalCode(Address model)
        {
            string postalCode = Manager.Manager.PostCode(model);
            return postalCode;
        }
    }
}
