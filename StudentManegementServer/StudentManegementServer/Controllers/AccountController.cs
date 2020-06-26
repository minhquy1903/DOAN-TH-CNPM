using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManegementServer.APIResponse;
using StudentManegementServer.Models;

namespace StudentManegementServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class AccountController : ControllerBase
    {
        [HttpPost("login")]
        public ActionResult Login([FromBody] Account account)
        {
            if(account.Username == "minhquy" && account.Password == "123456")
                return new JsonResult(new APIResponse<Account>(account));
            else
                return new JsonResult(new APIResponse<Account>(404));
        }
    }
}
