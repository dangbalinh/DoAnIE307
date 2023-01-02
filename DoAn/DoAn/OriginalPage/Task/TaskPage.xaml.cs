using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Xml.XPath;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DoAn.Model;



namespace DoAn.OriginalPage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TaskPage : ContentPage
    {
        public ObservableCollection<Task> listTask;
        public ObservableCollection<TaskType> listTaskType = new ObservableCollection<TaskType>();
        //List<Task> listTask = new List<Task>();
        public TaskPage()
        {
            InitializeComponent();
            //Device.StartTimer(TimeSpan.FromSeconds(1), ShowNotification);
            ListTask();
            //this.BindingContext = this;
        }
        bool ShowNotification()
        {
            foreach (var task in listTask)
            {
                if (DateTime.Now.TimeOfDay >= task.taskTime)
                {
                    DisplayAlert(task.taskType, task.taskName, "5Ting!!!!!");
                }
            }
            return true;


        }
        private void ListTask()
        {
            listTask = new ObservableCollection<Task>();
            //List<Task> listTask = new List<Task>();
            listTask.Add(new Task { taskId = 1, taskName = "Do Your Homework", taskType = "Working", taskDate = new DateTime(2012, 6, 12), taskTime = new TimeSpan(23, 23, 23) });
            listTask.Add(new Task { taskId = 2, taskName = "Do Your Homework", taskType = "Working", taskDate = new DateTime(2012, 6, 12), taskTime = new TimeSpan(23, 23, 23) });
            listTask.Add(new Task { taskId = 3, taskName = "Do Your Homework", taskType = "Working", taskDate = new DateTime(2012, 6, 12), taskTime = new TimeSpan(23, 23, 23) });
            listTask.Add(new Task { taskId = 4, taskName = "Do Your Homework", taskType = "Working", taskDate = new DateTime(2012, 6, 12), taskTime = new TimeSpan(23, 23, 23) });
            listTask.Add(new Task { taskId = 5, taskName = "Do Your Homework", taskType = "Working", taskDate = new DateTime(2012, 6, 12), taskTime = new TimeSpan(23, 23, 23) });

            listTaskType.Add(new TaskType { taskTypeId = 0, taskTypeName = "All" });
            listTaskType.Add(new TaskType { taskTypeId = 1, taskTypeName = "Working" });
            listTaskType.Add(new TaskType { taskTypeId = 2, taskTypeName = "Playing" });
            listTaskType.Add(new TaskType { taskTypeId = 3, taskTypeName = "Learning" });
            listTaskType.Add(new TaskType { taskTypeId = 4, taskTypeName = "Reload" });
            LtsTask.ItemsSource = listTask;
            BindableLayout.SetItemsSource(abc, listTaskType);
        }

        private void Button_Clicked(object sender, System.EventArgs e)
        {
            //listTask.Add(new Task { taskId = 5, taskName = "Do Your Homework", taskType = "Working" });
            //LtsTask.ItemsSource = listTask;
            Navigation.PushAsync(new EntryTaskPage(listTask));
        }



        private async void SWDelete_Invoked(object sender, System.EventArgs e)
        {
            var swipeItem = sender as SwipeItem;
            var item = swipeItem.CommandParameter as Task;
            bool answer = await DisplayAlert("Thông báo", $"Bạn có muốn xóa không?", "Yes", "No");
            if (answer)
            {
                listTask.Remove(item);
            }


        }

        private void SWEdit_Invoked(object sender, System.EventArgs e)
        {
            var swipeItem = sender as SwipeItem;
            var item = swipeItem.CommandParameter as Task;
            Navigation.PushAsync(new EntryTaskPage(item, listTask));
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            var typeTask = ((Label)sender).Text;
            if (typeTask == "All")
            {
                LtsTask.ItemsSource = listTask;
            }
            else
            {
                LtsTask.ItemsSource = listTask.Where(index => index.taskType == typeTask);
            }

        }

        private async void LtsTask_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = e.CurrentSelection[0] as Task;
            if (item != null)
            {
                await Navigation.ShowPopupAsync(new PopUpPage(item));
            }


        }

        private void SearchBarHotel_TextChanged(object sender, TextChangedEventArgs e)
        {
            LtsTask.ItemsSource = listTask.Where(index => index.taskName.StartsWith(e.NewTextValue));
        }


    }
}