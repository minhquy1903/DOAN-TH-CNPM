using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManegementServer.APIResponse;
using StudentManegementServer.BUS;
using StudentManegementServer.Models;
using StudentManegementServer.Models.Class;

namespace StudentManegementServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        [HttpPost("GetAllStudent")]
        public ActionResult GetAllStudent([FromBody] int maLop)
        {
            List<Student> students = BusControls.Instance.GetAllStudent(maLop);
            if (students != null)
                return new JsonResult(new APIResponse<object>(students));
            return new JsonResult(new APIResponse<object>(false));
        }
        [HttpPost("InsertNewStudent")]
        public ActionResult InsertNewClass([FromBody] Student student)
        {
            if(BusControls.Instance.InsertNewStudent(student))
                return new JsonResult(new APIResponse<bool>(true));
            return new JsonResult(new APIResponse<bool>(false));
        }
        [HttpPost("UpdateStudent")]
        public ActionResult UpdateStudent([FromBody] Student student)
        {
            if (BusControls.Instance.UpdateStudent(student))
                return new JsonResult(new APIResponse<bool>(true));
            return new JsonResult(new APIResponse<bool>(false));
        }
        [HttpPost("DeleteStudent")]
        public ActionResult DeleteStudent([FromBody] int maHS)
        {
            if (BusControls.Instance.DeleteStudent(maHS))
                return new JsonResult(new APIResponse<bool>(true));
            return new JsonResult(new APIResponse<bool>(false));
        }

    }
}
