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
        [HttpPost("Login")]
        public ActionResult Login([FromBody] Account account)
        {
            UserProfile userProfile = BusControls.Instance.Login(account);

            if(userProfile.Result)
            {
                return new JsonResult(new APIResponse<UserProfile>(userProfile));
            }
            else
                return new JsonResult(new APIResponse<UserProfile>(userProfile));
        }

        [HttpPost("SignUp")]
        public ActionResult SignUp([FromBody] Account account)
        {
            if (BusControls.Instance.SignUp(account))
            {
                return new JsonResult(new APIResponse<bool>(true));
            }
            return new JsonResult(new APIResponse<bool>(false));
        }
    }
}
