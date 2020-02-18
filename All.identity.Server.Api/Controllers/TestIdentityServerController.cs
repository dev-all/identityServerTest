using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace All.identity.Server.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TestIdentityServerController : ControllerBase
    {
        //Test Identity Server
        [HttpGet]
        public ActionResult Get()
        {
            return new JsonResult(from u in User.Claims select new { u.Type, u.Value });
        }

      
    }
}
