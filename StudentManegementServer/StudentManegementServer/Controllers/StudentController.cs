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
        public ActionResult GetAllStudent([FromBody] ClassInfo classInfo)
        {
            List<Student> students = BusControls.Instance.GetAllStudent(classInfo.MaLop);
            if (students != null)
                return new JsonResult(new APIResponse<object>(students));
            return new JsonResult(new APIResponse<object>(200));
        }
        [HttpPost("InsertNewStudent")]
        public ActionResult InsertNewClass([FromBody] Student student)
        {
            if(BusControls.Instance.InsertNewStudent(student))
                return new JsonResult(new APIResponse<object>("Insert success!"));
            return new JsonResult(new APIResponse<object>(200));
        }
        [HttpPost("UpdateStudent")]
        public ActionResult UpdateStudent([FromBody] Student student)
        {
            if (BusControls.Instance.UpdateStudent(student))
                return new JsonResult(new APIResponse<object>("Update success!"));
            return new JsonResult(new APIResponse<object>(200));
        }
        [HttpPost("DeleteStudent")]
        public ActionResult DeleteStudent([FromBody] Student student)
        {
            if (BusControls.Instance.DeleteStudent(student.MaHS))
                return new JsonResult(new APIResponse<object>("Update success!"));
            return new JsonResult(new APIResponse<object>(200));
        }

    }
}
