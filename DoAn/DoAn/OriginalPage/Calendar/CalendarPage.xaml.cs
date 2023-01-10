using System;

using Xamarin.Forms;

using DoAn.Services1.Implementations;
using DoAn.ModelDTO;
using DoAn.OriginalPage.Taskpage;
using Xamarin.CommunityToolkit.Extensions;

namespace DoAn.OriginalPage.Calendar
{
    public partial class CalendarPage : ContentPage
    {
        ToDoImplement toDoImplement;
        
        public CalendarPage()
        {
            InitializeComponent();
            toDoImplement = new ToDoImplement();
            
        }


        private async void calendar_DateSelectionChanged(object sender, XCalendar.Models.DateSelectionChangedEventArgs e)
        {
            var item = await toDoImplement.GetListTaskByDate(calendar.SelectedDates[0].ToString("MM/dd/yyyy"));
            LtsTask.ItemsSource = item;


        }

        private async void SWDelete_Invoked(object sender, EventArgs e)
        {
            var swipeItem = sender as SwipeItem;
            var item = swipeItem.CommandParameter as TaskDTO;
            bool answer = await DisplayAlert("Thông báo", $"Bạn có muốn xóa không?", "Yes", "No");
            if (answer)
            {
                await toDoImplement.DeleteTodoItem(item.taskId);
            }
            
        }

        private async void SWDetail_Invoked(object sender, EventArgs e)
        {
            var swipeItem = sender as SwipeItem;
            var item = swipeItem.CommandParameter as TaskDTO;
            await Navigation.ShowPopupAsync(new PopUpPage(item));
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            ((Image)sender).Source = ImageSource.FromFile("verified.png");
        }

        private void SWEdit_Invoked(object sender, EventArgs e)
        {
            var swipeItem = sender as SwipeItem;
            var item = swipeItem.CommandParameter as TaskDTO;
            Navigation.PushAsync(new EntryTaskPage(item.taskId, item));
        }
    }
}

