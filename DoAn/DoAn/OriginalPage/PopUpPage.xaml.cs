using System;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DoAn.OriginalPage
{
    
    public partial class PopUpPage : Popup
    {
        private Task _task;
        public PopUpPage(Task task)
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