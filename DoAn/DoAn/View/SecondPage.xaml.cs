using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DoAn.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SecondPage : ContentPage
	{
		public SecondPage ()
		{
			InitializeComponent ();
		}

        private void signUpButton_Clicked(object sender, EventArgs e)
        {
			Navigation.PushAsync(new RegisterUser());
        }

    

        private async void LoginTap_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new LoginPage());
        }
    }
}