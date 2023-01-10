using System;
namespace DoAn.Model
{
    public class TaskToDo
    {
        public string taskId => Guid.NewGuid().ToString();
        public string taskName { get; set; }
        public string taskType { get; set; }

        public DateTime taskDate { get; set; }

        public TimeSpan taskTime { get; set; }
        public string user_email { get; set; }
    }
}