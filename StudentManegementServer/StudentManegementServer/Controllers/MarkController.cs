using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManegementServer.APIResponse;
using StudentManegementServer.BUS;
using StudentManegementServer.Models;

namespace StudentManegementServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarkController : ControllerBase
    {
        [HttpPost("GetAllMarks")]
        public ActionResult GetAllMarks([FromBody] Mark mark)
        {
            List<Mark> marks = BusControls.Instance.GetAllMark(mark);
            if (marks != null)
                return new JsonResult(new APIResponse<List<Mark>>(marks));
            else
                return new JsonResult(new APIResponse<string>(""));
        }
    }
}
