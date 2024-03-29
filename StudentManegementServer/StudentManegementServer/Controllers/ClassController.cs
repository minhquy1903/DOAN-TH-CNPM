﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManegementServer.APIResponse;
using StudentManegementServer.BUS;
using StudentManegementServer.Models.Class;

namespace StudentManegementServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassController : ControllerBase
    {
        [HttpGet("GetAll")]

        public ActionResult GetAllClass()
        {
            List<ClassInfo> classInfos = BusControls.Instance.GetAllClass();
            if (classInfos != null)
                return new JsonResult(new APIResponse<List<ClassInfo>>(classInfos));
            return new JsonResult(new APIResponse<object>(false));
        }

        [HttpPost("InsertNewClass")]
        public ActionResult InsertNewClass([FromBody] ClassInfo classInfo)
        {
            if (BusControls.Instance.InsertNewClass(classInfo))
                return new JsonResult(new APIResponse<bool>(true));
            else
                return new JsonResult(new APIResponse<bool>(false));
        }
        [HttpPost("DeleteClass")]
        public ActionResult DeleteClass([FromBody] int maLop)
        {
            if (BusControls.Instance.DeleteClass(maLop))
                return new JsonResult(new APIResponse<bool>(true));
            return new JsonResult(new APIResponse<bool>(false));
        }

        [HttpPost("UpdateClass")]
        public ActionResult UpdateClass([FromBody] ClassInfo classInfo)
        {
            if (BusControls.Instance.UpdateClass(classInfo))
                return new JsonResult(new APIResponse<bool>(true));
            return new JsonResult(new APIResponse<bool>(false));
        }
    }
}
