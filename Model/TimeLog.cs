using System;

namespace Reviso.Model
{
    public class TimeLog
    {
        public int id { get; set; }
        public string Comment { get; set; }
        public string Date { get; set; }
        public string Project { get; set; }
        public int Time { get; set; }
    }
}
