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
    public class GetWorkingTimeController : Controller
    {
        /// <summary>
        /// Returns the list of all logged working times in Json format
        /// </summary>
        /// <returns>Json</returns>
        [HttpGet("[action]")]
        public JsonResult GetWorkingTimes()
        {
            try
            {
                DBGetWorkingTime db = new DBGetWorkingTime();
                var logsList = db.GetAllWorkingTimes();
                return Json(logsList);
            }
            catch
            {
                throw new JsonException(); 
            }
        }
    }
}
