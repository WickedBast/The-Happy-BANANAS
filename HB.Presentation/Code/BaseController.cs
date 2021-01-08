using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HB.Presentation.Code
{
    public class BaseController : Controller
    {
        public Guid CurrentUserID
        {
            get
            {
                return Guid.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type == "Id").Value);
            }
        }

        public string CurrentUserName
        {
            get
            {
                return HttpContext.User.Claims.FirstOrDefault(x => x.Type == "Name").Value;
            }
        }
        public string CurrentUserLastName
        {
            get
            {
                return HttpContext.User.Claims.FirstOrDefault(x => x.Type == "Surname").Value;
            }
        }
        public string CurrentUserEmail
        {
            get
            {
                return HttpContext.User.Claims.FirstOrDefault(x => x.Type == "Email").Value;
            }
        }
    }
}