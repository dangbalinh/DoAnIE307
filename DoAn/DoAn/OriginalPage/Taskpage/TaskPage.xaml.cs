using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Xml.XPath;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DoAn.Model;
using DoAn.ModelDTO;
using DoAn.Services1.Implementations;
using DoAn.OriginalPage.DoneTaskPage;

namespace DoAn.OriginalPage.Taskpage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TaskPage : ContentPage
    {
        public ToDoImplement ToDoImplement;
        public DoneTodoImplement doneTodoImplement;
        public ObservableCollection<TaskToDo> listTask;
        public ObservableCollection<TaskDTO> listTaskDTO;
        public ObservableCollection<TaskType> listTaskType; 
        
        public TaskPage()
        {
            ToDoImplement = new ToDoImplement();
            doneTodoImplement = new DoneTodoImplement();
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
            listTask = new ObservableCollection<TaskToDo>();
            listTaskDTO = new ObservableCollection<TaskDTO>();
            listTaskType = new ObservableCollection<TaskType>();
            listTaskType.Add(new TaskType { taskTypeId = 0, taskTypeName = "All" });
            listTaskType.Add(new TaskType { taskTypeId = 1, taskTypeName = "Working" });
            listTaskType.Add(new TaskType { taskTypeId = 2, taskTypeName = "Playing" });
            listTaskType.Add(new TaskType { taskTypeId = 3, taskTypeName = "Learning" });
            listTaskType.Add(new TaskType { taskTypeId = 4, taskTypeName = "Household" });
            BindableLayout.SetItemsSource(abc, listTaskType);
        }

        private void Button_Clicked(object sender, System.EventArgs e)
        {
            
            Navigation.PushAsync(new EntryTaskPage());
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            var allItems = await ToDoImplement.GetAllTodoItems();
            LtsTask.ItemsSource = allItems;
        }
        // Delete task
        private async void SWDelete_Invoked(object sender, System.EventArgs e)
        {
            var swipeItem = sender as SwipeItem;
            var item = swipeItem.CommandParameter as TaskDTO;
            bool answer = await DisplayAlert("Thông báo", $"Bạn có muốn xóa không?", "Yes", "No");
            if (answer)
            {
                await ToDoImplement.DeleteTodoItem(item.taskId);
            }
            var allItems = await ToDoImplement.GetAllTodoItems();
            LtsTask.ItemsSource = allItems;

        }
        // Edit task
        private void SWEdit_Invoked(object sender, System.EventArgs e)
        {
            var swipeItem = sender as SwipeItem;
            var item = swipeItem.CommandParameter as TaskDTO;
            Navigation.PushAsync(new EntryTaskPage(item.taskId,item));
        }
        // Filter task
        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            var typeTask = ((Label)sender).Text;
            if (typeTask == "All")
            {
                LtsTask.ItemsSource = await ToDoImplement.GetAllTodoItems();
            }
            else
            {

                LtsTask.ItemsSource = await ToDoImplement.GetListTaskByType(typeTask);
            }

        }

        private async void SearchBarHotel_TextChanged(object sender, TextChangedEventArgs e)
        {
            var allItems = await ToDoImplement.GetAllTodoItems();
            LtsTask.ItemsSource = allItems.Where(index => index.taskName.StartsWith(e.NewTextValue));
        }

        

        private  void TapGestureRecognizer_Tapped_2(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Donetaskpage());
        }

        private async void LtsTask_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var itemSelected = e.CurrentSelection[0] as TaskDTO;
            if (itemSelected != null)
            {
                await Navigation.ShowPopupAsync(new PopUpPage(itemSelected));
            }
        }

        async void SWDone_Invoked(System.Object sender, System.EventArgs e)
        {
            var swipeItem = sender as SwipeItem;
            var item = swipeItem.CommandParameter as TaskDTO;
            await doneTodoImplement.AddDoneTodoItem(item);
            await ToDoImplement.DeleteTodoItem(item.taskId);
        }
    }
}