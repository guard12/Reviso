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
        [HttpGet("[action]")]
        public JsonResult WorkingTime()
        {
            DBGetWorkingTime db = new DBGetWorkingTime();
            var logsList = db.GetAllLogs();
            return Json(logsList);
        }
    }
}
