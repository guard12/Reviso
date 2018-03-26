using System;
using Microsoft.AspNetCore.Mvc;
using System.Web;
using Newtonsoft.Json;
using System.Collections.Generic;
using Reviso.Model;

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
            TimeLog tl = new TimeLog();
            tl.Project = time.Project;
            tl.Comment = time.Comment;
            tl.Date = time.Date;
            tl.Time = time.Time;
            logs.Add(tl);
            return Ok();
        }
    }
}
