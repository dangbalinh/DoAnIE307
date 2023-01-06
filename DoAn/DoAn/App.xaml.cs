using System;
using Xamarin.Forms;

using DoAn.View;
using DoAn.OriginalPage;
using DoAn.Interfaces;
namespace DoAn
{
    public partial class App : Application
    {
        readonly IAuth auth;
        public App()
        {
            DevExpress.XamarinForms.Scheduler.Initializer.Init();
            InitializeComponent();
            auth = DependencyService.Get<IAuth>();

            if (auth.IsLoggedInAsync())
                MainPage = new NavigationPage(new HomePage());

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
