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
                return new JsonResult(new APIResponse<object>(userProfile));
            }
            else
                return new JsonResult(new APIResponse<object>(200));
        }

        [HttpPost("signup")]
        public ActionResult SignUp([FromBody] Account account)
        {
            BusControls busControls = new BusControls();

            if (busControls.Instance.SignUp(account))
            {
                return new JsonResult(new APIResponse<object>("Sign Up Success"));
            }
            return new JsonResult(new APIResponse<UserProfile>(200));
        }
    }
}
