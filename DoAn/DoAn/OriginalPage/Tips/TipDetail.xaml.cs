using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using DoAn.Model;
using Xamarin.Forms;

namespace DoAn.OriginalPage.Tips
{
    public partial class TipDetail : ContentPage
    {
        public TipDetail(Tip t)
        {
            InitializeComponent();
            Title = t.Title;
            var sv = new ScrollView
            {
                Content = new StackLayout
                {
                    Margin = new Thickness(10),
                    Children =
                    {
                        new Image{Source = t.Image, Aspect = Aspect.AspectFill},

                        new Label
                        {
                            Text = t.Title,
                            FontSize = 36,
                            TextColor = Color.Black,
                            FontAttributes = FontAttributes.Bold,
                            HorizontalTextAlignment = TextAlignment.Center,
                            Margin = 30,
                        },

                        new Label
                        {
                            Text = t.Tag,
                            TextColor = Color.Gray,
                            FontSize = 24,
                            FontAttributes = FontAttributes.Bold,
                            HorizontalTextAlignment = TextAlignment.Center,
                            Margin = new Thickness(0,0,0,5)
                        },

                        new BoxView
                        {
                            HeightRequest = 1,
                            HorizontalOptions = LayoutOptions.FillAndExpand,
                            Color = Color.Gray,
                            Margin = new Thickness(0,0,0,5)

                        },

                        new Label
                        {
                            Text = t.Content,
                            FontSize = 16,
                            TextColor = Color.Black,
                        },

                    }
                }
            };
            this.Content = sv;
        }
    }

}

