using System;
using Xamarin.Forms;

using DoAn.View;
using DoAn.OriginalPage;
using DoAn.OriginalPage.Taskpage;
using DoAn.OriginalPage.Calendar;

namespace DoAn
{
    public partial class App : Application
    {
        public App()
        {
            DevExpress.XamarinForms.Scheduler.Initializer.Init();
            InitializeComponent();
            MainPage = new NavigationPage(new CalendarPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
