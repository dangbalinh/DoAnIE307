using System;
using System.Collections.Generic;
using System.Text;

namespace DoAn.ModelDTO
{
    public class TaskDTO
    {
        public int taskId { get; set; }
        public string taskName { get; set; }
        public string taskType { get; set; }

        public string taskDate { get; set; }

        public string taskTime { get; set; }
    }
}
