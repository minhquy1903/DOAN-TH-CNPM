using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManegementServer.APIResponse;
using StudentManegementServer.Models;
using StudentManegementServer.BUS;

namespace StudentManegementServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class AccountController : ControllerBase
    {
        [HttpPost("login")]
        public ActionResult Login([FromBody] Account account)
        {
            BusControls busControls = new BusControls();

            UserProfile userProfile = busControls.Instance.Login(account);

            if(userProfile != null)
            {
                return new JsonResult(new APIResponse<UserProfile>(userProfile));
            }
            else
                return new JsonResult(new APIResponse<Account>(200));
        }
    }
}
