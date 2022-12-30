using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace DoAn.OriginalPage
{	
	public partial class CalendarPage : ContentPage
	{	
		public CalendarPage ()
		{
			InitializeComponent ();
		}

        void calendar_DateSelectionChanged(System.Object sender, XCalendar.Models.DateSelectionChangedEventArgs e)
        {
			date.Text = calendar.SelectedDates.ToString();
        }
    }
}

