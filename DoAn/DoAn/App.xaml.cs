using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DoAn.View;
using DoAn.OriginalPage;
namespace DoAn
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new TabbedPage1());
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
