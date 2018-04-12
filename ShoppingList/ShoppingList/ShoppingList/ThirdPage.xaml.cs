using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace ShoppingList
{
    public partial class ThirdPage : ContentPage
    {
        public ThirdPage()
        {
            InitializeComponent();
            BackgroundClick();
        }

        private void BackgroundClick(){
            this.xlayout.GestureRecognizers.Add(new TapGestureRecognizer()
            {
                Command = new Command(async () =>
                {
                    await App.Current.MainPage.FadeTo(0, 200);
                    App.Current.MainPage = new MainPage();
                    this.IsVisible = false;
                    await App.Current.MainPage.FadeTo(0, 1);
                    this.IsVisible = true;
                    await App.Current.MainPage.FadeTo(1, 200);
                })
            });
        }
    }
}
