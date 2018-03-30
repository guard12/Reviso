using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Reviso.Model;
using Reviso.DAL;

namespace Reviso.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class LogWorkingTimeController : Controller
    {
        [HttpPost]
        [Route("SaveWorkingTime")]
        public IActionResult SaveWorkingTime([FromBody]TimeLog time)
        {
            DBLogWorkingTime db = new DBLogWorkingTime();
            db.SaveLog(time.Project, time.Comment, time.Date, time.Time);
            return Ok();
        }
    }
}
