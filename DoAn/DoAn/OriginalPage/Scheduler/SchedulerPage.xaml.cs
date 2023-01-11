using System;
using System.Collections.Generic;
using DevExpress.XamarinForms.Scheduler;
using Xamarin.Forms;
using System.Threading.Tasks;
using SchedulerExample.AppointmentPages;
using DoAn.Services;

namespace DoAn.OriginalPage.Scheduler
{
    public partial class SchedulerPage : ContentPage
    {
        readonly UserService userService = new UserService();
        readonly AppointmentService appointmentService = new AppointmentService();
        public SchedulerPage()
        {
            DevExpress.XamarinForms.Scheduler.Initializer.Init();
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            SchedulerDataStorage.DataSource.AppointmentsSource = await appointmentService.GetAppointments();
        }

        const string EditPatternAction = "Edit pattern";
        const string EditOccurrenceAction = "Edit occurrence";
        const string EditNormalAction = "Edit";

        // Tap event
        async void Scheduler_Tap(object sender, SchedulerGestureEventArgs e)
        {
            if (e.AppointmentInfo != null)
            {
                string selectedAction = await DisplaySelectAppointmentEditActionSheet(e.AppointmentInfo.Appointment);
                switch (selectedAction)
                {
                    case "New appointment on the selected interval":
                        PushNewAppointmentPage(e.IntervalInfo);
                        break;
                    case "Detail":
                        PushAppointmentDetailPage(e.AppointmentInfo.Appointment);
                        break;

                    case EditPatternAction:
                        PushEditAppointmentPage(SchedulerDataStorage.GetPattern(e.AppointmentInfo.Appointment));
                        break;

                    case "Delete":
                        bool confirmation = await DisplayAlert("Do you really want to delete the appointment?", null, "Yes", "No");
                        if (confirmation)
                        {
                            SchedulerDataStorage.RemoveAppointment(e.AppointmentInfo.Appointment);
                            // delete appointment from database
                            int id = int.Parse(e.AppointmentInfo.Appointment.Id.ToString());
                            await appointmentService.DeleteAppointment(id);

                        }
                        break;

                    case EditOccurrenceAction:
                    case EditNormalAction:
                        PushEditAppointmentPage(e.AppointmentInfo.Appointment);
                        break;
                    default:
                        break;
                }
            }
            else
            {
                if (e.IntervalInfo != null) { PushNewAppointmentPage(e.IntervalInfo); }
            }
        }

        async void PushAppointmentDetailPage(AppointmentItem target)
        {
            var page = new CustomAppointmentDetailPage(target, SchedulerDataStorage);
            await Navigation.PushAsync(page);
        }

        // Edit appointment
        async void PushEditAppointmentPage(AppointmentItem target)
        {
            //var page = new AppointmentEditPage(target, SchedulerDataStorage);
            var page = new CustomAppointmentEditPage(target, SchedulerDataStorage);
            await Navigation.PushAsync(page);
        }

        // Create new appointment
        async void PushNewAppointmentPage(IntervalInfo info)
        {
            //var page = new AppointmentEditPage(info.Start, info.End, info.AllDay, SchedulerDataStorage);
            var page = new CustomAppointmentEditPage(info.Start, info.End, info.AllDay, SchedulerDataStorage);
            await Navigation.PushAsync(page);

        }

        // Select action
        async Task<String> DisplaySelectAppointmentEditActionSheet(AppointmentItem target)
        {
            string[] actions = null;
            //string deleteAction = null;
            switch (target.Type)
            {
                case AppointmentType.Normal:
                    //actions = new string[] { "Detail", EditNormalAction, "Delete" };
                    actions = new string[] { "Add new appointment on the selected interval", "Detail", "Delete" };
                    break;
                default:
                    actions = new string[] { EditPatternAction, EditOccurrenceAction };
                    break;
            }
            return await this.DisplayActionSheet("Select the action", "Cancel", null, actions);
        }


        void SchedulerView_Refreshing(System.Object sender, System.EventArgs e)
        {
            SchedulerView.IsRefreshing = false;
        }

        void Button_Clicked(System.Object sender, System.EventArgs e)
        {
        }
    }
}

