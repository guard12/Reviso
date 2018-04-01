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
        /// <summary>
        /// Gets the TimeLog object from api and passes it to SaveWorkingTime method
        /// </summary>
        /// <returns>The working time.</returns>
        /// <param name="time">TimeLog object</param>
        [HttpPost]
        [Route("SaveWorkingTime")]
        public IActionResult SaveWorkingTime([FromBody]TimeLog time)
        {
            try
            {
                DBLogWorkingTime db = new DBLogWorkingTime();
                db.SaveWorkingTime(time.Project, time.Comment, time.Date, time.Time);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
