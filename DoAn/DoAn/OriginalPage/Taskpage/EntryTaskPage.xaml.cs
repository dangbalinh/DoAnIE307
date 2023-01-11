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
using System.Threading.Tasks;

namespace DoAn.OriginalPage.Taskpage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public class TaskInfo
    {
        public string taskName { get; set; }
        public string taskType { get; set; }
        public DateTime taskDate { get; set; }
        public TimeSpan taskTime { get; set; }

        public TaskInfo()
        {
            taskName = "";
            taskType = "";
            taskDate = DateTime.Now;
            taskTime = DateTime.Now.TimeOfDay;
        }

        public TaskInfo(TaskDTO task)
        {
            taskName = task.taskName;
            taskType = task.taskType;
            taskDate = DateTime.Parse(task.taskDate);
            taskTime = TimeSpan.Parse(task.taskTime);
        }
    }

    public partial class EntryTaskPage : ContentPage
    {
        ToDoImplement ToDoImplement = new ToDoImplement();
        private string id;
        TaskDTO _task;
        IAuth auth;
        TaskInfo taskInfo;

        public EntryTaskPage()
        {
            InitializeComponent();
            taskInfo = new TaskInfo();
            dataForm.DataObject = taskInfo;
            dataForm.ValidateProperty += dataForm_ValidateProperty;
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

            taskInfo = new TaskInfo(task); 
            dataForm.DataObject = taskInfo;
            dataForm.ValidateProperty += dataForm_ValidateProperty;

        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            // validate taskInfo
            if(taskInfo.taskName == "" || taskInfo.taskType == "" || taskInfo.taskDate == null || taskInfo.taskTime == null)
            {
                Navigation.ShowPopup(new FailedActionPopup("All input fields are required"));
                return;
            } else{
                string date = taskInfo.taskDate.ToString("MM/dd/yyyy");
                string now = DateTime.Now.ToString("MM/dd/yyyy");

                if (DateTime.Parse(date) < DateTime.Parse(now))
                {
                    Navigation.ShowPopup(new FailedActionPopup("Date cannot be less than current date"));
                    return;
                } else if ( DateTime.Parse(date) == DateTime.Parse(now) && taskInfo.taskTime < DateTime.Now.TimeOfDay)
                {
                    Navigation.ShowPopup(new FailedActionPopup("DateTime cannot be less than current Datetime"));
                    return;
                }
            }

            TaskDTO dto = new TaskDTO();

            if (_task != null)
            {

                _task.taskName = taskInfo.taskName;
                _task.taskType = taskInfo.taskType;
                _task.taskDate = taskInfo.taskDate.ToString("MM/dd/yyyy");

                // format time HH:mm:ss
                _task.taskTime = taskInfo.taskTime.ToString(@"hh\:mm");
                _task.user_email = auth.GetEmail();

                await ToDoImplement.UpdateTodoItem(id, _task);
                Navigation.ShowPopup(new SuccessPopup("Update successfully"));
                await Navigation.PopAsync();
            } else {
                TaskToDo taskInit = new TaskToDo();

                taskInit.taskName = taskInfo.taskName;
                taskInit.taskType = taskInfo.taskType;
                taskInit.taskDate = taskInfo.taskDate;
                taskInit.taskTime = taskInfo.taskTime;
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

            // format time HH:mm:ss
            dto.taskTime = task.taskTime.ToString(@"hh\:mm");
            dto.user_email = task.user_email;
            return dto;
        }

        void dataForm_ValidateProperty(System.Object sender, DevExpress.XamarinForms.DataForm.DataFormPropertyValidationEventArgs e)
        {

            switch (e.PropertyName)
            {
                case "taskName":
                    if (e.NewValue.ToString() == "")
                    {
                        e.HasError = true;
                        e.ErrorText = "This field is required.";
                    }
                    taskInfo.taskName = e.NewValue.ToString();
                    break;
                case "taskType":
                    if (e.NewValue.ToString() == "")
                    {
                        e.HasError = true;
                        e.ErrorText = "This field is required.";
                    }
                    taskInfo.taskType = e.NewValue.ToString();
                    break;
                case "taskDate":
                    if (e.NewValue.ToString() == "")
                    {
                        e.HasError = true;
                        e.ErrorText = "This field is required.";
                    } else if (DateTime.Parse(e.NewValue.ToString()) < DateTime.Now)
                    {
                        e.HasError = true;
                        e.ErrorText = "Date cannot be less than current date";
                    }
                    taskInfo.taskDate = DateTime.Parse(e.NewValue.ToString());
                    break;
                case "taskTime":
                    if (e.NewValue.ToString() == "")
                    {
                        e.HasError = true;
                        e.ErrorText = "This field is required.";
                    } 

                    // if taskdate == now, time cannot be less than current time
                    if (taskInfo.taskDate.ToString("MM/dd/yyyy") == DateTime.Now.ToString("MM/dd/yyyy") && TimeSpan.Parse(e.NewValue.ToString()) < DateTime.Now.TimeOfDay)
                    {
                        e.HasError = true;
                        e.ErrorText = "Task datetime cannot be less than current datetime";
                    }

                    taskInfo.taskTime = TimeSpan.Parse(e.NewValue.ToString());
                    break;


            }
        }
    }
}