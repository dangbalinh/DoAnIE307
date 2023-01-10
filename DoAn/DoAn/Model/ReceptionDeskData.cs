using System;
using System.Collections.ObjectModel;
using DoAn.Services;

namespace DoAn.Model
{
    public class MedicalAppointment
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Subject { get; set; }
        public int LabelId { get; set; }
        public string Location { get; set; }
        public string User_email { get; set; }
    }
}
