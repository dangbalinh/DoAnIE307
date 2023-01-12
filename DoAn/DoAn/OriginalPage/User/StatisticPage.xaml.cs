using System;
using System.Collections.Generic;
using DoAn.Services;
using DoAn.Interfaces;
using Xamarin.Forms;

namespace DoAn.OriginalPage.User
{
    class TaskStatistic
    {
        public string Status { get; }
        public double Count { get; }

        public TaskStatistic(string status, double count)
        {
            this.Status = status;
            this.Count = count;
        }

    }

    public partial class StatisticPage : ContentPage
	{
        UserService userService;
        IAuth auth;
        int unfinishTasks;
        int finishTask;

        public StatisticPage ()
		{
			InitializeComponent ();
            userService = new UserService();
            auth = DependencyService.Get<IAuth>();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            unfinishTasks = await userService.GetNumberOfTasks(auth.GetEmail());
            finishTask = await userService.GetNumberOfDoneTasks(auth.GetEmail());

            var Statistics = new List<TaskStatistic>() {
                new TaskStatistic("Unfinished tasks", unfinishTasks),
                new TaskStatistic("Finished tasks", finishTask),
            };

            ChartDataSource.DataSource = Statistics;

        }

    }
}

