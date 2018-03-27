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
        private List<TimeLog> logs = new List<TimeLog>();
        [HttpGet("[action]")]
        public List<TimeLog> WorkingTime()
        {
            return logs;
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
