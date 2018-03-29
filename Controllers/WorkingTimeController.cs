using System;
using Microsoft.AspNetCore.Mvc;
using System.Web;
using Newtonsoft.Json;
using System.Collections.Generic;
using Reviso.Model;
using Reviso.DAL;

namespace Reviso.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class WorkingTimeController : Controller
    {
        [HttpGet("[action]")]
        public JsonResult WorkingTime()
        {
            DBWorkingTime db = new DBWorkingTime();
            var logsList = db.GetAllLogs();
            return Json(logsList);
        }

        [HttpPost]
        [Route("SaveWorkingTime")]
        public IActionResult SaveWorkingTime([FromBody]TimeLog time)
        {
            DBWorkingTime db = new DBWorkingTime();
            db.SaveLog(time.Project, time.Comment, time.Date, time.Time);
            return Ok();
        }
    }
}
