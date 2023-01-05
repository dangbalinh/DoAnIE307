using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using DoAn.Model;

namespace DoAn.OriginalPage.Calendar
{
    public partial class CalendarPage : ContentPage
    {
        public ObservableCollection<TaskToDo> listTask;
        public ObservableCollection<TaskToDo> listTaskShow;
        public CalendarPage()
        {
            InitializeComponent();
            listTaskShow = new ObservableCollection<TaskToDo>();
            listTask = new ObservableCollection<TaskToDo>();
            listTaskShow.Add(new TaskToDo { taskId = 1, taskName = "Do Your Homework", taskType = "Working", taskDate = new DateTime(2012, 6, 12), taskTime = new TimeSpan(23, 23, 23) });
            listTaskShow.Add(new TaskToDo { taskId = 2, taskName = "Do Your Homework", taskType = "Working", taskDate = new DateTime(2012, 6, 12), taskTime = new TimeSpan(23, 23, 23) });
            listTaskShow.Add(new TaskToDo { taskId = 3, taskName = "Do Your Homework", taskType = "Working", taskDate = new DateTime(2012, 6, 12), taskTime = new TimeSpan(23, 23, 23) });
            listTaskShow.Add(new TaskToDo { taskId = 4, taskName = "Do Your Homework", taskType = "Working", taskDate = new DateTime(2012, 6, 12), taskTime = new TimeSpan(23, 23, 23) });
            listTaskShow.Add(new TaskToDo { taskId = 5, taskName = "Do Your Homework", taskType = "Working", taskDate = new DateTime(2012, 6, 12), taskTime = new TimeSpan(23, 23, 23) });
            LtTask.ItemsSource = listTaskShow;
        }
        public CalendarPage(ObservableCollection<TaskToDo> listTask)
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

