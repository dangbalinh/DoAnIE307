using System;

using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace DoAn.OriginalPage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TaskPage : ContentPage
    {
        public ObservableCollection<Task> listTask;
        //List<Task> listTask = new List<Task>();
        public TaskPage()
        {
            InitializeComponent();
            //Device.StartTimer(TimeSpan.FromSeconds(1), ShowNotification);
            ListTask();
        }
        bool ShowNotification()
        {
            foreach (var task in listTask)
            {
                //if (_switch.IsToogled && DateTime.Now.TimeOfDay >= task.taskTime )
                //{
                //    _switch.IsToolged = false;
                //    DisplayAlert("Time alert", "kkkk", "OK");
                //}
            }
            

            return true;
        }
        private void ListTask()
        {
            listTask= new ObservableCollection<Task>();
            //List<Task> listTask = new List<Task>();
            listTask.Add(new Task { taskId = 1, taskName = "Do Your Homework", taskType = "Working" , taskDate =  new DateTime(2012,6,12) , taskTime = new TimeSpan(23,23,23)});
            listTask.Add(new Task { taskId = 2, taskName = "Do Your Homework", taskType = "Working", taskDate = new DateTime(2012, 6, 12), taskTime = new TimeSpan(23, 23, 23) });
            listTask.Add(new Task { taskId = 3, taskName = "Do Your Homework", taskType = "Working", taskDate = new DateTime(2012, 6, 12), taskTime = new TimeSpan(23, 23, 23) });
            listTask.Add(new Task { taskId = 4, taskName = "Do Your Homework", taskType = "Working", taskDate = new DateTime(2012, 6, 12), taskTime = new TimeSpan(23, 23, 23) });
            listTask.Add(new Task { taskId = 5, taskName = "Do Your Homework", taskType = "Working", taskDate = new DateTime(2012, 6, 12), taskTime = new TimeSpan(23, 23, 23) });

            LtsTask.ItemsSource = listTask;
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
            if(answer)
            {
                listTask.Remove(item);
            }


        }

        private void SWEdit_Invoked(object sender, System.EventArgs e)
        {
            var swipeItem = sender as SwipeItem;
            var item = swipeItem.CommandParameter as Task;

        }
    }
}