using System;
using NUnit.Framework;
using Reviso.DAL;
using Reviso.Model;
using System.Collections.Generic;

namespace Reviso.AutomatedTests
{
    [TestFixture]
    public class AppTests
    {
        [TestCase]
        public void GetWorkingTimes()
        {
            List<TimeLog> times = new List<TimeLog>();
            DBGetWorkingTime dbgwt = new DBGetWorkingTime();
            times = dbgwt.GetAllWorkingTimes();
            Assert.IsTrue(times.Count > 0);
        }
    }
}
