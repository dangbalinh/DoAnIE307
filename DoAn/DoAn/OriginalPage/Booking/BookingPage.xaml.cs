using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DoAn.OriginalPage.Booking
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [DesignTimeVisible(false)]
    public partial class BookingPage : ContentPage
    {
        public BookingPage()
        {
            InitializeComponent();
            this.BindingContext = this;
        }
        public List<PropertyType> PropertyTypeList => GetPropertyTypes();

        public List<Property> PropertyList => GetProperties();

        private List<PropertyType> GetPropertyTypes()
        {
            return new List<PropertyType>
            {
                new PropertyType { TypeName = "All" },
                new PropertyType { TypeName = "Studio" },
                new PropertyType { TypeName = "4 Bed" },
                new PropertyType { TypeName = "3 Bed" },
                new PropertyType { TypeName = "Office" },
                new PropertyType { TypeName = "Hotel" }
            };
        }

        private List<Property> GetProperties()
        {
            return new List<Property>
            {
                new Property { Image = "apt1.png", Address = "7 District", Location = "Ho Chi Minh", Price = "1tr2/Night", Bed = "4 Bed", Bath = "3 Bath", Space = "1600 sqft", Details = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Bibendum est ultricies integer quis. Iaculis urna id volutpat lacus laoreet. Mauris vitae ultricies leo integer malesuada. Ac odio tempor orci dapibus ultrices in. Egestas diam in arcu cursus euismod. Dictum fusce ut" },
                new Property { Image = "apt2.png", Address = "Dong Da District", Location = "Ha Noi", Price = "1tr3/Night", Bed = "3 Bed", Bath = "1 Bath", Space = "1100 sqft", Details = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Bibendum est ultricies integer quis. Iaculis urna id volutpat lacus laoreet. Mauris vitae ultricies leo integer malesuada. Ac odio tempor orci dapibus ultrices in. Egestas diam in arcu cursus euismod. Dictum fusce ut" },
                new Property { Image = "apt3.png", Address = "Lien Chieu District", Location = "Da Nang", Price = "1tr4/Night", Bed = "2 Bed", Bath = "2 Bath", Space = "1200 sqft", Details = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Bibendum est ultricies integer quis. Iaculis urna id volutpat lacus laoreet. Mauris vitae ultricies leo integer malesuada. Ac odio tempor orci dapibus ultrices in. Egestas diam in arcu cursus euismod. Dictum fusce ut" },
                new Property { Image = "apt3.png", Address = "Lien Chieu District", Location = "Da Nang", Price = "1tr4/Night", Bed = "2 Bed", Bath = "2 Bath", Space = "1200 sqft", Details = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Bibendum est ultricies integer quis. Iaculis urna id volutpat lacus laoreet. Mauris vitae ultricies leo integer malesuada. Ac odio tempor orci dapibus ultrices in. Egestas diam in arcu cursus euismod. Dictum fusce ut" },
            };
        }
        
        private async void PropertySelected(object sender, EventArgs e)
        {
            var property = (sender as ViewCell).BindingContext as Property;
            await this.Navigation.PushAsync(new DetailPage(property));

        }

        private void SelectType(object sender, EventArgs e)
        {
            var view = sender as ViewCell;
            var parent = view.Parent as StackLayout;

            foreach (var child in parent.Children)
            {
                VisualStateManager.GoToState(child, "Normal");
                //ChangeTextColor(child, "#707070");
            }

            //VisualStateManager.GoToState(view, "Selected");
            ChangeTextColor(view, "#FFFFFF");
        }

        private void ChangeTextColor(ViewCell child, string hexColor)
        {
            var txtCtrl = child.FindByName<Label>("PropertyTypeName");

            if (txtCtrl != null)
                txtCtrl.TextColor = Color.FromHex(hexColor);
        }

     
    }

    public class PropertyType
    {
        public string TypeName { get; set; }
    }

    public class Property
    {
        public string Id => Guid.NewGuid().ToString("N");
        public string PropertyName { get; set; }
        public string Image { get; set; }
        public string Address { get; set; }
        public string Location { get; set; }
        public string Price { get; set; }
        public string Bed { get; set; }
        public string Bath { get; set; }
        public string Space { get; set; }
        public string Details { get; set; }
    }
    
}
