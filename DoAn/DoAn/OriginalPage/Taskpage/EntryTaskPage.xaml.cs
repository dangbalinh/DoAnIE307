using System;

using System.Collections.ObjectModel;
using DoAn.Model;


using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DoAn.OriginalPage.Taskpage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EntryTaskPage : ContentPage
    {
        public ObservableCollection<TaskToDo> listTask;
        TaskToDo _task;

        public EntryTaskPage()
        {
            InitializeComponent();
        }
        public EntryTaskPage(ObservableCollection<TaskToDo> listTask)
        {
            InitializeComponent();
            this.listTask = listTask;
        }
        public EntryTaskPage(TaskToDo task, ObservableCollection<TaskToDo> listTask)
        {
            InitializeComponent();
            Title = "Update task";
            this.listTask = listTask;
            _task = task;
            nameTask.Text = task.taskName;
            typeTask.Text = task.taskType;
            datepicker.Date = task.taskDate;
            timepicker.Time = task.taskTime;
            listTask.Remove(_task);
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(nameTask.Text) || string.IsNullOrWhiteSpace(typeTask.Text))
            {
                await DisplayAlert("Thông báo", "Vui lòng điền đầy đủ thông tin!", "OK");
            }
            if (_task != null)
            {
                _task.taskName = nameTask.Text;
                _task.taskType = typeTask.Text;
                _task.taskDate = datepicker.Date;
                _task.taskTime = timepicker.Time;
                listTask.Add(_task);
                await Navigation.PopAsync();
            }
            else
            {
                var name = nameTask.Text;
                var type = typeTask.Text;
                var date = datepicker.Date;
                var time = timepicker.Time;
                await DisplayAlert("DATE", name, "OK");
                listTask.Add(new TaskToDo { taskId = 4, taskName = name, taskType = type, taskDate = date, taskTime = time });
                await Navigation.PopAsync();
            }

        }
    }
}