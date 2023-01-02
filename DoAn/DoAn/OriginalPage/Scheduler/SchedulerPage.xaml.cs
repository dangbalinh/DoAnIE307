using System;
using System.Collections.Generic;
using DevExpress.XamarinForms.Scheduler;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace DoAn.OriginalPage.Scheduler
{
    public partial class SchedulerPage : ContentPage
    {
        public SchedulerPage()
        {
            DevExpress.XamarinForms.Scheduler.Initializer.Init();
            InitializeComponent();
        }

        //void Scheduler_Tap(System.Object sender, DevExpress.XamarinForms.Scheduler.SchedulerGestureEventArgs e)
        //{
        //    // Get date
        //    //var today = e.AppointmentInfo.Appointment.Start.Date.ToShortDateString()
        //    if (e.AppointmentInfo == null)
        //    {
        //        ShowNewAppointmentEditPage(e.IntervalInfo);
        //        return;
        //    }
        //    AppointmentItem appointment = e.AppointmentInfo.Appointment;
        //    ShowAppointmentEditPage(appointment);

        //}


        //private void ShowAppointmentEditPage(AppointmentItem appointment)
        //{
        //    AppointmentEditPage appEditPage = new AppointmentEditPage(appointment, this.SchedulerDataStorage);
        //    Navigation.PushAsync(appEditPage);
        //}

        //private void ShowNewAppointmentEditPage(IntervalInfo info)
        //{
        //    AppointmentEditPage appEditPage = new AppointmentEditPage(info.Start, info.End,
        //                                                             info.AllDay, this.SchedulerDataStorage);
        //    Navigation.PushAsync(appEditPage);
        //}



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
                    case EditPatternAction:
                        PushEditAppointmentPage(SchedulerDataStorage.GetPattern(e.AppointmentInfo.Appointment));
                        break;
                    case EditOccurrenceAction:
                    case EditNormalAction:
                        PushEditAppointmentPage(e.AppointmentInfo.Appointment);
                        break;
                    case "Delete":
                        bool confirmation = await DisplayAlert("Do you really want to delete the appointment?", null, "Yes", "No");
                        if (confirmation)
                            SchedulerDataStorage.RemoveAppointment(e.AppointmentInfo.Appointment);
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

        // Edit appointment
        async void PushEditAppointmentPage(AppointmentItem target)
        {
            var page = new AppointmentEditPage(target, SchedulerDataStorage);
            await Navigation.PushAsync(page);
        }

        // Create new appointment
        async void PushNewAppointmentPage(IntervalInfo info)
        {
            var page = new AppointmentEditPage(info.Start, info.End, info.AllDay, SchedulerDataStorage);
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
                    actions = new string[] { EditNormalAction, "Delete" };
                    break;
                default:
                    actions = new string[] { EditPatternAction, EditOccurrenceAction };
                    break;
            }
            return await this.DisplayActionSheet("Select the action", "Cancel", null, actions);
        }
    }
}

