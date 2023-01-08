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

    public class ReceptionDeskData
    {
        // AppointmentService appointmentService;
        public static DateTime BaseDate = DateTime.Today;

        //public static string[] PatientNames = { "Andrew Glover", "Mark Oliver",
        //                                        "Taylor Riley", "Addison Davis",
        //                                        "Benjamin Hughes", "Lucas Smith",
        //                                        "Robert King", "Laura Callahan",
        //                                        "Miguel Simmons", "Isabella Carter",
        //                                        "Andrew Fuller", "Madeleine Russell",
        //                                        "Steven Buchanan", "Nancy Davolio",
        //                                        "Michael Suyama", "Margaret Peacock",
        //                                        "Janet Leverling", "Ariana Alexander",
        //                                        "Brad Farkus", "Bart Arnaz",
        //                                        "Arnie Schwartz", "Billy Zimmer"};

        public static string[] PatientNames = { "Go to the supermarket", "Go shopping",
                                                "Take a bath", "Prepare dinner",
                                                "Get homeworks done", "Go to school",
                                                "Clean the room", "Prepare breakfast",
                                                "Prepare lunch", "Coffee time",
                                                "Go to sleep", "Take a nap"};

        static Random rnd = new Random();

        void CreateMedicalAppointments()
        {
            int appointmentId = 1;
            int patientIndex = 0;
            DateTime start;
            TimeSpan duration;
            ObservableCollection<MedicalAppointment> result =
                                                     new ObservableCollection<MedicalAppointment>();
            for (int i = -20; i < 20; i++)
                for (int j = 0; j < 15; j++)
                {
                    int room = rnd.Next(1, 100);
                    start = BaseDate.AddDays(i).AddHours(rnd.Next(8, 17)).AddMinutes(rnd.Next(0, 40));
                    duration = TimeSpan.FromMinutes(rnd.Next(20, 30));
                    result.Add(CreateMedicAppointment(appointmentId, PatientNames[patientIndex],
                                                    start, duration, room));
                    appointmentId++;
                    patientIndex++;
                    if (patientIndex >= PatientNames.Length - 1)
                        patientIndex = 1;
                }
            MedicalAppointments = result;

            //MedicalAppointments = await appointmentService.GetAppointments();
        }

        MedicalAppointment CreateMedicAppointment(int appointmentId, string patientName,
                                                    DateTime start, TimeSpan duration, int room)
        {
            MedicalAppointment medicalAppointment = new MedicalAppointment();
            medicalAppointment.Id = appointmentId;
            medicalAppointment.StartTime = start;
            medicalAppointment.EndTime = start.Add(duration);
            medicalAppointment.Subject = patientName;

            // Assign one of the predefined labels to an appointment
            medicalAppointment.LabelId = rnd.Next(1, 10);

            medicalAppointment.Location = String.Format("{0}", room);
            return medicalAppointment;
        }

        public ObservableCollection<MedicalAppointment> MedicalAppointments { get; private set; }

        public ReceptionDeskData()
        {
            //appointmentService = new AppointmentService();
            CreateMedicalAppointments();
        }
    }
}
