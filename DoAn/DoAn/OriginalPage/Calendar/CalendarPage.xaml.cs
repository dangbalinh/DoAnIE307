using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using DoAn.Model;

namespace DoAn.OriginalPage
{
    public partial class CalendarPage : ContentPage
    {
        public ObservableCollection<Task> listTask;
        public ObservableCollection<Task> listTaskShow;
        public CalendarPage()
        {
            InitializeComponent();
            listTaskShow = new ObservableCollection<Task>();
            listTask = new ObservableCollection<Task>();
            listTaskShow.Add(new Task { taskId = 1, taskName = "Do Your Homework", taskType = "Working", taskDate = new DateTime(2012, 6, 12), taskTime = new TimeSpan(23, 23, 23) });
            listTaskShow.Add(new Task { taskId = 2, taskName = "Do Your Homework", taskType = "Working", taskDate = new DateTime(2012, 6, 12), taskTime = new TimeSpan(23, 23, 23) });
            listTaskShow.Add(new Task { taskId = 3, taskName = "Do Your Homework", taskType = "Working", taskDate = new DateTime(2012, 6, 12), taskTime = new TimeSpan(23, 23, 23) });
            listTaskShow.Add(new Task { taskId = 4, taskName = "Do Your Homework", taskType = "Working", taskDate = new DateTime(2012, 6, 12), taskTime = new TimeSpan(23, 23, 23) });
            listTaskShow.Add(new Task { taskId = 5, taskName = "Do Your Homework", taskType = "Working", taskDate = new DateTime(2012, 6, 12), taskTime = new TimeSpan(23, 23, 23) });
            LtTask.ItemsSource = listTaskShow;
        }
        public CalendarPage(ObservableCollection<Task> listTask)
        {
            this.listTask = listTask;
        }

        private void calendar_DateSelectionChanged(object sender, XCalendar.Models.DateSelectionChangedEventArgs e)
        {
            DisplayAlert("Date Changed", calendar.SelectedDates[0].ToString(), "OK");
            foreach (var task in listTask)
            {
                if (task.taskDate == calendar.SelectedDates[0].Date)
                {
                    listTaskShow.Add(task);
                }

            }
        }
    }
}

