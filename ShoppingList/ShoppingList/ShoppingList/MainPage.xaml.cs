using ShoppingList.iOS.Controller;
using ShoppingList.iOS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ShoppingList
{
    public partial class MainPage : ContentPage 
    {
        public MainPage() 
        {
            InitializeComponent();
            this.button.Clicked += NextPage;
        }

        private async void NextPage(object sender, EventArgs e) {
            await App.Current.MainPage.FadeTo(0, 200);
            App.Current.MainPage = new SecondPage(ProcessText(this.editor.Text));
            this.IsVisible = false;
            await App.Current.MainPage.FadeTo(0, 1);
            this.IsVisible = true;
            await App.Current.MainPage.FadeTo(1, 200);
        }

        private List<DataModel> ProcessText(String text) {
            return EditorTextController.CreateListWithSplit(text);
        }
    }
}
