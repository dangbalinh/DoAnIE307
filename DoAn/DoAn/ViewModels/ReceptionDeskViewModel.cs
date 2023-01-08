using System;
using System.Collections.Generic;
using System.ComponentModel;
using DoAn.Services;
using DoAn.Model;
using System.Collections.ObjectModel;


namespace DoAn.ViewModels
{
    public class ReceptionDeskViewModel : INotifyPropertyChanged
    {
        readonly ReceptionDeskData data;

        AppointmentService appointmentService = new AppointmentService();

        public event PropertyChangedEventHandler PropertyChanged;
        public DateTime StartDate { get { return ReceptionDeskData.BaseDate; } }
        public IReadOnlyList<MedicalAppointment> MedicalAppointments
        { get => data.MedicalAppointments; }

        public ReceptionDeskViewModel()
        {
            data = new ReceptionDeskData();
            //Init();
        }

        //async void Init()
        //{
        //    var x = await appointmentService.GetAppointments();
        //    MedicalAppointments = x;
        //}

        protected void RaisePropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }
}

