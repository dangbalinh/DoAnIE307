using System;
using Xamarin.Forms;

using DoAn.View;
using DoAn.OriginalPage;
using DoAn.Interfaces;
using Plugin.SharedTransitions;

[assembly: ExportFont("KleeOne-Regular.ttf", Alias = "kleeFont")]

[assembly: ExportFont("DancingScript-Regular.ttf", Alias = "dancingFont")]
namespace DoAn
{
    public partial class App : Application
    {
        readonly IAuth auth;
        public App()
        {
            DevExpress.XamarinForms.Scheduler.Initializer.Init();
            DevExpress.XamarinForms.Charts.Initializer.Init();
            InitializeComponent();
            auth = DependencyService.Get<IAuth>();

            if (auth.IsLoggedInAsync())
                MainPage = new SharedTransitionNavigationPage(new HomePage());

            MainPage = new SharedTransitionNavigationPage(new BeginningPage());
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
