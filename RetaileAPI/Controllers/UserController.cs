using Microsoft.AspNet.Identity;
using RetaileAPILibrary.DataAccess;
using RetaileAPILibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace RetaileAPI.Controllers
{
    [Authorize]
    public class UserController : ApiController
    {
        // GET: User/Details/5
        public UserModel GetById()
        {
            string userId = RequestContext.Principal.Identity.GetUserId();
            UserData data = new UserData();

            return data.GetUserById(userId).First();
        }
    }
}
