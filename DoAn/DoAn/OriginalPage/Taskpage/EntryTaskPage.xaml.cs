using System;

using System.Collections.ObjectModel;
using System.Globalization;
using DoAn.Model;
using DoAn.ModelDTO;
using DoAn.Services1.Implementations;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DoAn.OriginalPage.Taskpage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EntryTaskPage : ContentPage
    {
        ToDoImplement ToDoImplement = new ToDoImplement();
        private string id;
        TaskDTO _task;

        public EntryTaskPage()
        {
             
            InitializeComponent();
        }
        public EntryTaskPage(string id, TaskDTO task)
        {
            InitializeComponent();
            Title = "Update task";
            CultureInfo culture = new CultureInfo("es-ES");
            this.id = id;
            _task = task;
            nameTask.Text = task.taskName;
            typeTask.Text = task.taskType;
            datepicker.Date = DateTime.Parse(task.taskDate,culture);
            timepicker.Time = new TimeSpan(0,0,0,0);
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            TaskDTO dto = new TaskDTO();
            if (string.IsNullOrWhiteSpace(nameTask.Text) || string.IsNullOrWhiteSpace(typeTask.Text))
            {
                await DisplayAlert("Thông báo", "Vui lòng điền đầy đủ thông tin!", "OK");
            }
            if (_task != null)
            {
                _task.taskName = nameTask.Text;
                _task.taskType = typeTask.Text;
                _task.taskDate = datepicker.Date.ToString("MM/dd/yyyy");
                _task.taskTime = timepicker.Time.ToString();

                await ToDoImplement.UpdateTodoItem(id, _task);
                await DisplayAlert("Notification", "Update successful", "OK");
                await Navigation.PopAsync();
            }
            else
            {
                TaskToDo taskInit = new TaskToDo();
                taskInit.taskName = nameTask.Text;
                taskInit.taskType = typeTask.Text;
                taskInit.taskDate = datepicker.Date;
                taskInit.taskTime = timepicker.Time;
                await ToDoImplement.AddTodoItem(ConvertToDTO(taskInit));
                await DisplayAlert("Notification", "Add successful", "OK");
                await Navigation.PopAsync();
            }
        }
        private TaskDTO ConvertToDTO(TaskToDo task)
        {
            var dto = new TaskDTO();
            dto.taskId = task.taskId;
            dto.taskType = task.taskType;
            dto.taskName = task.taskName;
            dto.taskDate = task.taskDate.ToString("MM/dd/yyyy");
            dto.taskTime = task.taskTime.ToString();
            return dto;
        }          
    }
}