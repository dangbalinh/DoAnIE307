using System;
using System.Collections.ObjectModel;
using System.Globalization;
using DoAn.Model;
using DoAn.ModelDTO;
using DoAn.Services1.Implementations;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DoAn.PopupPages;
using Xamarin.CommunityToolkit.Extensions;
using DoAn.Services;
using DoAn.Interfaces;

namespace DoAn.OriginalPage.Taskpage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EntryTaskPage : ContentPage
    {
        ToDoImplement ToDoImplement = new ToDoImplement();
        private string id;
        TaskDTO _task;
        IAuth auth;

        public EntryTaskPage()
        {
            InitializeComponent();
            auth = DependencyService.Get<IAuth>();
        }

        public EntryTaskPage(string id, TaskDTO task)
        {
            InitializeComponent();
            auth = DependencyService.Get<IAuth>();
            Title = "Update task";
            CultureInfo culture = new CultureInfo("es-ES");
            this.id = id;
            _task = task;
            nameTask.Text = task.taskName;
            typeTask.Text = task.taskType;
            datepicker.Date = DateTime.Parse(task.taskDate, culture);
            timepicker.Time = TimeSpan.Parse(task.taskTime);
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            TaskDTO dto = new TaskDTO();
            if (string.IsNullOrWhiteSpace(nameTask.Text) || string.IsNullOrWhiteSpace(typeTask.Text))
            { 
                Navigation.ShowPopup(new FailedActionPopup("All input fields are required"));
                return;
            }

            if (_task != null)
            {
                _task.taskName = nameTask.Text;
                _task.taskType = typeTask.Text;
                _task.taskDate = datepicker.Date.ToString("MM/dd/yyyy");
                _task.taskTime = timepicker.Time.ToString();
                _task.user_email = auth.GetEmail();

                await ToDoImplement.UpdateTodoItem(id, _task);
                Navigation.ShowPopup(new SuccessPopup("Update successfully"));
                await Navigation.PopAsync();
            } else {
                TaskToDo taskInit = new TaskToDo();
                taskInit.taskName = nameTask.Text;
                taskInit.taskType = typeTask.Text;
                taskInit.taskDate = datepicker.Date;
                taskInit.taskTime = timepicker.Time;
                taskInit.user_email = auth.GetEmail();
                await ToDoImplement.AddTodoItem(ConvertToDTO(taskInit));
                Navigation.ShowPopup(new SuccessPopup("Add successfully"));
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
            dto.user_email = task.user_email;
            return dto;
        }          
    }
}