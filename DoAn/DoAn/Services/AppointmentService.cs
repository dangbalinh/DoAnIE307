using System;
using System.Collections.ObjectModel;
using Firebase.Database;
using DoAn.Model;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Xamarin.Essentials;
using Newtonsoft.Json;
using DoAn.OriginalPage.User;
using Firebase.Database.Query;
using Task = System.Threading.Tasks.Task;
using DoAn.Interfaces;
using Xamarin.Forms;

namespace DoAn.Services
{
	public class AppointmentService
	{
        readonly FirebaseClient client = new FirebaseClient("https://xamarinproject-c7a59-default-rtdb.asia-southeast1.firebasedatabase.app/");
        IAuth auth = DependencyService.Get<IAuth>();

        // add appointment to firebase realtime database
        public async Task<bool> AddAppointment(MedicalAppointment appointment)
        {
            var data = await client.Child("Appoiments").PostAsync(JsonConvert.SerializeObject(appointment));

            if (string.IsNullOrEmpty(data.Key))
                return true;
            return false;
        }

        // update appointment to firebase realtime database
        public async Task<bool> UpdateAppointment(MedicalAppointment appointment)
        {
            var data = await client.Child("Appoiments").OnceAsync<MedicalAppointment>();
            var toUpdate = data.Where(a => a.Object.Id == appointment.Id).FirstOrDefault();
            await client.Child("Appoiments").Child(toUpdate.Key).PutAsync(JsonConvert.SerializeObject(appointment));
            return true;
        }

        // delete appointment from firebase realtime database
        public async Task<bool> DeleteAppointment(int appointmentId)
        {
            var data = await client.Child("Appoiments").OnceAsync<MedicalAppointment>();
            var toDelete = data.Where(a => a.Object.Id == appointmentId).FirstOrDefault();
            await client.Child("Appoiments").Child(toDelete.Key).DeleteAsync();
            return true;
        }

        // get all appointment that belong to current user
        public async Task<ObservableCollection<MedicalAppointment>> GetAppointments()
        {
            var data = await client.Child("Appoiments").OnceAsync<MedicalAppointment>();
            var appointments = new ObservableCollection<MedicalAppointment>();
            foreach (var item in data)
            {
                if (item.Object.User_email == Preferences.Get("User_email", auth.GetEmail()))
                {
                    appointments.Add(item.Object);
                }
            }
            return appointments;
        }

        // get the last appointment in the entire database
        public async Task<MedicalAppointment> GetLastAppointment()
        {
            // take the last appointment in the entire database
            var data = await client.Child("Appoiments").OrderByKey().LimitToLast(1).OnceAsync<MedicalAppointment>();

            // if there is no appointment in the database, return null
            if (data.Count() == 0)
                return null;

            var appointments = new ObservableCollection<MedicalAppointment>();
            foreach (var item in data)
            {
                appointments.Add(item.Object);
            }
            return appointments[0];
            
        }

        // get the biggest id of appointment
        public async Task<int> GetMaxId()
        {
            var latestAppointment = await GetLastAppointment();
            if (latestAppointment == null)
                return 0;
            return latestAppointment.Id;
        }
    }
}

