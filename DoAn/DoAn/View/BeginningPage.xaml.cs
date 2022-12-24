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
	public partial class BeginningPage : ContentPage
	{
		public BeginningPage ()
		{
			InitializeComponent ();
		}

     

        private void button_start_Clicked(object sender, EventArgs e)
        {
			Navigation.PushAsync(new SecondPage ());
        }
    }
}