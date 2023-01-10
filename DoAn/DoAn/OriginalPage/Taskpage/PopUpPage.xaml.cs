using System;
using System.Xml;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DoAn.Model;
using DoAn.ModelDTO;


namespace DoAn.OriginalPage.Taskpage
{

    public partial class PopUpPage : Popup
    {
        //private TaskDTO _task;
        public PopUpPage(TaskDTO task)
        {
            InitializeComponent();
            nameLabel.Text = task.taskName;
            typeLabel.Text = task.taskType;
            dateLabel.Text = task.taskDate;
            timeLabel.Text = task.taskTime;
        }

    }
}