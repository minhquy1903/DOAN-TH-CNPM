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
        public ActionResult GetAllMarks([FromBody] int mahs)
        {
            List<Mark> marks = BusControls.Instance.GetAllMark(mahs);
            if (marks != null)
                return new JsonResult(new APIResponse<List<Mark>>(marks));
                return new JsonResult(new APIResponse<List<Mark>>(null));
        }

        [HttpPost("InsertMark")]
        public ActionResult InsertMark([FromBody] Mark mark)
        {
            if (BusControls.Instance.InsertMark(mark))
                return new JsonResult(new APIResponse<bool>(true));
            return new JsonResult(new APIResponse<bool>(false));
        }

        [HttpPost("DeleteMark")]
        public ActionResult DeleteMark([FromBody] int madiem)
        {
            if (BusControls.Instance.DeleteMark(madiem))
                return new JsonResult(new APIResponse<bool>(true));
            return new JsonResult(new APIResponse<bool>(false));
        }
    }
}
