using DoAn.Services1.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DoAn.OriginalPage.DoneTaskPage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Donetaskpage : ContentPage
    {
        public DoneTodoImplement doneTodoImplement;
        public Donetaskpage()
        {
            InitializeComponent();
            doneTodoImplement = new DoneTodoImplement();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            var allItems = await doneTodoImplement.GetAllDoneTodoItems();
            LtsTask.ItemsSource = allItems;
        }
    }
}