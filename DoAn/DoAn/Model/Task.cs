using System;
using System.Collections.Generic;
using System.Text;

namespace DoAn.OriginalPage
{
    public class Task
    {
        public int taskId { get; set; }
        public string taskName { get; set; }
        public string taskType { get; set; }

        public DateTime taskDate { get; set; }

        public TimeSpan taskTime { get; set; }
    }
}
