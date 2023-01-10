using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DoAn.OriginalPage.Booking
{

    [DesignTimeVisible(false)]
    public partial class BookingPage : ContentPage

    {
        public List<PropertyType> PropertyTypeList => GetPropertyTypes();

        public List<Property> PropertyList;
        public BookingPage()
        {
            InitializeComponent();
            this.BindingContext = this;
            PropertyList = new List<Property>();
            InitProperty();
            BindableLayout.SetItemsSource(ShowList, PropertyList);
        }

        
        private List<PropertyType> GetPropertyTypes()
        {
            return new List<PropertyType>
            {
                new PropertyType { TypeName = "All" },
                new PropertyType { TypeName = "4 Bed" },
                new PropertyType { TypeName = "3 Bed" },
                new PropertyType { TypeName = "2 Bed" },
                new PropertyType { TypeName = "Studio" }
            };
        }
        public void InitProperty()
        {
            PropertyList.Add(new Property { latitude = 10.77039, longitude = 106.68926, email="hungthinhhotel@gmail.com", Image = "hotel_1.png", Address = "7 District", Location = "Ho Chi Minh", Price = "100$/Night", Bed = "4 Bed", Bath = "3 Bath", Space = "1600 sqft", Details = "Bringing the essence of luxury and sophistication, New World Saigon Hotel is the ideal option for you and your loved ones to experience a truly deluxe getaway in the heart of the city, located only five minutes from Ben Thanh Market. With many tempting incentive programmes running until the end of May, the hotel promises to take you on a journey of exquisite accommodation and gastronomic delights." });
            PropertyList.Add(new Property { latitude = 21.03239, longitude = 105.85211, email = "hoaphathotel@gmail.com", Image = "hotel3.jpg", Address = "Dong Da District", Location = "Ha Noi", Price = "200$/Night", Bed = "3 Bed", Bath = "1 Bath", Space = "1100 sqft", Details = "Canary Hanoi Hotel is a standard 3-star hotel with unique designs combined between traditions and modernity. The hotel has total of 40 bedrooms fully equipped with modern facilities,01 elevators, 01 restaurants and 01café lounge, souvenir stalls, … Canary Hanoi Hotel Hanoi is a perfect match between the unique style and innovative ideas. Keeping the environment green, clean & beautiful is not only our endeavor but the aim of the whole world." });
            PropertyList.Add(new Property { latitude = 16.05374, longitude = 108.24736, email = "lungcuhotel@gmail.com",Image = "hotel4.jpg", Address = "Lien Chieu District", Location = "Da Nang", Price = "300$/Night", Bed = "2 Bed", Bath = "2 Bath", Space = "1200 sqft", Details = "Mitisa hotel is situated in Nguyen Van Linh, the golden street and close to dynamic Danang’s popular attractions such as finance and trade centers, entertainment venues and gastronomic destinations. The hotel is only 0.5km of Danang International Airport and a few-minute walking from Dragon Bridge where the street along romantic Han River is regarded by tourists as Vietnam’s the most beautiful street. It takes only 3 minutes for you to drive from the hotel to My Khe beach, once listed in Forbes Magazine as one of the “World’s Most Luxurious Beaches”." });
            PropertyList.Add(new Property { latitude = 10.177126, longitude = 106.68949,email = "donghoahotel@gmail.com",Image = "hotel5.jpg", Address = "Nha Trang Center", Location = "Khanh Hoa", Price = "150$/Night", Bed = "4 Bed", Bath = "3 Bath", Space = "1400 sqft", Details = "Canary Khanh Hoa Hotel is a standard 4-star hotel with unique designs combined between traditions and modernity. The hotel has total of 40 bedrooms fully equipped with modern facilities,01 elevators, 01 restaurants and 01café lounge, souvenir stalls, … Canary Hanoi Hotel Hanoi is a perfect match between the unique style and innovative ideas. Keeping the environment green, clean & beautiful is not only our endeavor but the aim of the whole world." });
            PropertyList.Add(new Property { latitude = 10.03683, longitude = 105.78992,email = "viettienhotel@gmail.com", Image = "hotel6.jpg", Address = "8 District", Location = "Can Tho", Price = "120$/Night", Bed = "2 Bed", Bath = "2 Bath", Space = "1200 sqft", Details = "The hotel is located in the population area luxury hotels and cultural centers, commercial and financial city of Can Tho. Ninh Kieu 2 Hotel - Can Tho has 108 comfortable rooms including 4 categories: VIP Suite, Deluxe, Superior and Standard..All are equipped with modern and luxurious wooden furniture luxury. Bathroom with luxury bath, separate VIP room suite with a bathtub and separate shower." });
            PropertyList.Add(new Property { latitude = 10.177126, longitude = 106.68949,email = "namhaihotel@gmail.com", Image = "hotel7.jpg", Address = "Dong Hoi Center", Location = "Quang Binh", Price = "140$/Night", Bed = "4 Bed", Bath = "3 Bath", Space = "1700 sqft", Details = "The hotel is located in the population area luxury hotels and cultural centers, commercial and financial city of Can Tho. Ninh Kieu 2 Hotel - Can Tho has 108 comfortable rooms including 4 categories: VIP Suite, Deluxe, Superior and Standard..All are equipped with modern and luxurious wooden furniture luxury. Bathroom with luxury bath, separate VIP room suite with a bathtub and separate shower." });
            PropertyList.Add(new Property { latitude = 10.177126, longitude = 106.68949,email = "hunghoahotel@gmail.com", Image = "hotel8.jpg", Address = "3 District", Location = "Phu Yen", Price = "126$/Night", Bed = "4 Bed", Bath = "3 Bath", Space = "1500 sqft", Details = "The hotel is located in the population area luxury hotels and cultural centers, commercial and financial city of Can Tho. Ninh Kieu 2 Hotel - Can Tho has 108 comfortable rooms including 4 categories: VIP Suite, Deluxe, Superior and Standard..All are equipped with modern and luxurious wooden furniture luxury. Bathroom with luxury bath, separate VIP room suite with a bathtub and separate shower." });
            PropertyList.Add(new Property { latitude = 10.177126, longitude = 106.68949,email = "hungphathotel@gmail.com", Image = "hotel6.jpg", Address = "Yen Ho District", Location = "Lao Cai", Price = "125$/Night", Bed = "4 Bed", Bath = "3 Bath", Space = "1900 sqft", Details = "The hotel is located in the population area luxury hotels and cultural centers, commercial and financial city of Can Tho. Ninh Kieu 2 Hotel - Can Tho has 108 comfortable rooms including 4 categories: VIP Suite, Deluxe, Superior and Standard..All are equipped with modern and luxurious wooden furniture luxury. Bathroom with luxury bath, separate VIP room suite with a bathtub and separate shower." });
            PropertyList.Add(new Property { latitude = 10.177126, longitude = 106.68949,email = "lanphuonghotel@gmail.com", Image = "apt3.png", Address = "Lao Cai City", Location = "Lao Cai", Price = "129$/Night", Bed = "4 Bed", Bath = "3 Bath", Space = "1950 sqft", Details = "The hotel is located in the population area luxury hotels and cultural centers, commercial and financial city of Can Tho. Ninh Kieu 2 Hotel - Can Tho has 108 comfortable rooms including 4 categories: VIP Suite, Deluxe, Superior and Standard..All are equipped with modern and luxurious wooden furniture luxury. Bathroom with luxury bath, separate VIP room suite with a bathtub and separate shower." });
            PropertyList.Add(new Property { latitude = 10.177126, longitude = 106.68949,email = "kimngochotel@gmail.com", Image = "apt1.png", Address = "Vinh Phuc City", Location = "Vinh Phuc", Price = "140$/Night", Bed = "4 Bed", Bath = "3 Bath", Space = "1500 sqft", Details = "The hotel is located in the population area luxury hotels and cultural centers, commercial and financial city of Can Tho. Ninh Kieu 2 Hotel - Can Tho has 108 comfortable rooms including 4 categories: VIP Suite, Deluxe, Superior and Standard..All are equipped with modern and luxurious wooden furniture luxury. Bathroom with luxury bath, separate VIP room suite with a bathtub and separate shower." });
            PropertyList.Add(new Property { latitude = 10.177126, longitude = 106.68949, email = "linhtrunghotel@gmail.com", Image = "hotel6.jpg", Address = "10 District", Location = "Ninh Binh", Price = "145$/Night", Bed = "4 Bed", Bath = "3 Bath", Space = "1400 sqft", Details = "The hotel is located in the population area luxury hotels and cultural centers, commercial and financial city of Can Tho. Ninh Kieu 2 Hotel - Can Tho has 108 comfortable rooms including 4 categories: VIP Suite, Deluxe, Superior and Standard..All are equipped with modern and luxurious wooden furniture luxury. Bathroom with luxury bath, separate VIP room suite with a bathtub and separate shower." });
            PropertyList.Add(new Property { latitude = 10.177126, longitude = 106.68949,email = "tuanhunghotel@gmail.com", Image = "hotel7.jpg", Address = "Phan Thiet City", Location = "Binh Thuan", Price = "138$/Night", Bed = "4 Bed", Bath = "3 Bath", Space = "1300 sqft", Details = "The hotel is located in the population area luxury hotels and cultural centers, commercial and financial city of Can Tho. Ninh Kieu 2 Hotel - Can Tho has 108 comfortable rooms including 4 categories: VIP Suite, Deluxe, Superior and Standard..All are equipped with modern and luxurious wooden furniture luxury. Bathroom with luxury bath, separate VIP room suite with a bathtub and separate shower." });
            PropertyList.Add(new Property { latitude = 10.177126, longitude = 106.68949,email = "lachonghotel@gmail.com", Image = "apt2.png", Address = "7 District", Location = "Ho Chi Minh", Price = "114$/Night", Bed = "4 Bed", Bath = "3 Bath", Space = "1250 sqft", Details = "The hotel is located in the population area luxury hotels and cultural centers, commercial and financial city of Can Tho. Ninh Kieu 2 Hotel - Can Tho has 108 comfortable rooms including 4 categories: VIP Suite, Deluxe, Superior and Standard..All are equipped with modern and luxurious wooden furniture luxury. Bathroom with luxury bath, separate VIP room suite with a bathtub and separate shower." });
            PropertyList.Add(new Property { latitude = 10.177126, longitude = 106.68949,email = "kimdunghotel@gmail.com", Image = "hotel8.jpg", Address = "9 District", Location = "Thu Duc", Price = "129$/Night", Bed = "4 Bed", Bath = "3 Bath", Space = "1890 sqft", Details = "The hotel is located in the population area luxury hotels and cultural centers, commercial and financial city of Can Tho. Ninh Kieu 2 Hotel - Can Tho has 108 comfortable rooms including 4 categories: VIP Suite, Deluxe, Superior and Standard..All are equipped with modern and luxurious wooden furniture luxury. Bathroom with luxury bath, separate VIP room suite with a bathtub and separate shower." });
            PropertyList.Add(new Property { latitude = 10.177126, longitude = 106.68949,email = "hungthinh@gmail.com", Image = "hotel7.jpg", Address = "Ho Tay District", Location = "Ha Noi", Price = "160$/Night", Bed = "4 Bed", Bath = "3 Bath", Space = "2000 sqft", Details = "The hotel is located in the population area luxury hotels and cultural centers, commercial and financial city of Can Tho. Ninh Kieu 2 Hotel - Can Tho has 108 comfortable rooms including 4 categories: VIP Suite, Deluxe, Superior and Standard..All are equipped with modern and luxurious wooden furniture luxury. Bathroom with luxury bath, separate VIP room suite with a bathtub and separate shower." });

        }


        private void PropertySelected(object sender, EventArgs e)
        {
            var property = (sender as Grid).BindingContext as Property;
            Navigation.PushAsync(new DetailPage(property));

        }

        private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            var typeBed = ((Label)sender).Text;
            if (typeBed == "All")
            {
                BindableLayout.SetItemsSource(ShowList, PropertyList);
            }
            else
            {
                List<Property> list = new List<Property>();
                foreach (var item in PropertyList)
                {
                    if (item.Bed == typeBed)
                    {
                        list.Add(item);
                    }
                }
                
                BindableLayout.SetItemsSource(ShowList, list );
            }
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
        public double latitude { get; set; }

        public double longitude { get; set; }
        public string email { get; set; }
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
