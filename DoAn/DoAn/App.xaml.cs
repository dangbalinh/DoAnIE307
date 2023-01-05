using System;
using Xamarin.Forms;

using DoAn.View;
using DoAn.OriginalPage;
namespace DoAn
{
    public partial class App : Application
    {
        public App()
        {
            DevExpress.XamarinForms.Scheduler.Initializer.Init();
            InitializeComponent();
            MainPage = new NavigationPage(new LoginPage());
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
