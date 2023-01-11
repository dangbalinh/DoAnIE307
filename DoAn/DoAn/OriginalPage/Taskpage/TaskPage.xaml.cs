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
using DoAn.Services;
using DoAn.Interfaces;

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
        IAuth auth;
        List<TaskDTO> itemSource;

        public TaskPage()
        {
            ToDoImplement = new ToDoImplement();
            doneTodoImplement = new DoneTodoImplement();
            InitializeComponent();
            ListTask();
            auth = DependencyService.Get<IAuth>();

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
            itemSource = await ToDoImplement.GetAllTodoItems(auth.GetEmail());
            LtsTask.ItemsSource = itemSource;
        }
        // Delete task
        private async void SWDelete_Invoked(object sender, System.EventArgs e)
        {
            var swipeItem = sender as SwipeItem;
            var item = swipeItem.CommandParameter as TaskDTO;
            bool answer = await DisplayAlert("Warning", $"Do you want to delete this to-do?", "Yes", "No");
            if (answer)
            {
                await ToDoImplement.DeleteTodoItem(item.taskId);
            }
            var allItems = await ToDoImplement.GetAllTodoItems(auth.GetEmail());
            LtsTask.ItemsSource = allItems;

        }
        // Edit task
        private void SWEdit_Invoked(object sender, System.EventArgs e)
        {
            var swipeItem = sender as SwipeItem;
            var item = swipeItem.CommandParameter as TaskDTO;
            Navigation.PushAsync(new EntryTaskPage(item.taskId, item));
        }
        // Filter task
        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            var typeTask = ((Label)sender).Text;
            if (typeTask == "All")
            {
                LtsTask.ItemsSource = await ToDoImplement.GetAllTodoItems(auth.GetEmail());
            }
            else
            {
                LtsTask.ItemsSource = await ToDoImplement.GetListTaskByType(typeTask);
            }

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
            var allItems = await ToDoImplement.GetAllTodoItems(auth.GetEmail());
            LtsTask.ItemsSource = allItems;
        }

        void TasksSearchBar_TextChanged(System.Object sender, Xamarin.Forms.TextChangedEventArgs e)
        {
            // searching for taskName or taskType
            LtsTask.ItemsSource = itemSource.Where(item => item.taskName.ToLower().Contains(e.NewTextValue.ToLower()) || item.taskType.ToLower().Contains(e.NewTextValue.ToLower()));
        }
    }
}