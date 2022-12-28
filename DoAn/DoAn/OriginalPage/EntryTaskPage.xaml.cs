using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DoAn.OriginalPage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EntryTaskPage : ContentPage
    {
        public ObservableCollection<Task> listTask;
       
        public EntryTaskPage()
        {
            InitializeComponent();
        }
        public EntryTaskPage(ObservableCollection<Task> listTask)
        {
            InitializeComponent();
            this.listTask = listTask;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            var name = nameTask.Text;
            var type = typeTask.Text;
            var date = datepicker.Date;
            var time = timepicker.Time;
            DisplayAlert("DATE",name,"OK");
            listTask.Add(new Task { taskId = 4, taskName = name, taskType = type ,taskDate = date, taskTime = time });
        }
    }
}