using System;
using System.Xml;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DoAn.Model;


namespace DoAn.OriginalPage.Taskpage
{

    public partial class PopUpPage : Popup
    {
        private TaskToDo _task;
        public PopUpPage(TaskToDo task)
        {
            InitializeComponent();
            _task = task;
            nameLabel.Text = _task.taskName;
            typeLabel.Text = _task.taskType;
            dateLabel.Text = _task.taskDate.ToString("MM/dd/yyyy");
            timeLabel.Text = _task.taskTime.ToString();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {

        }
    }
}